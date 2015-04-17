using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NYU
{
    [TestClass]
    public class TurnRightTest
    {
        [TestMethod]
        public void TurnRightTestMethod()
        {
            CarInstance car = new CarInstance { Heading = 100 };
            double expect;

            for (int i = -360; i < 480; i++)
            {
                if (i < 0 || i >= 360)
                    expect = car.Heading;
                else
                {
                    expect = car.Heading + i;
                    if (expect > 360) expect -= 360;
                }
                car.turnRight(i);
                Assert.AreEqual(expect, car.Heading);
            }
        }
    }
}
