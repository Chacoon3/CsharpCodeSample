using System.Collections;

namespace Strategy.DataType {

    public class RollingWindow : IEnumerable<Decimal> {
        public int size { get; private set; }
        public int count => m_queue.Count;
        public bool isReady => m_queue.Count == size;

        private Queue<Decimal> m_queue;

        public RollingWindow(int size) {
            m_queue = new Queue<Decimal>(size);
            this.size = size;
        }

        /// <summary>
        /// Enqueue the element and keeps the window size
        /// </summary>
        /// <param name="price"></param>
        /// <returns>the head element being dequeued or null otherwise</returns>
        public Decimal? Update(Decimal price) {
            Decimal? dequeued = null;
            if (m_queue.Count == size) {
                dequeued = m_queue.Dequeue();
            }
            m_queue.Enqueue(price);
            return dequeued;
        }

        public IEnumerator<Decimal> GetEnumerator() {
            return m_queue.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return m_queue.GetEnumerator();
        }
    }

    public class RollingWindow<T> : IEnumerable<T> {
        public int size { get; private set; }
        public int count => m_queue.Count;
        public bool isReady => m_queue.Count == size;

        private Queue<T> m_queue;

        public RollingWindow(int size) {
            m_queue = new Queue<T>(size);
            this.size = size;
        }

        public void Update(T price) {
            if (m_queue.Count == size) {
                m_queue.Dequeue();
            }
            m_queue.Enqueue(price);
        }

        public IEnumerator<T> GetEnumerator() {
            return m_queue.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return m_queue.GetEnumerator();
        }
    }
}