using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NYU
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Tire> myTire = new List<Tire>();
            Tire ta = new Tire("RedFlag") { ModelName = "Victory", Diameter = 80 };
            Tire tb = new Tire { ManufacturerName = "LandRover", ModelName = "Land", Diameter = 100 };
            myTire.Add(ta);
            myTire.Add(tb);

            foreach (Tire t in myTire)
                t.DashBoard();

            CarInstance myCar = new CarInstance("John", "Doe", CarColor.Black, true, myTire, 100, 120);
            myCar.DashBoard();
            myCar.accelerate(20);
            myCar.turnLeft(180);
            myCar.brake(70);
            myCar.turnRight(20);
            Console.WriteLine();
        }
    }
}
