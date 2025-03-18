namespace Company.G01.PL.Services
{
    public interface IScopedSerivece
    {
        public Guid Guid { get; set; }
        string GetGuid();
    }
}
