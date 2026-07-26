namespace Lab.Services
{
    public class EmailService : IEmailService

    {
        public string ProcessEmail(string email)
        {
            return ($"Email sent - {email}");
        }
    }
}
