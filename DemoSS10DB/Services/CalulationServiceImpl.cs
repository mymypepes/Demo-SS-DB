using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoSS10DB.Services
{
    public class CalulationServiceImpl : CalulationService
    {
        public double Add(double a, double b)
        {
            return a + b;
        }

        public double Mul(double a, double b)
        {
            return a * b;
        }
    }
}
