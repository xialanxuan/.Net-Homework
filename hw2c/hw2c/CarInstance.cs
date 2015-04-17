using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NYU
{
    public enum CarColor { 
    Red, Blue, Green, White, Black
    }

    /// <summary>
    /// The car instance
    /// </summary>
    public class CarInstance : CarMakeModel
    {
        //Field
        private string ownerFirstName;
        private string ownerLastName;
        private CarColor color;
        private bool isRegistered;
        private IEnumerable<Tire> tires;
        private double speed;
        private double heading;
        public const int speedLimit = 200;
        private double speedChange;
        private double headingChange;

        //Delegates
        public delegate void CarState();
        public event CarState BrakeLight;
        public event CarState NoLongerRegistered;
        public event CarState OutOfControl;
        public event CarState MaxSpeed;

        //Events
        private void brakeLight() {
            Console.WriteLine("Brake light is on");
        }

        private void noLongerRegistered() {
            Console.WriteLine("The car is no longer registered");
        }

        private void outOfControl() {
            Console.WriteLine("The car is out of control");
        }

        private void maxSpeed() {
            Console.WriteLine("You have reached the maximum speed {0}", speedLimit);
        }



        //Properties
        /// <summary>
        /// Owner`s first name, cannot be more than 15 characters
        /// </summary>
        public string OwnerFirstName{
            get { return ownerFirstName; }
            set {
                if (value.Length > 15)
                {
                    Console.WriteLine("The maximum length of First Name is 15");
                }
                else ownerFirstName = value;
            }
        }

        /// <summary>
        /// Owner`s last name, cannot be more than 20 characters
        /// </summary>
        public string OwnerLastName{
            get { return ownerLastName; }
            set
            {
                if (value.Length > 20)
                {
                    Console.WriteLine("The maximum length of Last Name is 20");
                }
                else ownerLastName = value;
            }
        }

        public CarColor Color{
            get { return color; }
            set { color = value; }
        }

        public bool IsRegistered{
            get { return isRegistered; }
            set
            {
                isRegistered = value;
                if (value == false && NoLongerRegistered != null)
                    NoLongerRegistered();
            }
        }

        /// <summary>
        /// Tire
        /// </summary>
        public IEnumerable<Tire> Tires{
            get { return tires; }
            set { tires = value; }
        }

        /// <summary>
        /// Speed, maximum 200 mph
        /// </summary>
        public double Speed {
            get { return speed; }
            set {
                if (value > speedLimit){
                    speed = speedLimit;
                    if (MaxSpeed != null)
                        MaxSpeed();
                }
                else speed = value;
            }
        }

        /// <summary>
        /// Heading from 0 to 360
        /// </summary>
        public double Heading {
            get { return heading; }
            set {
                heading = value % 360;
            }
        }




        //Methods
        /// <summary>
        /// DashBoard, show all the information
        /// </summary>
        public void DashBoard(){
            Console.WriteLine("Hello {0} {1}", OwnerFirstName, OwnerLastName);
            Console.WriteLine("I`m a {0} car", Color);
            if (IsRegistered)
                Console.WriteLine("I`m registered");
            else Console.WriteLine("I'm not registered");
            Console.WriteLine("My speed is {0} MPH and heading {1} degree", Speed, Heading);

        }

        /// <summary>
        /// Turn left
        /// </summary>
        /// <param name="degree"></param>
        public void turnLeft(int degree) {
            if (degree >= 360) {
                Console.WriteLine("Turning is large than 360, no heading change");
                return;
            }
            if (degree < 0) {
                Console.WriteLine("Turning is less than 0, cannot be negative");
                return;
            }
            Heading -= degree;
            if (Heading < 0) Heading += 360;
            Console.WriteLine("Left turn {0} degree, Heading {1} degree", degree, Heading);
            headingChange = degree;
            if (headingChange > 20 && speedChange > 20 && OutOfControl != null)
                OutOfControl(); 
        }

        /// <summary>
        /// Turn right
        /// </summary>
        /// <param name="degree"></param>
        public void turnRight(int degree)
        {
            if (degree >= 360)
            {
                Console.WriteLine("Turning is large than 360, no heading change");
                return;
            }
            if (degree < 0)
            {
                Console.WriteLine("Turning is less than 0, cannot be negative");
                return;
            }
            Heading += degree;
            if (Heading >= 360) Heading -= 360;
            Console.WriteLine("Right turn {0} degree, Heading {1} degree", degree, Heading);
            headingChange = degree;
            if (headingChange > 20 && speedChange > 20 && OutOfControl != null)
                OutOfControl();        
        }

        /// <summary>
        /// add speed, maximum 100
        /// </summary>
        /// <param name="acc"></param>
        public void accelerate(int acc) {
            if (acc > 100) {
                Console.WriteLine("Maximum accelerate speed is 100 mph");
                Speed += 100;
                Console.WriteLine("Now your speed is {0}", Speed);
                return;
            }
            Speed += acc;
            Console.WriteLine("Now your speed is {0}", Speed);
            speedChange = acc;
            if (headingChange > 20 && speedChange > 20 && OutOfControl != null)
                OutOfControl();        
        }

        /// <summary>
        /// substract speed, minimum 0
        /// Also, I think the substract cannot be more than the current speed, so I add a limit here
        /// </summary>
        /// <param name="dec"></param>
        public void brake(int dec) {
            if (dec < 0) {
                Console.WriteLine("Cannot decrease the speed less than 0");
                return;
            }
            if (dec > Speed) {
                Speed = 0;
            }
            else  Speed -= dec;
            Console.WriteLine("Your speed is {0}", Speed);
            if (BrakeLight != null)
                BrakeLight();
            speedChange = dec;
            if (headingChange > 20 && speedChange > 20 && OutOfControl != null)
                OutOfControl();          
        }

        //Constructor
        public CarInstance()
        {
            BrakeLight += brakeLight;
            MaxSpeed += maxSpeed;
            NoLongerRegistered += noLongerRegistered;
            OutOfControl += outOfControl;
        }

        public CarInstance(string fn, string ln, CarColor col, bool isR, IEnumerable<Tire> ti, double sp, double hd)
        {
            OwnerFirstName = fn;
            OwnerLastName = ln;
            Color = col;
            IsRegistered = isR;
            Tires = ti;
            Speed = sp;
            Heading = hd;
            BrakeLight += brakeLight;
            MaxSpeed += maxSpeed;
            NoLongerRegistered += noLongerRegistered;
            OutOfControl += outOfControl;
        }

        public CarInstance(String makeN, string modelN, int year, SizeClass size, double height, double length, string fn, string ln, CarColor col, bool isR, IEnumerable<Tire> ti, double sp, double hd)
            : base(makeN, modelN, year, size, height, length)
        {
            OwnerFirstName = fn;
            OwnerLastName = ln;
            Color = col;
            IsRegistered = isR;
            Tires = ti;
            Speed = sp;
            Heading = hd;
            BrakeLight += brakeLight;
            MaxSpeed += maxSpeed;
            NoLongerRegistered += noLongerRegistered;
            OutOfControl += outOfControl;
        }

    }
}
