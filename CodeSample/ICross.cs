namespace Strategy.DataType {
    /// <summary>
    /// crosss indicator
    /// </summary>
    public interface ICross {
        decimal? diff { get; }
        decimal? fast { get; }
        decimal? slow { get; }
        bool isCrossOver { get; }
        bool isCrossUnder { get; }
        bool dropBelow { get; }
        bool riseAbove { get; }
        bool isReady { get; }
        decimal? prevDiff { get; }

        void Update(decimal price);
        void Reset();
    }
}