using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using IEC77C_ADT_2022_23_1.Models;
using IEC77C_ADT_2022_23_1.Repository;
using IEC77C_ADT_2022_23_1.Logic;

namespace IEC77C_ADT_2022_23_1.Test
{
    class CityLogicTest
    {
        Mock<ICityRepository> cityrepoMock = new();
        Mock<IStoreRepository> storerepoMock = new();
        Mock<ICompanyRepository> companyrepoMock = new();

        CityLogic citylogic;

        [SetUp]
        public void TestSetup()
        {
            cityrepoMock.Setup(m => m.FindById(It.IsAny<int>())).Returns(new City());

            citylogic = new(cityrepoMock.Object, storerepoMock.Object, companyrepoMock.Object);

        }

        [Test]
        public void GetAllTest()
        {
            //SETUP
            cityrepoMock.Setup(m => m.GetAll()).Returns(new List<City> {
                new City { City_ID = 1 }
                 });

            //ACT
            citylogic.GetAll();

            //ASSERT
            cityrepoMock.Verify(m => m.GetAll(), Times.Once);
        }

        [Test]
        public void AddTest()
        {
            //ACT
            citylogic.Add(new City());

            //ASSERT
            cityrepoMock.Verify(m => m.Add(It.IsAny<City>()), Times.Once);
        }
        [Test]
        public void UpdateTest()
        {
            //ACT
            citylogic.Update(new City());

            //ASSERT
            cityrepoMock.Verify(m => m.Update(It.IsAny<City>()), Times.Once);
        }

        [Test]
        public void DeleteTest()
        {

            //ACT
            citylogic.Delete(new City());

            //ASSERT
            cityrepoMock.Verify(m => m.Delete(It.IsAny<City>()), Times.Once);

        }

        [Test]
        public void FindByIDTest()
        {
            //ACT
            citylogic.FindById(0);

            //ASSERT
            cityrepoMock.Verify(m => m.FindById(It.IsAny<int>()), Times.Once);
        }
    }
}
