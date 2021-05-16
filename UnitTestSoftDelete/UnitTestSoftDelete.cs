using Canducci.SoftDelete;
using Canducci.SoftDelete.Internals;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UnitTestSoftDelete.Models;
using Canducci.SoftDelete.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Canducci.SoftDelete.Interceptors;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using UnitTestSoftDelete.Service;
using System.Threading.Tasks;

namespace UnitTestSoftDelete
{
    [TestClass]
    public class UnitTestSoftDelete
    {
        private Db Db { get; set; }
        private DbContextOptionsBuilder Builder { get; set; }
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

            Builder = new DbContextOptionsBuilder();

            Db = new Db();
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

        [TestMethod]
        public void TestMethodAddInterceptorSoftDeleteExtension()
        {            
            AddInterceptorMethodsExtensions.AddInterceptorSoftDeleteDateTime(Builder);
            AddInterceptorMethodsExtensions.AddInterceptorSoftDeleteBool(Builder);
            AddInterceptorMethodsExtensions.AddInterceptorSoftDeleteChar(Builder);
            var interceptors = Builder
                .Options
                .Extensions
                .ToList()
                .Select(x => (CoreOptionsExtension)x)
                .Select(x => x.Interceptors)                
                .FirstOrDefault();
            bool intSoftDateTime = interceptors.Where(x => x.GetType() == typeof(SoftDeleteDateTimeSaveChangesInterceptor)).Any();
            bool intSoftBool = interceptors.Where(x => x.GetType() == typeof(SoftDeleteBoolSaveChangesInterceptor)).Any();
            bool intSoftChar = interceptors.Where(x => x.GetType() == typeof(SoftDeleteCharSaveChangesInterceptor)).Any();
            Assert.IsTrue(intSoftDateTime);
            Assert.IsTrue(intSoftBool);
            Assert.IsTrue(intSoftChar);
        }

        [TestMethod]
        public void TestMethodAddInterceptorSoftDeleteExtensionInstanceOf()
        {
            SoftDeleteDateTimeSaveChangesInterceptor a = new SoftDeleteDateTimeSaveChangesInterceptor();
            SoftDeleteBoolSaveChangesInterceptor b = new SoftDeleteBoolSaveChangesInterceptor();
            SoftDeleteCharSaveChangesInterceptor c = new SoftDeleteCharSaveChangesInterceptor();

            Assert.IsInstanceOfType(a, typeof(SaveChangesInterceptor));
            Assert.IsInstanceOfType(b, typeof(SaveChangesInterceptor));
            Assert.IsInstanceOfType(c, typeof(SaveChangesInterceptor));
        }

        [TestMethod]
        public void TestEntries()
        {
            ModelEntriesGenericBool modelEntriesGenericBool = new ModelEntriesGenericBool();
            ModelEntriesGenericChar modelEntriesGenericChar = new ModelEntriesGenericChar();
            ModelEntriesGenericDateTime ModelEntriesGenericDateTime = new ModelEntriesGenericDateTime();
            
            Assert.IsInstanceOfType(modelEntriesGenericBool, typeof(Entries<ISoftDeleteBool>));
            Assert.IsInstanceOfType(modelEntriesGenericChar, typeof(Entries<ISoftDeleteChar>));
            Assert.IsInstanceOfType(ModelEntriesGenericDateTime, typeof(Entries<ISoftDeleteDateTime>));
        }

        //[TestMethod]
        //public void Test1()
        //{
        //    EntityTypeBuilder<ModelBool> entityTypeBuilder = new(IMutableEntityType);
        //    HasQueryFilterExtensions.HasQueryFilterSoftDeleteBool(entityTypeBuilder);
        //}

        [TestMethod]
        public async Task TestDbContextInMemory()
        {
            ModelBool modelBool = new();
            ModelChar modelChar = new();
            ModelDateTime modelDateTime = new();

            Db.Add(modelBool);
            Db.Add(modelChar);
            Db.Add(modelDateTime);

            Db.SaveChanges();

            Assert.AreNotEqual(modelBool.Id, Guid.Empty);
            Assert.AreNotEqual(modelChar.Id, Guid.Empty);
            Assert.AreNotEqual(modelDateTime.Id, Guid.Empty);
            Assert.AreEqual(modelBool.DeletedAt, false);
            Assert.AreEqual(modelChar.DeletedAt, char.Parse("N"));
            Assert.AreEqual(modelDateTime.DeletedAt, null);

            Db.ModelBools.Remove(modelBool);
            Db.ModelChars.Remove(modelChar);
            Db.ModelDateTimes.Remove(modelDateTime);

            await Db.SaveChangesAsync();

            Assert.AreNotEqual(modelBool.DeletedAt, false);
            Assert.AreNotEqual(modelChar.DeletedAt, char.Parse("N"));
            Assert.AreNotEqual(modelDateTime.DeletedAt, null);

        }
    }
}
