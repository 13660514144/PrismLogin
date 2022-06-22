using Prism.Mvvm;
using Prism.Events;
using PrismLogin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Prism.Commands;
using PrismLogin.Contorl;
using Panuon.UI.Silver;
using System.Windows;

namespace PrismLogin.ViewModels
{
    public class TreeViewViewModel : BindableBase
    {
        public ObservableCollection<NavMenuModel> NavMenus { get; }

        public ICommand SelectItemChangeCommand
        {
            get
            {
                return new BaseCommand((param) =>
                {
                    if (param != null)
                    {                        
                        SelectedItem = param as MenuModel;
                       var result = MessageBoxX.Show(SelectedItem.MenuName, "Infomation", null, MessageBoxButton.OK);
                    }
                });
            }
        }

        public TreeViewViewModel()
        {
            NavMenus = new ObservableCollection<NavMenuModel>();
            var menu = new NavMenuModel() { Id = 1, MenuName = "Chapter 1" };

            var subMenu = new NavMenuModel() { Id = 11, MenuName = "Chapter 1.1", ParentId = 1 };
            subMenu.ChildMenus.Add(new MenuModel() { Id = 111, MenuName = "Chapter 1.1.1", ParentId = 11 });
            menu.ChildMenus.Add(subMenu);

            NavMenus.Add(menu);
            var m2 = new NavMenuModel() { Id = 2, MenuName = "Chapter 2" };

            var subMenu2 = new NavMenuModel() { Id = 21, MenuName = "Chapter 2.1", ParentId = 1 };

            m2.ChildMenus.Add(subMenu2);
            NavMenus.Add(m2);
            NavMenus.Add(new NavMenuModel() { Id = 3, MenuName = "Chapter 3" });

            subMenu.ChildMenus.Add(new MenuModel() { Id = 112, MenuName = "我是最后码", ParentId = 11 });
            
        }
        private MenuModel _selectedItem;
        public MenuModel SelectedItem
        {
            get { return _selectedItem; }
            set { SetProperty(ref _selectedItem, value); }
        }
    }
}
