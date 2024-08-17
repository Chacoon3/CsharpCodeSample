namespace Strategy.DataType {
    /// <summary>
    /// Simple moving average indicator. one fast and one slow sma's.
    /// </summary>
    public class SmaCross : Cross {
        private Sma _fast;
        private Sma _slow;

        public override decimal? fast => _fast.value;
        public override decimal? slow => _slow.value;
        public override bool isReady => prevDiff.HasValue && diff.HasValue;

        public SmaCross(int fastSize, int slowSize) {
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
            diff = _fast.value - _slow.value;
        }

        public override void OnReset() {
            _fast.Reset();
            _slow.Reset();
        }
    }
}
