using NUnit.Framework;
using Moq;
using IEC77C_ADT_2022_23_1.Logic;
using IEC77C_ADT_2022_23_1.Repository;
using IEC77C_ADT_2022_23_1.Models;
using System.Collections.Generic;
using System;

namespace IEC77C_ADT_2022_23_1.Test
{
    [TestFixture]
    public class StoreLogicTest
    {
        Mock<IStoreRepository> storerepoMock = new();
        StoreLogic storelogic;

        [SetUp]
        public void TestSetup_and_mock()
        {
            //Setup of mock object
            
            storerepoMock.Setup(m => m.FindById(It.IsAny<int>())).Returns(new Store());

            //Initialization of logic to be tested
            storelogic = new StoreLogic(storerepoMock.Object);

        }
        [Test]
        public void GetAllTest()
        {
            //SETUP
            storerepoMock.Setup(m => m.GetAll()).Returns(new List<Store> {
                new Store { Company_ID = 1 } });

            //ACT
            storelogic.GetAll();

            //ASSERT
            storerepoMock.Verify(m => m.GetAll(), Times.Once);
        }

        [Test]
        public void AddTest()
        {
            //ACT
            storelogic.Add(new Store());

            //ASSERT
            storerepoMock.Verify(m => m.Add(It.IsAny<Store>()), Times.Once);
        }
        [Test]
        public void UpdateTest()
        {
            //ACT
            storelogic.Update(new Store());

            //ASSERT
            storerepoMock.Verify(m => m.Update(It.IsAny<Store>()), Times.Once);
        }

        [Test]
        public void DeleteTest()
        {

            //ACT
            storelogic.Delete(new Store());

            //ASSERT
            storerepoMock.Verify(m => m.Delete(It.IsAny<Store>()), Times.Once);

        }

        [Test]
        public void FindByIDTest()
        {
            //ACT
            storelogic.FindById(0);

            //ASSERT
            storerepoMock.Verify(m => m.FindById(It.IsAny<int>()), Times.Once);
        }
        [Test]
        public void TotalSizeCorrectReturnValueTest()
        {
            //SETUP
            int size1 = 10;
            int size2 = 30;
            int NotUsedSize = 20; //Size for a different ID store
            storerepoMock.Setup(m => m.GetAll()).Returns(new List<Store> { 
                new Store { Company_ID = 1, Size = NotUsedSize }, 
                new Store { Company_ID = 0, Size = size1 }, 
                new Store { Company_ID = 0, Size = size2 } 
            });
            //GetAll returns a store list with sizes size1 and size2
            List<Store> mockgetall = (List<Store>)storelogic.GetAll();
            //ASSERT
            Assert.IsTrue(storelogic.TotalSize(0).Equals(size1 + size2));

        }


    }
}
