namespace Strategy.DataType {
    public class Vwap : Cross {
        private long cumVolume;
        private decimal cumAmount;
        private decimal? _vwap;

        public override decimal? fast => lastObs;
        public override decimal? slow => _vwap;
        public override bool isReady => _vwap.HasValue && lastObs.HasValue;

        public Vwap() {
            cumVolume = 0;
            cumAmount = 0;
            _vwap = null;
        }

        /// <summary>
        /// dummy method to be compatible with interface structure.
        /// </summary>
        /// <param name="price"></param>
        /// <exception cref="NotImplementedException"></exception>
        public override void Update(decimal price) {
            throw new NotImplementedException();
        }

        public void Update(decimal price, long volume) {
            if (price <= 0 || volume <= 0) {
                throw new ArgumentException("price and volume have to be both positive");
            }
            cumVolume += volume;
            cumAmount += price * volume;
            lastObs = price;
            _vwap = cumAmount / cumVolume;
            prevDiff = diff;
            diff = lastObs - _vwap;
        }

        public override void OnReset() {
            _vwap = null;
            lastObs = null;
        }
    }
}
