using LW_2_12;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace LW_2_12Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestConstructor()
        {
            MyStack<int> st = new MyStack<int>();

            int expected = 0;
            int actual = st.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestConstructor2()
        {
            MyStack<int> st = new MyStack<int>(5);

            int expected = 5;
            int actual = st.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestConstructor3()
        {
            bool expected = true;
            bool actual = false; ;
            try
            {
                MyStack<int> st = new MyStack<int>(-5);
            }
            catch
            {
                actual = true;
            }
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPush()
        {
            bool expected = true;
            bool actual = false; ;
            try
            {
                MyStack<int> st = new MyStack<int>(-5);
            }
            catch
            {
                actual = true;
            }
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPush2()
        {
            MyStack<int> st = new MyStack<int>();
            int[] vs = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            st.Push(vs);

            int expected = 9;
            int actual = st.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGet()
        {
            MyStack<int> st = new MyStack<int>();
            int[] vs = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            st.Push(vs);

            int expected = 8;
            int actual = st.Get();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGet2()
        {
            bool expected = true;
            bool actual = false; ;
            try
            {
                MyStack<int> st = new MyStack<int>();
                st.Get();
            }
            catch
            {
                actual = true;
            }
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGet3()
        {
            MyStack<int> st = new MyStack<int>();

            Element<int> expected = null;
            Element<int> actual = st.GetAsElement();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestRemove()
        {
            MyStack<int> st = new MyStack<int>();
            int[] vs = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            st.Push(vs);
            st.Remove(5);

            int expected = 3;
            int actual = st.Get();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestRemove2()
        {
            bool expected = true;
            bool actual = false; ;
            try
            {
                MyStack<int> st = new MyStack<int>(5);
                st.Remove(10);
            }
            catch
            {
                actual = true;
            }
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestContains()
        {
            MyStack<int> st = new MyStack<int>();
            int[] vs = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            st.Push(vs);

            bool expected = true;
            bool actual = st.Contains(3);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestContains2()
        {
            MyStack<int> st = new MyStack<int>();
            int[] vs = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            st.Push(vs);

            bool expected = false;
            bool actual = st.Contains(32);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestContains3()
        {
            MyStack<int> st = new MyStack<int>();

            bool expected = false;
            bool actual = st.Contains(32);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestClone()
        {
            MyStack<int> st = new MyStack<int>();
            st.Push(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 });
            MyStack<int> st2 = st.Clone();

            bool expected = true;
            bool actual = object.Equals(st, st2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestShallowCopy()
        {
            MyStack<int> st = new MyStack<int>();
            MyStack<int> st2 = st.ShallowCopy();

            bool expected = true;
            bool actual = object.ReferenceEquals(st, st2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestShow()
        {
            MyStack<int> st = new MyStack<int>();
            st.Push(new int[] { 1, 2 });

            string expected = "2 1 ";
            string actual = st.Show();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestShow2()
        {
            MyStack<Organization> st = new MyStack<Organization>(2);

            string expected = "null null ";
            string actual = st.Show();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestShow3()
        {
            MyStack<int> st = new MyStack<int>();
            st.Push(new int[] { 1, 2, 3 });

            string expected = "3 2 1 ";
            string actual = st.Show();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestEnumerator()
        {
            MyStack<int> st = new MyStack<int>();
            st.Push(new int[] { 1, 2, 3 });

            foreach(var item in st)
            {
            }

            int actual = 0;

            foreach (var item in st)
            {
                actual++;
            }

            int expected = 3;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestEnumerator2()
        {
            MyStack<int> st = new MyStack<int>();

            int actual = st.GetEnumerator().Current;
            int expected = 0;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestEnumerator3()
        {
            MyStack<int> st = new MyStack<int>();

            IEnumerator actual = st.GetEnumerator();

            Assert.AreEqual(true, actual is MyEnumerator<int>);
        }

        [TestMethod]
        public void TestEquals()
        {
            MyStack<int> st = new MyStack<int>();
            st.Push(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 });
            MyStack<int> st2 = st.Clone();
            st2.Push(45);

            bool expected = false;
            bool actual = object.Equals(st, st2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestEquals2()
        {
            MyStack<int> st = new MyStack<int>(5);
            MyStack<string> st2 = new MyStack<string>(5);

            bool expected = false;
            bool actual = object.Equals(st, st2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestEquals3()
        {
            MyStack<int> st = new MyStack<int>(5);
            st.Push(3);
            st.Push(3);
            MyStack<int> st2 = new MyStack<int>(5);
            st2.Push(4);
            st2.Push(4);

            bool expected = false;
            bool actual = object.Equals(st, st2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestEquals4()
        {
            MyStack<int> st = new MyStack<int>(5);
            st.Push(3);
            MyStack<int> st2 = new MyStack<int>(5);
            st2.Push(4);

            bool expected = false;
            bool actual = object.Equals(st, st2);

            Assert.AreEqual(expected, actual);
        }
    }
}