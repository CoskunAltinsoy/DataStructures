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
        public Array(params T[] initial)
        {
            InnerList = new T[initial.Length];
            Count = 0;
            initial.ToList().ForEach(i => Add(i));
        }
        public Array(IEnumerable<T> collection)
        {
            InnerList = new T[collection.ToArray().Length];
            Count = 0;
            collection.ToList().ForEach(c => Add(c));
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
        public void AddRange(IEnumerable<T> collection)
        {
            collection.ToList().ForEach(c => Add(c));
        }
        public T Remove()
        {
            if (Count == 0)
            {
                throw new Exception("There is no item");
            }
            if (InnerList.Length / 4 == Count) 
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
        public bool Remove(T item)
        {
            if (Count == 0)
            {
                throw new Exception("There is no item");
            }
            if (InnerList.Length / 4 == Count)
            {
                HalfArray();
            }
            if (Count > 0)
            {
                Count--;
            }

            var tempArray = new T[Count];
            int count = 0;
            for (int i = 0; i < InnerList.Length; i++)
            {      
                if (!EqualityComparer<T>.Default.Equals(InnerList[i], item))
                {
                    tempArray[count] = InnerList[i];
                    count++;
                }
                
            }
            InnerList = tempArray;

            return true;
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
            //return this.MemberwiseClone();// shallow copy
            var arr = new Array<T>();//deep copy
            foreach (var item in this)
            {
                arr.Add(item);
            }
            return arr;
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