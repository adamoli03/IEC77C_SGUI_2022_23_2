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
        Mock<IStoreRepository> storerepoMock = new();
        Mock<ICityRepository> cityrepoMock = new();
        Mock<ICompanyRepository> companyrepoMock = new();
        CityLogic citylogic;

        [OneTimeSetUp]
        public void TestSetup()
        {
            cityrepoMock.Setup(m => m.FindById(It.IsAny<int>())).Returns(new City());
            cityrepoMock.Setup(m => m.Add(It.Is<City>(x => x.City_Name == null)))
                            .Throws<ArgumentNullException>();

            citylogic = new(cityrepoMock.Object, storerepoMock.Object, companyrepoMock.Object);
            
            cityrepoMock.Setup(m => m.GetAll()).Returns(new List<City> {
                new City {City_ID = 0, City_Name = "testedcity", Country = "country1" },
                new City {City_ID = 1, City_Name = "invalidcity", Country = "country2" } });

            storerepoMock.Setup(m => m.GetAll()).Returns(new List<Store>
            {
                new Store { Store_ID = 0, City_ID = 0, Company_ID = 0},
                new Store { Store_ID = 1, City_ID = 0, Company_ID = 0},
                new Store { Store_ID = 2, City_ID = 1, Company_ID = 0},
                new Store { Store_ID = 3, City_ID = 0, Company_ID = 1},
                new Store { Store_ID = 4, City_ID = 1, Company_ID = 1},
                new Store { Store_ID = 5, City_ID = 1, Company_ID = 1}
            });

            companyrepoMock.Setup(m => m.GetAll()).Returns(new List<Company>
            {
                new Company { Company_ID = 0, Name = "ValidTest"},
                new Company { Company_ID = 1, Name = "InvalidTest"}
            });
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
            citylogic.Add(new City {City_Name = "test" });

            //ASSERT
            cityrepoMock.Verify(m => m.Add(It.IsAny<City>()), Times.Once);
        }
        [Test]
        public void AddThrows()
        {
            Assert.Throws<ArgumentNullException>(() => citylogic.Add(new City()));
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

        [Test]
        public void MostStores_ThrowsIndexOutOfRange()
        {
            Assert.Throws<IndexOutOfRangeException>(() => citylogic.MostStores(3.15));
        }
        [Test]
        public void MostStores_ThrowsInvalidOperationException()
        {
            //Setup

            Assert.Throws<InvalidOperationException>(() => citylogic.MostStores("asd"));
        }
        [Test]
        public void MostStores_StringInputValidityTest()
        {
            
            //Tests for string and int inputs as well
            Assert.That(citylogic.MostStores("testedcity").Equals("ValidTest"));
            
        }
        [Test]
        public void MostStores_IntInputValidityTest()
        {
            Assert.That(citylogic.MostStores(0).Equals("ValidTest"));
        }
        [Test]
        public void ListCountriestEST()
        {
            List<string> test = citylogic.ListCountries();
            List<string> expected = new List<string> { "country1", "country2" };
            CollectionAssert.AreEquivalent(expected, test);
        }


        
    }
}
