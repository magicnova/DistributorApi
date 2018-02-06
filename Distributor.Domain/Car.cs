namespace Distributor.Domain
{
    public class Car
    {
        public string Id { get; set; }
        public string Brand { get; set; }
        public string Motor { get; set; }
        public string Model { get; set; }
        public string Transmission { get; set; }
        public int Year { get; set; }
        public bool Active { get; set; }
    }
}