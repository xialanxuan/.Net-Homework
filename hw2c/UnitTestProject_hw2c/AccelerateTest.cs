using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NYU
{
    [TestClass]
    public class AccelerateTest
    {
        [TestMethod]
        public void AccelerateTestMethod()
        {
            CarInstance car = new CarInstance { Speed = 40 };
            double expect;

            for (int i = 0; i < 1000; i++) {
                if (i < 100)
                {
                    expect = car.Speed + i;
                    if (expect > CarInstance.speedLimit) expect = CarInstance.speedLimit;
                }
                else {
                    expect = car.Speed + 100;
                    if (expect > CarInstance.speedLimit) expect = CarInstance.speedLimit;
                }
                car.accelerate(i);
                Assert.AreEqual(expect, car.Speed); 
            }
        }
    }
}
