namespace Creative.Restaurant.Operations.App.Api.Models
{
    public class Unit
    {
        public int Id { get; set; }
        public string Abbr { get; set; }
        public string Name { get; set; }
        public bool IsByWeight { get; set; }
        public bool IsByVolume { get; set; }
    }
}