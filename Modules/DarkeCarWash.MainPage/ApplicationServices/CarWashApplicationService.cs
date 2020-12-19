using DarkeCarWash.MainPage.Model;
using DarkeCarWash.MainPageDomain.DomainModel;
using DarkeCarWash.MainPageDomain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkeCarWash.MainPage.ApplicationServices
{
    public class CarWashApplicationService : ICarWashApplicationService
    {
        private readonly ICarWashDomainServices _carWashDomain;

        public CarWashApplicationService(ICarWashDomainServices carWashDomain)
        {
            _carWashDomain = carWashDomain;
        }
        public bool CreateJob(CarWashClientModel carWash)
        {
            try
            {
                var result = _carWashDomain.CreateJob(ConvertToDomain(carWash));
                return result;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        private CarWashDomainModel ConvertToDomain(CarWashClientModel carWash)
        {
            return new CarWashDomainModel
            {
                IsDryAgent = carWash.IsDryAgent,
                IsPreSoak = carWash.IsPreSoak,
                IsRainShield = carWash.IsRainShield,
                IsSoftWater = carWash.IsSoftWater,
                IsTyreShine = carWash.IsTyreShine,
                TotCost = carWash.TotCost,
                WashMode = carWash.WashMode
            };
        }
    }
}
