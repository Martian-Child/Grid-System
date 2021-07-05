using System.Collections;
using System.Collections.Generic;

namespace MartianChild.Utility.DataManipulation
{
    /// <summary>
    /// <para> Casts list from one type to another type of list. </para>
    /// <param name="TTo"> Type to cast list to. </param>
    /// <param name="TFrom"> Type of the list. </param>
    /// </summary>
    public class CastedList<TTo, TFrom> : IList<TTo> where TTo : TFrom
    {
        public readonly IList<TFrom> baseList;

        public CastedList(IList<TFrom> baseList)
        {
            this.baseList = baseList;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return baseList.GetEnumerator();
        }

        public IEnumerator<TTo> GetEnumerator()
        {
            return new CastedEnumerator<TTo, TFrom>(baseList.GetEnumerator());
        }

        public int Count => baseList.Count;

        public bool IsReadOnly => baseList.IsReadOnly;

        public void Add(TTo item)
        {
            baseList.Add((TFrom) (object) item);
        }

        public void Clear()
        {
            baseList.Clear();
        }

        public bool Contains(TTo item)
        {
            return baseList.Contains((TFrom) (object) item);
        }

        public void CopyTo(TTo[] array, int arrayIndex)
        {
            baseList.CopyTo((TFrom[]) (object) array, arrayIndex);
        }

        public bool Remove(TTo item)
        {
            return baseList.Remove((TFrom) (object) item);
        }

        // IList
        public TTo this[int index]
        {
            get => (TTo) (object) baseList[index];
            set => baseList[index] = (TFrom) (object) value;
        }

        public int IndexOf(TTo item)
        {
            return baseList.IndexOf((TFrom) (object) item);
        }

        public void Insert(int index, TTo item)
        {
            baseList.Insert(index, (TFrom) (object) item);
        }

        public void RemoveAt(int index)
        {
            baseList.RemoveAt(index);
        }
    }

    public class CastedEnumerator<TTo, TFrom> : IEnumerator<TTo>
    {
        public readonly IEnumerator<TFrom> baseEnumerator;

        public CastedEnumerator(IEnumerator<TFrom> baseEnumerator)
        {
            this.baseEnumerator = baseEnumerator;
        }

        // IDisposable
        public void Dispose()
        {
            baseEnumerator.Dispose();
        }

        // IEnumerator
        object IEnumerator.Current => baseEnumerator.Current;

        public bool MoveNext()
        {
            return baseEnumerator.MoveNext();
        }

        public void Reset()
        {
            baseEnumerator.Reset();
        }

        // IEnumerator<>
        public TTo Current => (TTo) (object) baseEnumerator.Current;
    }

    public static class ListExtensions
    {
        public static IList<TTo> CastList<TFrom, TTo>(this IList<TFrom> list) where TTo : TFrom
        {
            return new CastedList<TTo, TFrom>(list);
        }
    }
}