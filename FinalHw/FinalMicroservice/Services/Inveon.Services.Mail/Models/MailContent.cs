namespace Inveon.Services.Mail
{
    public class MailContent
    {        
        public double OrderTotal { get; set; }
        public int CartHeaderId { get; set; }
        public DateTime PickupDateTime { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CardNumber { get; set; }
        public string Email { get; set; }
    }
}
