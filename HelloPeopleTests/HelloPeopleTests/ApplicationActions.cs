using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace HelloPeopleTests
{
    static class ApplicationUnderTest
    {
        public static RunningApplication LaunchApplication()
        {
            var p = new System.Diagnostics.ProcessStartInfo(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "SimpleApp", "Debug", "SimpleWpfApp.exe"));
            var a = Application.AttachOrLaunch(p);

            return new RunningApplication(a.GetWindow("SimpleWindow"));
        }
    }

    class RunningApplication
    {
        readonly Window _window;

        public RunningApplication(Window w)
        {
            _window = w;
        }

        public void Shutdown()
        {
            _window.Close();
            System.Threading.Thread.Sleep(100);
        }

        public void ClickGreetButton()
        {
            var b = _window.Get<Button>(SearchCriteria.ByAutomationId("9C40BE16-15B7-4CF4-9666-06D5E16F23C5"));

            b.Click();
        }

        public string GetGreeting()
        {
            var m = _window.Get<Label>(SearchCriteria.ByAutomationId("8986AD15-8479-423E-A06D-008D9CA55854"));

            return m.Text;
        }

        public Task<string> GetGreetingAsync()
        {
            var m = _window.Get<Label>(SearchCriteria.ByAutomationId("8986AD15-8479-423E-A06D-008D9CA55854"));

            _window.WaitTill(() => m.Text != string.Empty, TimeSpan.FromSeconds(30D));

            return Task.FromResult(m.Text);
        }

        public void SelectBarrington()
        {
            var b = _window.Get<RadioButton>(SearchCriteria.ByAutomationId("D3E2F9BF-827A-4D54-A594-6483E01D2374"));

            b.Click();
        }

        public void EnableRandomDelays()
        {
            var c = _window.Get<CheckBox>(SearchCriteria.ByAutomationId("46CB4826-AE59-47A5-BE71-869122FB40B2"));

            c.Click();
        }
    }
}
