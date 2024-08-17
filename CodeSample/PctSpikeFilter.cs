namespace Strategy.DataType {
    /// <summary>
    /// filter out spikes according to percentage change of price
    /// </summary>
    public class PctSpikeFilter {
        private decimal threshold;
        private decimal? _prev;

        public PctSpikeFilter() : this(1e-3m) {

        }

        public PctSpikeFilter(decimal threshold) {
            if (threshold < 0) {
                throw new ArgumentException("threshold has to be non negative");
            }
            this.threshold = threshold;
        }

        public void SetThreshold(decimal threshold) {
            if (threshold <= 0) {
                throw new ArgumentException("threshold has to be positive");
            }
            if (threshold >= 1) {
                Console.WriteLine("warning: spike filter factor greater than 1 detected. check if using the wrong scale. usually it should be a number no greater than 1");
            }
            this.threshold = threshold;
        }

        public decimal Filter(decimal price) {
            if (_prev == null) {
                _prev = price;
            }
            else {
                var res = Math.Clamp(price, _prev.Value * (1 - threshold), _prev.Value * (1 + threshold));
                _prev = res;
            }
            return _prev.Value;
        }
    }
}
