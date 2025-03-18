namespace Company.G01.PL.Services
{
    public interface ISengletonService
    {
        public Guid Guid { get; set; }
        string GetGuid();
    }
}
