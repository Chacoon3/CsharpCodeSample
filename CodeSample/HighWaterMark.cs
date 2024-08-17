namespace Strategy.DataType {
    public class HighWaterMark {
        public decimal? value { get; private set; }
        public bool hasChanged { get; private set; }

        public void Reset() {
            value = null;
            hasChanged = false;
        }

        public void Update(decimal value) {
            if (this.value == null) {
                this.value = value;
                hasChanged = true;
            }
            else {
                var prevValue = this.value;
                this.value = Math.Max(this.value.Value, value);
                hasChanged  = prevValue == null  || this.value != prevValue;
            }
        }
    }
}
