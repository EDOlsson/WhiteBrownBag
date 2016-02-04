using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;

namespace HelloPeopleTests
{
    public class HelloPeopleTests : IDisposable
    {
        readonly RunningApplication _app;

        public HelloPeopleTests()
        {
            _app = ApplicationUnderTest.LaunchApplication();

            _app.EnableRandomDelays();
        }

        public void ApplicationShouldLaunch()
        {
            _app.ClickGreetButton();
        }

        public async Task ClickingGreetButtonShouldDisplayHelloWorld()
        {
            _app.ClickGreetButton();

            var g = await _app.GetGreetingAsync();

            g.ShouldBe("Hello World!");
        }

        public async Task SelectingBarringtonAndClickingGreetButtonShouldDisplayHelloBarrington()
        {
            _app.SelectBarrington();

            _app.ClickGreetButton();

            var g = await _app.GetGreetingAsync();

            g.ShouldBe("Hello Barrington!");
        }

        public void Dispose()
        {
            _app.Shutdown();
        }
    }
}
