namespace Lab.Services
{
    public class TransientService : IGuidService
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
