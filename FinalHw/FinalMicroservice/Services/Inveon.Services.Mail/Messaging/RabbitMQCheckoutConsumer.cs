using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;
using Inveon.Services.Mail;
using MimeKit;

namespace Inveon.Services.OrderAPI.Messaging
{
    public class RabbitMQCheckoutConsumer : BackgroundService
    {
        
        private IConnection _connection;
        private IModel _channel;

        public RabbitMQCheckoutConsumer()
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "checkoutqueue", false, false, false, arguments: null);
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

			var consumer = new EventingBasicConsumer(_channel);
			consumer.Received += (model, ea) =>
			{
				var body = ea.Body.ToArray();

				var message = Encoding.UTF8.GetString(body);

				MailContent mailContent = new MailContent();

				mailContent = JsonConvert.DeserializeObject<MailContent>(message);
				if (mailContent != null)
				{
					SendEmail(mailContent);
				}

				// _channel.BasicAck(ea.DeliveryTag, false);
			};

			_channel.BasicConsume(queue: "checkoutqueue", autoAck: true, consumer: consumer);
			
			return Task.CompletedTask;
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

			/*using var client = new MailKit.Net.Smtp.SmtpClient();
			client.Connect(StaticDefinitions.Host, 587, false);
			client.Authenticate(StaticDefinitions.MailSenderAddress, StaticDefinitions.MailSenderPassword);
			client.Send(emailMessage);
			client.Disconnect(true);
			*/
		}
	}
}
