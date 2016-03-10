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

            //
            // TODO - support random delays
            //
            // _app.EnableRandomDelays();
        }

        public void ApplicationShouldLaunch()
        {
            _app.ClickGreetButton();
        }

        public void ClickingGreetButtonShouldDisplayHelloWorld()
        {
            _app.ClickGreetButton();

            var g = _app.GetGreeting();

            g.ShouldBe("Hello World!");
        }

        public void SelectingBarringtonAndClickingGreetButtonShouldDisplayHelloBarrington()
        {
            _app.SelectBarrington();

            _app.ClickGreetButton();

            var g = _app.GetGreeting();

            g.ShouldBe("Hello Barrington!");
        }

        public void Dispose()
        {
            _app.Shutdown();
        }
    }
}
