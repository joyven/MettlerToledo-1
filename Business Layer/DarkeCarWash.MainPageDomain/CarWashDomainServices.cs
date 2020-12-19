using DarkeCarWash.MainPageDomain.DomainModel;
using DarkeCarWash.MainPageDomain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkeCarWash.MainPageDomain
{
    public class CarWashDomainServices : ICarWashDomainServices
    {
        public bool CreateJob(CarWashDomainModel carWash)
        {
            try
            {
                //this can be extendted to Db layer and based on Db response this will chagned dynamically later part
                return true;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
