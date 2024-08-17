namespace Strategy.DataType {
    public class NetGain {
        public string symbol;
        public decimal balance;
        public decimal? netGain;
        public decimal netBuyAmount;
        public decimal netSellAmount;

        public override string ToString() {
            return string.Format("{0},{1},{2},{3}", symbol, balance, netGain.HasValue ? netGain.Value.ToString("f2") : "undefined", netGain.HasValue ? (netGain.Value / netBuyAmount).ToString("p3") : "undefined");
        }
    }
}
