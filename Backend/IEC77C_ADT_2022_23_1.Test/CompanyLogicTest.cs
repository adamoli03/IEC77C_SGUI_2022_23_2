using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using IEC77C_ADT_2022_23_1.Repository;
using IEC77C_ADT_2022_23_1.Logic;
using IEC77C_ADT_2022_23_1.Models;

namespace IEC77C_ADT_2022_23_1.Test
{
    [TestFixture]
    public class CompanyLogicTest
    {
        Mock<ICompanyRepository> companyrepoMock = new();
        Mock<IStoreRepository> storerepoMock = new();

        CompanyLogic companyLogic;

        [SetUp]
        public void TestSetup()
        {
            companyrepoMock.Setup(m => m.FindById(It.IsAny<int>())).Returns(new Company());

            companyLogic = new(companyrepoMock.Object, storerepoMock.Object);
        }


        [Test]
        public void GetAllTest()
        {
            //SETUP
            companyrepoMock.Setup(m => m.GetAll()).Returns(new List<Company> {
                new Company { Company_ID = 1 },
                new Company { Company_ID = 2 } });

            //ACT
            companyLogic.GetAll();

            //ASSERT
            companyrepoMock.Verify(m => m.GetAll(), Times.Once);
        }

        [Test]
        public void AddTest()
        {
            //ACT
            companyLogic.Add(new Company());

            //ASSERT
            companyrepoMock.Verify(m => m.Add(It.IsAny<Company>()), Times.Once);
        }
        [Test]
        public void UpdateTest()
        {
            //ACT
            companyLogic.Update(new Company());

            //ASSERT
            companyrepoMock.Verify(m => m.Update(It.IsAny<Company>()), Times.Once);
        }

        [Test]
        public void DeleteTest()
        {

            //ACT
            companyLogic.Delete(new Company());

            //ASSERT
            companyrepoMock.Verify(m => m.Delete(It.IsAny<Company>()), Times.Once);

        }

        [Test]
        public void FindByIDTest()
        {
            //ACT
            companyLogic.FindById(0);

            //ASSERT
            companyrepoMock.Verify(m => m.FindById(It.IsAny<int>()), Times.Once);
        }
    }
}
