namespace Strategy.DataType {
    /// <summary>
    /// Z score calculated on a rolling window
    /// </summary>
    public class RollingZ {
        public decimal zScore { get; private set; }
        public bool isReady => sma.isReady;
        private Sma sma;

        public RollingZ(int window) {
            sma = new Sma(window);
        }

        public void Update(decimal value) {
            sma.Update(value);
            decimal std = (decimal)(sma.Sum(x => (x - sma.value) * (x - sma.value)) / (sma.count - 1));
            if (isReady) {
                zScore = (value - sma.value.Value) / std;
            }
        }
    }
}
