using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PrismLogin.Models
{
    public class NavMenuModel : MenuModel
    {
        public NavMenuModel()
        {
            ChildMenus = new ObservableCollection<MenuModel>();
        }
        public ObservableCollection<MenuModel> ChildMenus { get; }
    }

}
