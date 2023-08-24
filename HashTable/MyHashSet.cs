using System;
using System.Linq;
using System.Text;

namespace HashTable
{
    public class MyHashSet<T> where T : IMyHashable
    {
        private List<T>[] dataInSlots;

        public MyHashSet()
        {
            dataInSlots = new List<T>[10];
            for (int i = 0; i < 10; i++) dataInSlots[i] = new List<T>();
        }

        public void Add(T input)
        {
            int slotId = input.getHashValue();
            dataInSlots[slotId].Add(input);
        }

        public bool Contains(T input)
        {
            int slotId = input.getHashValue();
            return dataInSlots[slotId].Contains(input);
        }
    }

    public class myInt : IMyHashable, IEquatable<myInt>
    {
        public int data;

        public myInt(int v)
        {
            data = v;
        }

        private int getValue()
        {
            return data;
        }

        public int getHashValue()
        {
            return data % 10;
        }

        public bool Equals(myInt other)
        {
            return other.data == data;
        }
    }

    public class myString : IMyHashable, IEquatable<myString>
    {
        public string data;

        public myString(string v)
        {
            data = v;
        }

        public int getHashValue()
        {
            int sumOfASCII = 0;
            foreach (char c in data)
            {
                sumOfASCII += c;
            }

            return sumOfASCII % 10;
        }

        public bool Equals(myString other)
        {
            return other.data == data;
        }
    }

    public interface IMyHashable
    {
        int getHashValue();
    }

}

