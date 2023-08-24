using Microsoft.VisualStudio.TestTools.UnitTesting;
using HashTable;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Drawing;

namespace HashTableTests
{
    [TestClass]
    public class MyHashSetTest
    {

        [TestInitialize]
        public void Initialize()
        {

        }

        [TestMethod]
        public void TestInt()
        {
            MyHashSet<myInt> test1 = new MyHashSet<myInt>();
            test1.Add(new myInt(9));
            test1.Add(new myInt(7));


            Assert.AreEqual(test1.Contains(new myInt(7)), true);
            Assert.AreEqual(test1.Contains(new myInt(5)), false);
        }

        [TestMethod]
        public void TestString()
        {
            MyHashSet<myString> test2 = new MyHashSet<myString>();
            test2.Add(new myString("dd"));
            test2.Add(new myString("d"));

            Assert.AreEqual(test2.Contains(new myString("d")), true);
            Assert.AreEqual(test2.Contains(new myString("r")), false);
        }
    }
}