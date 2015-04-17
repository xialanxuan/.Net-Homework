using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NYU
{
    public class Tire
    {
        //Properties
        public String ManufacturerName { set; get; }
        public String ModelName { set; get; }
        public double Diameter { set; get; }


        //Constructor
        public Tire() { }
        public Tire(string mn)
        {
            ManufacturerName = mn;
        }

        //Method
        /// <summary>
        /// Show all the information
        /// </summary>
        public void DashBoard() {
            Console.WriteLine("The information about the tire: ");
            Console.WriteLine("The manufacturer name is {0}", ManufacturerName);
            Console.WriteLine("The model name  is {0}", ModelName);
            Console.WriteLine("The diameter  is {0}", Diameter);
            Console.WriteLine();
        }
    }
}
