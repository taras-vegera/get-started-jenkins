using api.Controllers;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System;
using System.Linq;

namespace tests
{
    [TestFixture]
    public class WeatherForecast
    {
        [Test]
        public void ShouldAddTwoNumbers()
        {
            var controller = new WeatherForecastController();
            var list = controller.Get();
            Assert.That(list, !Is.Null);
            Assert.That(list.Count(), Is.EqualTo(5));
        }

    }
}
