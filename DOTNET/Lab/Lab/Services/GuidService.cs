namespace Lab.Services
{
    public class GuidService : IGuidService
    {
        public Guid Id { get; set; }= Guid.NewGuid();
    }
}
