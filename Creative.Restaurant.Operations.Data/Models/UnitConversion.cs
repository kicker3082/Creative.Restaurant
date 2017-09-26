namespace Restaurant.Operations.Data.Models
{
    public class UnitConversion
    {
        public int Id { get; set; }
        public Unit FromUnit { get; set; }
        public Unit ToUnit { get; set; }
        public decimal Factor { get; set; }
    }
}