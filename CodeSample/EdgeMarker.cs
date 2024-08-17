namespace Strategy.DataType {
    /// <summary>
    /// Measures how much the value has deviated from its original value
    /// </summary>
    public class EdgeMarker {
        decimal _value;

        public decimal boundary => _value;

        public decimal retreat { get; private set; }

        public EdgeMarker(decimal value) {
            _value = value;
        }

        public EdgeMarker(decimal value, decimal retreat):this(value) {
            this.retreat = retreat;
        }

        public void Update(decimal value) {
            if (value >= 0) {
                if (_value >= 0) {
                    _value = Math.Max(_value, value);
                    retreat = _value - value;
                }
                else {
                    _value = value;
                    retreat = 0;
                }
            }
            else {  // value < 0
                if (_value < 0) {
                    _value = Math.Min(_value, value);
                    retreat = _value - value;
                }
                else {
                    _value = value;
                    retreat = 0;
                }
            }
        }

        public void Reset() {
            _value = 0;
        }

        public override string ToString() {
            return string.Format("(boundary:{0:p2}, retreat:{1:p2})", _value, retreat);
        }
    }
}