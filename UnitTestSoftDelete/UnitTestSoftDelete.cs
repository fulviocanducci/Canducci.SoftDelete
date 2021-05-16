using Canducci.SoftDelete;
using Canducci.SoftDelete.Internals;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UnitTestSoftDelete.Models;

namespace UnitTestSoftDelete
{
    [TestClass]
    public class UnitTestSoftDelete
    {

        private EntriesSoftDeleteBool EntriesSoftDeleteBool { get; set; }
        private EntriesSoftDeleteChar EntriesSoftDeleteChar { get; set; }
        private EntriesSoftDeleteDateTime EntriesSoftDeleteDateTime { get; set; }

        private ModelEntriesGenericChar ModelEntriesGenericChar { get; set; }
        private ModelEntriesGenericBool ModelEntriesGenericBool { get; set; }
        private ModelEntriesGenericDateTime ModelEntriesGenericDateTime { get; set; }

        private ModelGenericChar ModelGenericChar { get; set; }
        private ModelGenericDateTime ModelGenericDateTime { get; set; }
        private ModelGenericBool ModelGenericBool { get; set; }

        private ModelChar ModelChar { get; set; }
        private ModelDateTime ModelDateTime { get; set; }
        private ModelBool ModelBool { get; set; }


        [TestInitialize]
        public void SetUp()
        {
            EntriesSoftDeleteBool = new EntriesSoftDeleteBool();
            EntriesSoftDeleteChar = new EntriesSoftDeleteChar();
            EntriesSoftDeleteDateTime = new EntriesSoftDeleteDateTime();

            ModelEntriesGenericChar = new ModelEntriesGenericChar();
            ModelEntriesGenericBool = new ModelEntriesGenericBool();
            ModelEntriesGenericDateTime = new ModelEntriesGenericDateTime();


            ModelGenericChar = new ModelGenericChar();
            ModelGenericDateTime = new ModelGenericDateTime();
            ModelGenericBool = new ModelGenericBool();

            ModelChar = new ModelChar();
            ModelDateTime = new ModelDateTime();
            ModelBool = new ModelBool();
        }

        [TestMethod]
        public void TestInterfaceEntriesGenericChar()
        {
            Assert.IsInstanceOfType(EntriesSoftDeleteChar, typeof(Entries<ISoftDeleteChar>));
        }

        [TestMethod]
        public void TestInterfaceEntriesGenericBool()
        {
            Assert.IsInstanceOfType(EntriesSoftDeleteBool, typeof(Entries<ISoftDeleteBool>));
        }

        [TestMethod]
        public void TestInterfaceEntriesGenericDateTime()
        {
            Assert.IsInstanceOfType(EntriesSoftDeleteDateTime, typeof(Entries<ISoftDeleteDateTime>));
        }

        [TestMethod]
        public void TestInterfaceModelEntriesGenericChar()
        {
            Assert.IsInstanceOfType(ModelEntriesGenericChar, typeof(Entries<ISoftDeleteChar>));
        }

        [TestMethod]
        public void TestInterfaceModelEntriesGenericBool()
        {
            Assert.IsInstanceOfType(ModelEntriesGenericBool, typeof(Entries<ISoftDeleteBool>));
        }

        [TestMethod]
        public void TestInterfaceModelEntriesGenericDateTime()
        {
            Assert.IsInstanceOfType(ModelEntriesGenericDateTime, typeof(Entries<ISoftDeleteDateTime>));
        }

        [TestMethod]
        public void TestInterfaceGenericChar()
        {
            Assert.IsInstanceOfType(ModelGenericChar.Id, typeof(Guid));
            Assert.IsInstanceOfType(ModelGenericChar, typeof(ISoftDelete<char>));
        }

        [TestMethod]
        public void TestInterfaceGenericBool()
        {
            Assert.IsInstanceOfType(ModelGenericBool.Id, typeof(Guid));
            Assert.IsInstanceOfType(ModelGenericBool, typeof(ISoftDelete<bool>));
        }

        [TestMethod]
        public void TestInterfaceGenericDateTime()
        {
            Assert.IsInstanceOfType(ModelGenericDateTime.Id, typeof(Guid));
            Assert.IsInstanceOfType(ModelGenericDateTime, typeof(ISoftDelete<DateTime?>));
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
            Assert.IsInstanceOfType(ModelChar, typeof(ISoftDeleteChar));
        }

        [TestMethod]
        public void TestInterfaceBool()
        {
            Assert.IsInstanceOfType(ModelBool, typeof(ISoftDeleteBool));
        }

        [TestMethod]
        public void TestInterfaceDateTime()
        {
            Assert.IsInstanceOfType(ModelDateTime.Id, typeof(System.Guid));
            Assert.IsInstanceOfType(ModelDateTime, typeof(ISoftDeleteDateTime));
        }

        [TestMethod]
        public void TestInterfaceCharValue()
        {
            Assert.IsInstanceOfType(ModelChar.Id, typeof(System.Guid));
            Assert.AreEqual(ModelChar.DeletedAt, 'N');
        }

        [TestMethod]
        public void TestInterfaceBoolValue()
        {
            Assert.IsInstanceOfType(ModelBool.Id, typeof(System.Guid));
            Assert.AreEqual(ModelBool.DeletedAt, default);
        }

        [TestMethod]
        public void TestInterfaceDateTimeValue()
        {
            Assert.IsInstanceOfType(ModelDateTime.Id, typeof(System.Guid));
            Assert.AreEqual(ModelDateTime.DeletedAt, default);
        }
    }
}
