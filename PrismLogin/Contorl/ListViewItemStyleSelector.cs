using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace PrismLogin.Contorl
{
    public class ListViewItemStyleSelector : StyleSelector
    {
        public override Style SelectStyle(object item,
            DependencyObject container)
        {
            Style st = new Style();
            st.TargetType = typeof(ListViewItem);
            Setter backGroundSetter = new Setter();
            backGroundSetter.Property = ListViewItem.BackgroundProperty;

            st.Setters.Add(new Setter
            {
                Property = ListViewItem.FontSizeProperty,
                Value = 20.0
            });
            st.Setters.Add(new Setter
            {
                Property = ListViewItem.FontFamilyProperty,
                Value = new FontFamily("Microsoft YaHei")
            }) ;
            Trigger triggerIsMouseOver = new Trigger { Property = ListViewItem.IsMouseOverProperty, Value = true };
            triggerIsMouseOver.Setters.Add(new Setter(ListViewItem.BackgroundProperty, Brushes.Gray));
            triggerIsMouseOver.Setters.Add(new Setter(ListViewItem.ForegroundProperty, Brushes.White));
            st.Triggers.Add(triggerIsMouseOver);
            Trigger triggerIsSelectd = new Trigger { Property = ListViewItem.IsSelectedProperty, Value = true };
            triggerIsSelectd.Setters.Add(new Setter(ListViewItem.BackgroundProperty, new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 134, 108))));
            triggerIsSelectd.Setters.Add(new Setter(ListViewItem.ForegroundProperty, Brushes.White));
            st.Triggers.Add(triggerIsSelectd);

            ListView listView =
                ItemsControl.ItemsControlFromItemContainer(container)
                  as ListView;
            int index =
                listView.ItemContainerGenerator.IndexFromContainer(container);
            if (index % 2 == 0)
            {
                backGroundSetter.Value = Brushes.Gainsboro;//new SolidColorBrush(System.Windows.Media.Color.FromRgb(85, 85, 85));
            }
            else
            {
                backGroundSetter.Value = Brushes.Beige;//new SolidColorBrush(System.Windows.Media.Color.FromRgb(102, 102, 102));
            }
            st.Setters.Add(backGroundSetter);

            return st;
        }
    }
}
