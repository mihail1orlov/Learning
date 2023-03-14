using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;

namespace ICloneableMemberwiseAppTests
{
    [TestClass]
    public partial class DeepCloneTests
    {
        [TestMethod]
        public void DeepClone_Null_ReturnsDefault()
        {
            object obj = null;
            var cloned = obj.DeepClone();
            Assert.AreEqual(default(object), cloned);
        }

        [TestMethod]
        public void DeepClone_ValueType_ReturnsClonedValue()
        {
            int value = 42;
            var cloned = value.DeepClone();
            Assert.AreEqual(value, cloned);
        }

        [TestMethod]
        public void DeepClone_String_ReturnsClonedString()
        {
            string value = "hello";
            var cloned = value.DeepClone();
            Assert.AreEqual(value, cloned);
        }

        [TestMethod]
        public void DeepClone_Array_ReturnsClonedArray()
        {
            int[] array = { 1, 2, 3 };
            var cloned = array.DeepClone();
            Assert.AreNotSame(array, cloned);
            CollectionAssert.AreEqual(array, cloned);
        }

        [TestMethod]
        public void DeepClone_TwoArrayRank_ReturnsClonedArray()
        {
            var array = new double[,]
            {
                { 6.1230317691118863E-17, 1.0, 0.0 },
                { -1.0, 6.1230317691118863E-17, 0.0 },
                { 0.0, 0.0, 7.0 }
            };

            var cloned = array.DeepClone();
            Assert.AreNotSame(array, cloned);
            CollectionAssert.AreEqual(array, cloned);
        }

        [TestMethod]
        public void DeepClone_TwoDimentionalArray_ReturnsClonedArray()
        {
            var array = new double[][]
            {
                new double[] { 6.1230317691118863E-17, 1.0, 0.0 },
                new double[] { -1.0, 6.1230317691118863E-17, 0.0 },
                new double[] { 0.0, 0.0, 7.0 }
            };

            var cloned = array.DeepClone();
            Assert.AreNotSame(array, cloned);
            for (int i = 0; i < array.Length; i++)
            {
                CollectionAssert.AreEqual(array[i], cloned[i]);
            }
        }

        [TestMethod]
        public void DeepClone_Object_ReturnsClonedObject()
        {
            var obj = new TestObject
            {
                Name = "test",
                Value = 42,
                Child = new TestObject
                {
                    Name = "child",
                    Value = 24
                }
            };

            var cloned = obj.DeepClone();

            Assert.AreNotSame(obj, cloned);
            Assert.AreEqual(obj.Name, cloned.Name);
            Assert.AreEqual(obj.Value, cloned.Value);
            Assert.AreNotSame(obj.Child, cloned.Child);
            Assert.AreEqual(obj.Child.Name, cloned.Child.Name);
            Assert.AreEqual(obj.Child.Value, cloned.Child.Value);
        }

        [TestMethod]
        public void DeepClone_ICloneableObject_ReturnsClonedObject()
        {
            // arrange
            var expectation = new TestCloneableObject();

            // action
            var actual = expectation.DeepClone();

            // assert
            Assert.AreNotSame(expectation, actual);
            Assert.AreEqual("TestName_222", actual.Name);
            Assert.AreEqual(2222, actual.Value);
            Assert.AreNotSame(expectation.Child, actual.Child);
            Assert.AreEqual("TestName_222", actual.Child.Name);
            Assert.AreEqual(22, actual.Child.Value);
        }


        private class TestObject
        {
            public string Name { get; set; }
            public int Value { get; set; }
            public TestObject Child { get; set; }
        }

        private class TestCloneableObject : ICloneable
        {
            public string Name { get; private set; } = "Name_111";
            public int Value { get; private set; } = 1111;
            public TestObject Child { get; private set; } = new TestObject { Name = "TestName_111", Value = 11 };

            public object Clone()
            {
                return (TestCloneableObject)new TestCloneableObject { Name = "TestName_222", Value = 2222, Child = new TestObject { Name = "TestName_222", Value = 22 } };
            }
        }
    }
}