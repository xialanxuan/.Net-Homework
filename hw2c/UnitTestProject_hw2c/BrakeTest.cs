using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NYU
{
    [TestClass]
    public class BrakeTest
    {
        [TestMethod]
        public void BrakeTestMethod()
        {
            CarInstance car = new CarInstance { Speed = 60 };
            double expect;

            for (int i = -20; i < 500; i++)
            {
                if (i < 0) expect = car.Speed;
                else {
                    expect = car.Speed - i;
                    if (expect < 0) expect = 0;
                }
                car.brake(i);
                Assert.AreEqual(expect, car.Speed);
            }
        }
    }
}
