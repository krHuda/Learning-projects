using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace TicTacToe.Additions
{
    /// <summary>
    /// В данном классе реализованы методы помогающие найти нужные элементы вёрстки.
    /// </summary>
    public static class Elements
    {
        /// <summary>
        /// Данный метод возвращает дочерний элемент определённого типа.
        /// </summary>
        /// <param name="depObj">Исходный элемент.</param>
        /// <typeparam name="T">Тип искомого элементы.</typeparam>
        /// <returns>Искомый элемент.</returns>
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
        
        /// <summary>
        /// Данный метод возвращает список дочерних элементов определённого типа.
        /// </summary>
        /// <param name="depObj">Исходный элемент.</param>
        /// <typeparam name="T">Тип искомых элементов.</typeparam>
        /// <returns>Список искомых элементов.</returns>
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