using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnQPayWithFun.Contracts.Persistence.App;
using System;
using System.Threading.Tasks;

namespace SnQPayWithFun.LogicUnitTest
{
	[TestClass]
	public class BookUnitTest
	{
        private static SnQPayWithFun.Contracts.Client.IControllerAccess<IBook> CreateController()
        {
            return SnQPayWithFun.Logic.Factory.Create<IBook>();
        }
        private static async void DeleteAllBooksAsync()
        {
            using var ctrl = CreateController();

            foreach (var item in await ctrl.GetAllAsync())
            {
                await ctrl.DeleteAsync(item.Id);
            }

            await ctrl.SaveChangesAsync();
        }

        [ClassInitialize]
        public static void ClassInitialize(TestContext testcontent)
        {
            DeleteAllBooksAsync();

        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            DeleteAllBooksAsync();
        }

        [TestInitialize]
        public void InitDatabase()
        {

        }

        [TestCleanup]
        public void Cleanup()
        {

        }

        [TestMethod]
        public void Create_NoneRequirments_Result()
        {
            Task.Run(async () =>
            {
                using var ctrl = CreateController();

                var entity = await ctrl.CreateAsync();

                Assert.IsNotNull(entity);
            }).Wait();
        }

        [TestMethod]
        public void Insert_WithValidISBN_ResultPersistenceEntity()
        {
            IBook expected = null;
            string expectedISBN = null;

            Task.Run(async () =>
            {
                using var ctrl = CreateController();
                var entity = await ctrl.CreateAsync();

                expectedISBN = "0471190470";
                entity.ISBNNumber = expectedISBN;
                expected = await ctrl.InsertAsync(entity);
                await ctrl.SaveChangesAsync();
            }).Wait();

            Assert.IsNotNull(expected);
            Assert.AreNotEqual(0, expected.Id);
            Assert.AreEqual(expected.ISBNNumber, expectedISBN);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task Insert_WithInvalidISBN_ResultPersistenceEntity()
        {
            IBook expected = null;
            string expectedISBN = null;

            using var ctrl = CreateController();
            var entity = await ctrl.CreateAsync();

            expectedISBN = "0471290470";
            entity.ISBNNumber = expectedISBN;
            expected = await ctrl.InsertAsync(entity);
            await ctrl.SaveChangesAsync();


        }

        [TestMethod]
        public void Edit_ValidChange_ResultPersistenceEntity()
        {
            IBook expected = null;
            IBook expectedISBN = null;
            string insertedISBN = null;
            IBook getByIdItem = null;

            Task.Run(async () =>
            {
                using var ctrl = CreateController();
                var entity = await ctrl.CreateAsync();

                insertedISBN = "0471190470";
                entity.ISBNNumber = insertedISBN;
                var inserted = await ctrl.InsertAsync(entity);
                await ctrl.SaveChangesAsync();


                getByIdItem = await ctrl.GetByIdAsync(inserted.Id);
                
                if(getByIdItem != null)
                {
                    string newISBN = "2231694166";
                    getByIdItem.ISBNNumber = newISBN;
                    await ctrl.UpdateAsync(getByIdItem);
                    await ctrl.SaveChangesAsync();
                }

                expectedISBN = await ctrl.GetByIdAsync(getByIdItem.Id);

            }).Wait();

            Assert.IsNotNull(expectedISBN);
            Assert.AreNotEqual(0, expectedISBN.Id);
            Assert.AreNotEqual(expectedISBN.ISBNNumber, insertedISBN);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task Edit_InvalidChange_ResultPersistenceEntity()
        {
            IBook expected = null;
            IBook expectedISBN = null;
            string insertedISBN = null;
            IBook getByIdItem = null;


            using var ctrl = CreateController();
            var entity = await ctrl.CreateAsync();

            insertedISBN = "0471190470";
            entity.ISBNNumber = insertedISBN;
            var inserted = await ctrl.InsertAsync(entity);
            await ctrl.SaveChangesAsync();


            getByIdItem = await ctrl.GetByIdAsync(inserted.Id);

            if (getByIdItem != null)
            {
                string newISBN = "1231694166";
                getByIdItem.ISBNNumber = newISBN;
                await ctrl.UpdateAsync(getByIdItem);
                await ctrl.SaveChangesAsync();
            }

            expectedISBN = await ctrl.GetByIdAsync(getByIdItem.Id);
        }
    }
}
