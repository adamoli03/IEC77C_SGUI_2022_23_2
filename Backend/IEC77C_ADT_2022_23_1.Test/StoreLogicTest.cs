using NUnit.Framework;
using Moq;
using IEC77C_ADT_2022_23_1.Logic;
using IEC77C_ADT_2022_23_1.Repository;
using IEC77C_ADT_2022_23_1.Models;
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
            storerepoMock.Setup(m => m.Add(It.IsAny<Store>()));
            storerepoMock.Setup(m => m.FindById(It.IsAny<int>())).Returns(new Store());

            //Initialization of logic to be tested
            storelogic = new StoreLogic(storerepoMock.Object);

        }
        

        [Test]
        public void TestAdd()
        {
            //ACT
            storelogic.Add(new Store());

            //ASSERT
            storerepoMock.Verify(m => m.Add(new Store()), Times.Once);

        }


    }
}
