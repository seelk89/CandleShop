namespace CandleShop.Core.Entity
{
    public class Candle
    {
        public int id { get; set; }

        public string name { get; set; }

        public string type { get; set; }

        public double price { get; set; }

        public int stock { get; set; }

        public string imageURL { get; set; }
    }
}