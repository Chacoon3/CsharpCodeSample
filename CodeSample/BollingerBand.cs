namespace Strategy.DataType {
    public  class BollingerBand {
        private Sma ma;
        private decimal stdDevFactor;
        private decimal stdDev;
        private decimal? _upperBand;
        private decimal? _lowerBand;

        public int period => ma.period;
        public bool isReady => ma.isReady;
        /// <summary>
        /// the sma value
        /// </summary>
        public decimal? maValue => ma.value;
        public decimal? upperBand => _upperBand;
        public decimal? lowerBand => _lowerBand;
        /// <summary>
        /// last inserted value
        /// </summary>
        public decimal? lastObs { get; private set; }

        public BollingerBand(int period, decimal stdDevFactor = 2) {
            if (period <= 2) {
                throw new ArgumentException("period must be at least 2");
            }
            if (stdDevFactor <= 0) {
                throw new ArgumentException($"stdDev factor must be positive");
            }
            if (stdDevFactor >= 3) {
                Console.WriteLine($"warning: abnormal large std dec factor for bollinger band observed: {stdDevFactor}");
            }
            ma = new Sma(period);
            this.stdDevFactor = stdDevFactor;
        }

        public void Update(decimal price) {
            ma.Update(price);
            lastObs = price;
            if (ma.isReady) {
                var sampleVar = ma.Sum(x => (x - ma.value) * (x - ma.value)) / (ma.count - 1);
                stdDev = (decimal)Math.Sqrt((double)sampleVar);
                _upperBand = ma.value + stdDevFactor * stdDev;
                _lowerBand = ma.value - stdDevFactor * stdDev;
            }
        }
    }
}
