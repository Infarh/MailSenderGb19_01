using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionTestLib
{
    internal class Calculator
    {
        private double Sum(double x, double y) => x + y;

        private double Substract(double x, double y) => x - y;

        private double Multiply(double x, double y) => x * y;

        private double Divade(double x, double y) => x / y;
    }
}
