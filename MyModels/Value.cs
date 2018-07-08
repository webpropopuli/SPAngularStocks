namespace StockApp1.API.MyModels
{
    public class Value
    {
        public Value(int id, string name, string symbol, double close)
        {
            this.Id = id;
            this.Name = name;
            this.Symbol = symbol;
            this.Close = close;
        }

        public int Id { get; set; } // primary key
        public string Name { get; set; }
        public string Symbol { get; set; }
        public double Close { get; set; }
    }
}