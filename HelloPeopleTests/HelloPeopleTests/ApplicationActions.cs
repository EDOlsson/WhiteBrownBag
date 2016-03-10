using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace HelloPeopleTests
{
    static class ApplicationUnderTest
    {
        public static RunningApplication LaunchApplication()
        {
            var p = Process.Start(new ProcessStartInfo(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "SimpleApp", "Debug", "SimpleWpfApp.exe")));

            p.WaitForInputIdle();
            System.Threading.Thread.Sleep(4000);

            var w = AutomationElement.RootElement.FindChildByProcessId(p.Id);
            return new RunningApplication(w);
        }
    }

    class RunningApplication
    {
        readonly AutomationElement _rootWindow;

        public RunningApplication(AutomationElement w)
        {
            _rootWindow = w;
        }

        public void Shutdown()
        {
            var p = _rootWindow.GetCurrentPattern(WindowPattern.Pattern) as WindowPattern;
            p?.Close();
        }

        public void ClickGreetButton()
        {
            var b = _rootWindow.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, "9C40BE16-15B7-4CF4-9666-06D5E16F23C5"));

            var p = b?.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;

            p?.Invoke();
        }

        public string GetGreeting()
        {
            var b = _rootWindow.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, "8986AD15-8479-423E-A06D-008D9CA55854"));

            return b?.Current.Name;
        }

        public void SelectBarrington()
        {
            var b = _rootWindow.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, "D3E2F9BF-827A-4D54-A594-6483E01D2374"));

            var p = b?.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;

            p?.Select();
        }

        public void EnableRandomDelays()
        {
            //var c = _window.Get<CheckBox>(SearchCriteria.ByAutomationId("46CB4826-AE59-47A5-BE71-869122FB40B2"));

            //c.Click();
        }
    }
}
