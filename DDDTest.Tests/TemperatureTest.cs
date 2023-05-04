using DDD.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DDDTest.Tests
{
    [TestClass]
    public class TemperatureTest
    {
        [TestMethod]
        public void 小数点２桁以下で丸めて表示できる()
        {
            Temperature t = new Temperature(12.3f);
            Assert.AreEqual(12.3f, t.Value);
            Assert.AreEqual("12.30", t.DisplayValue);
            Assert.AreEqual("12.30℃", t.DisplayValueWithUnit);
            Assert.AreEqual("12.30 ℃", t.DisplayValueWithUnitSpace);

        }

        [TestMethod]
        public void 温度Equals()
        {
            Temperature t1 = new Temperature(12.3f);
            Temperature t2 = new Temperature(12.3f);

            Assert.AreEqual(true, t1.Equals(t2));
        }

        [TestMethod]
        public void 温度EqualsEquals()
        {
            Temperature t1 = new Temperature(12.3f);
            Temperature t2 = new Temperature(12.3f);

            Assert.AreEqual(true, t1 == t2);
        }
    }
}
