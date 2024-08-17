namespace Strategy.DataType {
    public class CumulativeReturn {
        private CumulativeSum sumReturn;
        private decimal lastPrice;
        public decimal value => sumReturn.value;

        public CumulativeReturn() {
            sumReturn = new CumulativeSum();
            lastPrice = 0;
        }

        public void Reset() {
            sumReturn.Reset();
            lastPrice = 0;
        }

        public void Update(decimal value) {
            // value is the current price
            if (lastPrice != 0) {
                sumReturn.Update((value - lastPrice) / lastPrice);
            }
            lastPrice = value;
        }
    }
}
