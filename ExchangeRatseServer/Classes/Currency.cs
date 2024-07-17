namespace ExchangeRatseServer.Classes
{
    public class Currency
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string SymbolNative { get; set; }
        public int DecimalDigits { get; set; }
        public int Rounding { get; set; }
        public string Code { get; set; }
        public string NamePlural { get; set; }
        public string Type { get; set; }
    }
}
