using System.Diagnostics.CodeAnalysis;

namespace Strategy.DataType {
#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
#pragma warning disable CS0661 // Type defines operator == or operator != but does not override Object.GetHashCode()
    public readonly struct Pair<T> {
#pragma warning restore CS0661 // Type defines operator == or operator != but does not override Object.GetHashCode()
#pragma warning restore CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
        public readonly T first;
        public readonly T second;

        public Pair(T first, T second) {
            this.first = first;
            this.second = second;
        }

        public override bool Equals([NotNullWhen(true)] object obj) {
            if (obj is Pair<T> other) {
                return first.Equals(other.first) && second.Equals(other.second);
            }
            return false;
        }

        public static bool operator ==(Pair<T> a, Pair<T> b) {
            return a.Equals(b);
        }

        public static bool operator !=(Pair<T> a, Pair<T> b) {
            return !a.Equals(b);
        }
    }
}
