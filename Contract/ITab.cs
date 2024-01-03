
using Fluent;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Contract
{
    public abstract class ITab
    {
        public UIElement? TargetElement;
        public abstract string? name { get; }
        public abstract RibbonTabItem createTab();
    }

}
