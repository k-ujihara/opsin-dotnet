using System.Collections;
using System.Collections.Generic;

namespace Opsin
{
    internal class ReadOnlyListWrapper<T> : IReadOnlyList<T>
    {
        private readonly java.util.List list;

        internal ReadOnlyListWrapper(java.util.List list)
        {
            this.list = list;
        }

        public T this[int index]
            => (T)list.get(index);

        public int Count => list.size();

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < list.size(); i++)
                yield return (T)list.get(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
