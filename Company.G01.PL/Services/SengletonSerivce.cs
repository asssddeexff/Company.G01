namespace Company.G01.PL.Services
{
    public class SengletonSerivce:ISengletonService
    {
        public SengletonSerivce()
        {
            Guid = Guid.NewGuid();
        }
        public Guid Guid { get; set; }

        public string GetGuid()
        {
            return Guid.ToString();
        }
    }
}
