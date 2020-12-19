using DarkeCarWash.MainPage.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkeCarWash.MainPage.ApplicationServices
{
    public interface ICarWashApplicationService
    {
        bool CreateJob(CarWashClientModel carWash);
    }
}
