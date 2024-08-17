using System.Collections;

namespace Strategy.DataType {
    /// <summary>
    /// simple moving average
    /// </summary>
    public class Sma : IEnumerable<decimal> {
        protected Queue<decimal> window;
        public int period { get; private set; }
        private decimal _value;

        public bool isReady => window.Count == period;
        public decimal? value {
            get {
                if (window.Count == period) {
                    return _value;
                }
                else {
                    return null;
                }
            }
        }
        public int count => window.Count;

        public Sma(int period) {
            if (period < 1) {
                throw new ArgumentException("window size must be a positive integer");
            }
            window = new Queue<decimal>(period);
            this.period = period;
        }

        /// <remarks>O(1) update</remarks>
        public virtual void Update(decimal price) {
            decimal? dequeued = null;
            if (window.Count == period) {
                dequeued = window.Dequeue();
            }
            window.Enqueue(price);

            if (window.Count == period) {
                if (dequeued.HasValue) {
                    _value = (_value * period - dequeued.Value + price) / period;
                }
                else {
                    _value = window.Average();
                }
            }
        }

        public void Reset() {
            window.Clear();
            _value = 0;
        }

        public IEnumerator<decimal> GetEnumerator() {
            return ((IEnumerable<decimal>)window).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return ((IEnumerable)window).GetEnumerator();
        }
    }
}
