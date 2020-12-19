using DarkeCarWash.MainPageDomain.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkeCarWash.MainPageDomain.Interfaces
{
    public interface ICarWashDomainServices
    {
        bool CreateJob(CarWashDomainModel carWash);
    }
}
