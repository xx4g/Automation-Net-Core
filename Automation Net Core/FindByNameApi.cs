using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace Automation_Net_Core
{
    internal class FindByNameApi
    {
        public static FrameworkElement FindControlByName(DependencyObject container, string name)
        {
            if (container == null) return null;

            int childCount = VisualTreeHelper.GetChildrenCount(container);

            for (int i = 0; i < childCount; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(container, i);

                if (child is FrameworkElement element && element.Name == name)
                {
                    return element; // Control with the specified name found
                }

                // Recursively search child controls
                FrameworkElement foundElement = FindControlByName(child, name);

                if (foundElement != null)
                {
                    return foundElement; // Control found in child's hierarchy
                }
            }

            return null; // Control not found
        }
    }
}
