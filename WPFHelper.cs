using System.Windows;
using System.Windows.Media;

namespace WPFToolbox
{
    internal static class WPFHelper
    {
        public static T? GetVisualParent<T>(this DependencyObject item) where T : DependencyObject
        {
            item = VisualTreeHelper.GetParent(item);
            while (item != null && item is not T)
                item = VisualTreeHelper.GetParent(item);
            return (T?)item;
        }

        public static T? GetParent<T>(this FrameworkElement item) where T : FrameworkElement
        {
            FrameworkElement? parent = item.Parent as FrameworkElement;
            while (parent != null && parent is not T)
                parent = parent.Parent as FrameworkElement;
            return (T?)parent;
        }
    }
}
