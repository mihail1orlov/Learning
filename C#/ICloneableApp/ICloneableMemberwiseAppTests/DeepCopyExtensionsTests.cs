using Microsoft.VisualStudio.TestTools.UnitTesting;

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

        private class TestObject
        {
            public string Name { get; set; }
            public int Value { get; set; }
            public TestObject Child { get; set; }
        }
    }
}