using System;
using System.Net.Mail;
using System.Text;
using System.Threading;
using MailKit.Net.Smtp;
using MimeKit;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Newtonsoft.Json;
using Inveon.Services.Mail;

class Program
{
    static void Main()
    {

        var factory = new ConnectionFactory()
        {
            HostName = "localhost",
            Port = 5672,
            UserName = "guest",
            Password = "guest"
        };

        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();
        var queueName = "checkoutqueue";

        channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();

            var message = Encoding.UTF8.GetString(body);

            MailContent mailContent = new MailContent();
            
            mailContent = JsonConvert.DeserializeObject<MailContent>(message);
            if(mailContent != null)
            {
                SendEmail(mailContent);
            }
        };

        channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);

        Console.WriteLine("RabbitMQ Consumer running... Press any key to exit.");
        Console.ReadLine();
    }

    static void SendEmail(MailContent mailContent)
    {
        string creditCardNumber = mailContent.CardNumber;
        string maskedCreditCardNumber = $"{new string('*', creditCardNumber.Length - 4)}{creditCardNumber.Substring(creditCardNumber.Length - 4)}";

        var emailMessage = new MimeMessage();
        emailMessage.From.Add(new MailboxAddress(StaticDefinitions.MailSenderName, StaticDefinitions.MailSenderAddress));
        emailMessage.To.Add(new MailboxAddress($"{mailContent.FirstName} {mailContent.LastName}", mailContent.Email));
        emailMessage.Subject = "Siparişinizi Aldık";
        emailMessage.Body = new TextPart("plain")

        {
            Text = $"Merhaba {mailContent.FirstName} {mailContent.LastName},\n\n" +
            $"{mailContent.PickupDateTime.ToString("dd MMMM yyyy HH:mm")} tarihli {mailContent.CartHeaderId} numaralı siparişiniz için " +
            $"{maskedCreditCardNumber} numaralı kartınızdan {mailContent.OrderTotal} tl tutarındaki ödemeniz alınmıştır." +
            $"\nSipariş durumunu websitemizden takip edebilirsiniz.\n\nBizi tercih ettiğiniz için teşekkürler. :)"
        };

        using var client = new MailKit.Net.Smtp.SmtpClient();
        client.Connect(StaticDefinitions.Host, 587, false);
        client.Authenticate(StaticDefinitions.MailSenderAddress, StaticDefinitions.MailSenderPassword);
        client.Send(emailMessage);
        client.Disconnect(true);
    }
}
