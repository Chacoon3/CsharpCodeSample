namespace Strategy.DataType {
    /// <summary>
    /// cumulative min value
    /// </summary>
    public class CumulativeMin {
        public decimal? value { get; private set; }
        public bool hasChanged { get; private set; }

        public CumulativeMin() {
            Reset();
        }

        public void Update(decimal price) {
            if (value == null) {
                value = price;
                hasChanged = true;
            }
            else {
                var prevValue = value;
                value = Math.Min(value.Value, price);
                hasChanged  = prevValue == null  || value != prevValue;
            }
        }

        public void Reset() {
            this.value = null;
            hasChanged = false;
        }
    }
}
