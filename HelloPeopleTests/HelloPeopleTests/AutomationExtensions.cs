using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace HelloPeopleTests
{
    static class AutomationExtensions
    {
        public static AutomationElement FindChildByProcessId(this AutomationElement element, int id) => element.FindChildByCondition(new PropertyCondition(AutomationElement.ProcessIdProperty, id));

        public static AutomationElement FindChildByCondition(this AutomationElement element, Condition condition) => element.FindFirst(TreeScope.Children, condition);
    }
}
