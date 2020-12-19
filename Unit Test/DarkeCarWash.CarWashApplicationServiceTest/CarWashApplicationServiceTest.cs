using DarkeCarWash.Core.Enums;
using DarkeCarWash.MainPage.ApplicationServices;
using DarkeCarWash.MainPage.Model;
using DarkeCarWash.MainPageDomain.DomainModel;
using DarkeCarWash.MainPageDomain.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System;

namespace DarkeCarWash.CarWashApplicationServiceTest
{
    [TestClass]
    public class CarWashApplicationServiceTest
    {
        ICarWashDomainServices _carWashDomain;
        ICarWashApplicationService _applicationService;

        CarWashClientModel signature = null;
        CarWashDomainModel express = null;

        [TestInitialize]
        public void Test_Initialize()
        {
            _carWashDomain = MockRepository.GenerateMock<ICarWashDomainServices>();

            _applicationService = new CarWashApplicationService(_carWashDomain);
            MockValues();
        }

        private void MockValues()
        {
            signature = new CarWashClientModel()
            {
                IsPreSoak = true,
                IsSoftWater = true,
                IsDryAgent = true,
                IsTyreShine = true,
                IsRainShield = true,
                WashMode = WashMode.Signature,
                TotCost = 9,
            };

            express = new CarWashDomainModel()
            {
                IsPreSoak = true,
                IsSoftWater = true,
                IsDryAgent = true,
                IsTyreShine = false,
                IsRainShield = false,
                WashMode = WashMode.Express,
                TotCost = 3,
            };
        }

        [TestMethod]
        public void CreateJobTest()
        {
            _carWashDomain.Stub(x => x.CreateJob(express)).Return(true);
            bool actualResult = _applicationService.CreateJob(signature);

            Assert.AreEqual(actualResult, true);
        }

        [TestMethod]
        public void CreateJobTest_False()
        {
            _carWashDomain.Stub(x => x.CreateJob(express)).Return(false);
            bool actualResult = _applicationService.CreateJob(signature);

            Assert.AreEqual(actualResult, false);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateJobTest_Negative()
        {
            _carWashDomain.Stub(x => x.CreateJob(express)).Throw(new Exception());
            bool actualResult = _applicationService.CreateJob(signature);
        }
    }
}
