﻿using DropDownMenu.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PrismLogin.Views
{
    /// <summary>

    /// UserControlMenuItem.xaml 的交互逻辑

    /// </summary>

    public partial class UserControlMenuItem : UserControl

    {

        MenuDrawerFloat _context;

        public UserControlMenuItem(ItemMenu itemMenu, MenuDrawerFloat context)

        {

            InitializeComponent();

            _context = context;

            ExpanderMenu.Visibility = itemMenu.SubItems == null ? Visibility.Collapsed : Visibility.Visible;

            ListViewItemMenu.Visibility = itemMenu.SubItems == null ? Visibility.Visible : Visibility.Collapsed;

            this.DataContext = itemMenu;

        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)

        {
             _context.SwitchScreen(((SubItem)((ListView)sender).SelectedItem).Screen);
        }
    }
}
