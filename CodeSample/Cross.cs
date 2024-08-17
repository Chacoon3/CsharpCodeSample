namespace Strategy.DataType {
    public abstract class Cross : ICross {
        protected decimal? lastObs;

        public decimal? prevDiff { get; protected set; }
        public decimal? diff { get; protected set; }
        public abstract decimal? fast { get; }
        public abstract decimal? slow { get; }
        public virtual bool isReady { get; } = true;

        public bool isCrossOver => diff > 0 && prevDiff <= 0;
        public bool isCrossUnder =>diff < 0 && prevDiff >= 0;
        public virtual bool dropBelow => diff > 0 && lastObs < fast;
        public virtual bool riseAbove => diff < 0 && lastObs > fast;

        public abstract void Update(decimal price);

        public abstract void OnReset();

        public void Reset() {
            lastObs = null;
            diff = null;
            prevDiff = null;
            OnReset();
        }
    }
}
