namespace Strategy.DataType {
    public class Macd: Cross {
        private readonly Ema fastEma;
        private readonly Ema slowEma;
        private readonly Ema signalEma;

        public override decimal? fast => fastEma.value;
        public override decimal? slow => slowEma.value;


        public Macd(int fastPeriod, int slowPeriod, int signalPeriod) {
            if (fastPeriod < 0 || slowPeriod < 0 || signalPeriod < 0) {
                throw new ArgumentException("period has to be positive");
            }

            if (fastPeriod >= slowPeriod) {
                throw new ArgumentException("fast window has to be shorter than slow window");
            }

            if (signalPeriod > fastPeriod) {
                Console.WriteLine("warning: Macd signal period recommended to be shorter than fast period. Violation detected.");
            }

            fastEma = new Ema(fastPeriod);
            slowEma = new Ema(slowPeriod);
            signalEma = new Ema(signalPeriod);
        }


        public override void Update(decimal price) {
            fastEma.Update(price);
            slowEma.Update(price);
            prevDiff = diff;
            signalEma.Update(fastEma.value.Value - slowEma.value.Value);
            diff = signalEma.value;
        }

        public override void OnReset() {
            fastEma.Reset();
            slowEma.Reset();
            signalEma.Reset();
        }
    }
}
