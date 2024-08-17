namespace Strategy.DataType {
    public class CumulativeSum {
        public decimal value { get; private set;  }

        public CumulativeSum() {
            value = 0;
        }

        public void Reset() {
            value = 0;
        }

        public void Update(decimal value) {
            this.value += value;

        }
    }
}
