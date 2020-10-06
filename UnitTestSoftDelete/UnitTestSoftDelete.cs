using System;
using Canducci.SoftDelete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestSoftDelete.Models;

namespace UnitTestSoftDelete
{
    [TestClass]
    public class UnitTestSoftDelete
    {
        private ModelGenericChar ModelGenericChar { get; set; }
        private ModelGenericDateTime ModelGenericDateTime { get; set; }
        private ModelGenericBool ModelGenericBool { get; set; }

        private ModelChar ModelChar { get; set; }
        private ModelDateTime ModelDateTime { get; set; }
        private ModelBool ModelBool { get; set; }


        [TestInitialize]
        public void SetUp()
        {
            ModelGenericChar = new ModelGenericChar();
            ModelGenericDateTime = new ModelGenericDateTime();
            ModelGenericBool = new ModelGenericBool();

            ModelChar = new ModelChar();
            ModelDateTime = new ModelDateTime();
            ModelBool = new ModelBool();
        }

        [TestMethod]
        public void TestInterfaceGenericChar()
        {
            Assert.IsInstanceOfType(ModelGenericChar.GetType(), typeof(ISoftDelete<char>).GetType());
        }

        [TestMethod]
        public void TestInterfaceGenericBool()
        {
            Assert.IsInstanceOfType(ModelGenericBool.GetType(), typeof(ISoftDelete<bool>).GetType());
        }

        [TestMethod]
        public void TestInterfaceGenericDateTime()
        {
            Assert.IsInstanceOfType(ModelGenericDateTime.GetType(), typeof(ISoftDelete<DateTime?>).GetType());
        }


        [TestMethod]
        public void TestInterfaceGenericBoolValue()
        {
            Assert.AreEqual(ModelGenericBool.DeletedAt, default);
        }

        [TestMethod]
        public void TestInterfaceGenericDateTimeValue()
        {
            Assert.AreEqual(ModelGenericDateTime.DeletedAt, default);
        }

        [TestMethod]
        public void TestInterfaceGenericCharValue()
        {
            Assert.AreEqual(ModelGenericChar.DeletedAt, 'N');
        }


        [TestMethod]
        public void TestInterfaceChar()
        {
            Assert.IsInstanceOfType(ModelChar.GetType(), typeof(ISoftDeleteChar).GetType());
        }

        [TestMethod]
        public void TestInterfaceBool()
        {
            Assert.IsInstanceOfType(ModelBool.GetType(), typeof(ISoftDeleteBool).GetType());
        }

        [TestMethod]
        public void TestInterfaceDateTime()
        {
            Assert.IsInstanceOfType(ModelDateTime.GetType(), typeof(ISoftDeleteDateTime).GetType());
        }


        [TestMethod]
        public void TestInterfaceCharValue()
        {
            Assert.AreEqual(ModelChar.DeletedAt, 'N');
        }

        [TestMethod]
        public void TestInterfaceBoolValue()
        {
            Assert.AreEqual(ModelBool.DeletedAt, default);
        }

        [TestMethod]
        public void TestInterfaceDateTimeValue()
        {
            Assert.AreEqual(ModelDateTime.DeletedAt, default);
        }
    }
}
