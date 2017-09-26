namespace Creative.Restaurant.Operations.App.Api.Models
{
    public class UnitConversion
    {
        public int Id { get; set; }
        public string FromUnitAbbr { get; set; }
        public string ToUnitAbbr { get; set; }
        public decimal Factor { get; set; }
    }
}