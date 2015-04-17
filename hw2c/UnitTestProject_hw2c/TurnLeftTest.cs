using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NYU
{
    [TestClass]
    public class TurnLeftTest
    {
        [TestMethod]
        public void TurnLeftTestMethod()
        {
            CarInstance car = new CarInstance { Heading = 100 };
            double expect;

            for (int i = -360; i < 480; i++) {
                if (i < 0 || i >= 360)
                    expect = car.Heading;
                else {
                    expect = car.Heading - i;
                    if (expect < 0) expect += 360;
                }
                car.turnLeft(i);
                Assert.AreEqual(expect, car.Heading);
            }
        }
    }
}
