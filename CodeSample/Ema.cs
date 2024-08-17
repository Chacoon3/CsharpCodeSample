namespace Strategy.DataType {
    public class Ema {
        private readonly decimal factor;

        public bool isReady => value.HasValue;
        public decimal? value { get; private set; }

        public Ema(int period) {
            factor = 2m / (period + 1m);
        }

        public void Update(decimal price) {
            if (value.HasValue) {
                value = factor * price + (1 - factor) * value;
            }
            else {
                value = price;
            }
        }

        public void Reset() {
            value= null;
        }
    }
}
