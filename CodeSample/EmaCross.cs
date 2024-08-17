namespace Strategy.DataType {
    public class EmaCross : Cross {
        private Ema _fast;
        private Ema _slow;

        public override decimal? fast => _fast.value;
        public override decimal? slow => _slow.value;
        /// <summary>
        /// if the moving averages are define, i.e., having sufficient data points
        /// </summary>
        public override bool isReady => prevDiff.HasValue && diff.HasValue;

        public EmaCross(int fastSize, int slowSize) {
            if (fastSize <= 0 || slowSize <= 0) {
                throw new ArgumentException("size must be positive");
            }
            if (fastSize >= slowSize) {
                throw new ArgumentException("fast size must be less than slow size");
            }
            _fast = new(fastSize);
            _slow = new(slowSize);
        }

        /// <summary>
        /// O(1) update
        /// </summary>
        /// <param name="price"></param>
        public override void Update(decimal price) {
            prevDiff = diff;
            _fast.Update(price);
            _slow.Update(price);
            lastObs = price;
            diff = _fast.value - _slow.value;
        }

        public override void OnReset() {
            _fast.Reset();
            _slow.Reset();
        }
    }
}
