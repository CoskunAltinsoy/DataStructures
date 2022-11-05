using System.Collections;

namespace DataStructures.Arrays
{
    public class Array<T> : IEnumerable<T>, ICloneable
    {
        private T[] InnerList;
        public int Count { get; private set; }
        public int Capacity => InnerList.Length;
        public Array()
        {
            InnerList = new T[2];
            Count = 0;
        }
        public void Add(T item)
        {
            if (InnerList.Length==Count)
            {
                DoubleArray();
            }
            InnerList[Count] = item;
            Count++;
        }

        public T Remove()
        {
            if (Count == 0)
            {
                throw new Exception("There is no item");
            }
            if (InnerList.Length / 2 == Count) 
            {
                HalfArray();
            }
            var temp = InnerList[Count - 1];
            if (Count > 0) 
            {
                Count--;
            }

            var tempArray = new T[InnerList.Length];
            for (int i = 0; i < Count; i++)
            {
                tempArray[i] = InnerList[i];
            }
            InnerList = tempArray;
            return temp;

        }

        private void HalfArray()
        {
            if (InnerList.Length>2)
            {
                var temp = new T[InnerList.Length / 2];
                System.Array.Copy(InnerList, temp, temp.Length);
                InnerList = temp;
            }
        }

        private void DoubleArray()
        {
            var temp = new T[InnerList.Length * 2];
            System.Array.Copy(InnerList, temp, InnerList.Length);
            InnerList = temp;
        }
        public object Clone()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return InnerList.Select(x => x).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}