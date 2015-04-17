using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NYU
{
    /// <summary>
    /// .net homework part 2 c#
    /// </summary>

    public enum SizeClass
    {
        Minicompact, Subcompact, Compact, Midsize, Large
    }
    /// <summary>
    /// use enumeration to describe car size 
    /// </summary>

    public class CarMakeModel
    {
        //Properties
        public String MakeName { get; set; }
        public String ModelName { get; set; }
        public int Year { get; set; }
        public SizeClass Class { get; set; }
        public double Height { get; set; }
        public double Length { get; set; }

        //Constructor
        public CarMakeModel() { }

        public CarMakeModel(String makeN, String modelN, int year, SizeClass size, double height, double length)
        {
            MakeName = makeN;
            ModelName = modelN;
            Year = year;
            Class = size;
            Height = height;
            Length = length;

        }
    }


}
