using MaterialDesignThemes.Wpf;
using System;

using System.Collections.Generic;

using System.Text;

using System.Windows.Controls;

namespace DropDownMenu.ViewModel

{

    public class ItemMenu

    {

        public ItemMenu(string header, List<SubItem> subItems, PackIconKind icon)

        {

            Header = header;

            SubItems = subItems;

            Icon = icon;

        }

        public string Header { get; private set; }

        public PackIconKind Icon { get; private set; }

        public List<SubItem> SubItems { get; private set; }

        public UserControl Screen { get; private set; }

    }

}