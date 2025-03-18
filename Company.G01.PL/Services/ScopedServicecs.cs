
namespace Company.G01.PL.Services
{
    public class ScopedServicecs : IScopedSerivece
    {
        public ScopedServicecs()
        {
            Guid=Guid.NewGuid();
        }
        public Guid Guid { get; set ; }

        public string GetGuid()
        {
            return Guid.ToString();
        }
    }
}
