using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace TicTacToe.Additions
{
    public static class Elements
    {
        public static T GetChildOfType<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj == null)
            {
                return null;
            }
            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                var child = VisualTreeHelper.GetChild(depObj, i);
                var result = (child as T) ?? GetChildOfType<T>(child);
                if (result != null) return result;
            }
            return null;
        }
        
        public static List<T> GetListOfChildrenOfType<T>(DependencyObject depObj) where T : DependencyObject
        {
            var result = new List<T>();
            if (depObj == null)
            {
                return null;
            }
            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                var child = VisualTreeHelper.GetChild(depObj, i);
                result.Add((child as T) ?? GetChildOfType<T>(child));
            }
            return result;
        }
    }
}