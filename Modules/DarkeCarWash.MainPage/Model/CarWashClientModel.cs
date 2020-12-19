using DarkeCarWash.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkeCarWash.MainPage.Model
{
    public class CarWashClientModel
    {
        public bool IsPreSoak { get; set; }
        public bool IsSoftWater { get; set; }
        public bool IsDryAgent { get; set; }
        public bool IsTyreShine { get; set; }
        public bool IsRainShield { get; set; }
        public WashMode WashMode { get; set; }
        public int TotCost { get; set; }
    }
}
