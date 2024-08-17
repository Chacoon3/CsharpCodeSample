namespace Strategy.DataType {
    internal class Orderbook {

        internal struct Entry {
            public decimal price;
            public decimal size;
        }

        public List<Entry> bids;
        public List<Entry> asks;

        public Orderbook() {
            bids = new();
            asks = new();
        }

        public Orderbook(int capacity) {
            bids = new(capacity);
            asks = new(capacity);
        }

        public void Reset() {
            bids.Clear();
            asks.Clear();
        }
    }
}
