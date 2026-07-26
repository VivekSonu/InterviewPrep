namespace Lab.Services
{
    public class ProductService(IPaymentService payment, IEmailService email) : IProductService
    {
        public string ProcessProduct()
        {
            payment.ProcessPayment();
            email.ProcessEmail("Payment done");

            return "Product proceesed";
        }
    }
}
