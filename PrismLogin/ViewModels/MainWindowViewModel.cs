using Panuon.UI.Silver;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using PrismLogin.Models;
using PrismLogin.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using TreeView = PrismLogin.Views.TreeView;
namespace PrismLogin.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public DelegateCommand<string> SortCommand { get; private set; }
        public DelegateCommand<System.Windows.Controls.ListView> ShowMessageBoxCommand { get; private set; }
        public DelegateCommand<System.Windows.Controls.TabControl> TabCommand { get; private set; }
        private ObservableCollection<Person> personCollection = new ObservableCollection<Person>();
        private ICollectionView personCollectionView;
        private ObservableCollection<string> _TabCollection = new ObservableCollection<string>();
        private ICollectionView _TabCollectionView;

        private readonly IContainerExtension _container;
        CTLgetlist LIST;
        DataListGrid Listgrid;
        TreeView treeview;
        MenuSample menu;
        MenuDrawer menudrawer;
        MenuDrawerFloat menudrawerfloat;
        SignAlr singalrxaml;
        SignalrClientHub _HUB;
        public MainWindowViewModel(DataListGrid _Listgrid, IContainerExtension container, SignalrClientHub hub)
        {
            _container = container;
            LIST = _container.Resolve<CTLgetlist>();// new CTLgetlist();
            Listgrid = _Listgrid;// new DataListGrid();
            treeview = _container.Resolve<TreeView>();
            menu = _container.Resolve<MenuSample>();
            menudrawer = _container.Resolve<MenuDrawer>();
            menudrawerfloat = _container.Resolve<MenuDrawerFloat>();
            singalrxaml = _container.Resolve<SignAlr>();
            _HUB = hub;// _container.Resolve<SignalrClientHub>();
            _HUB.StartAsync();
            personCollection.Add(new Person() { Name = "刘二", Age = 17 , Email = "aa", Tel = "刘二", Sex = "刘二", Address = "刘士大夫士大夫二" });
            personCollection.Add(new Person() { Name = "张三", Age = 18, Email = "bb", Tel = "刘二", Sex = "刘二", Address = "刘士大夫士大夫二" });
            personCollection.Add(new Person() { Name = "李四", Age = 17, Email = "cc", Tel = "刘二", Sex = "刘二", Address = "刘士大夫士大夫二" });
            personCollection.Add(new Person() { Name = "王五", Age = 19, Email = "dd", Tel = "刘二", Sex = "刘二", Address = "刘士大夫士大夫二" });
            personCollection.Add(new Person() { Name = "周六", Age = 18, Email = "ee", Tel = "刘二", Sex = "刘二", Address = "刘士大夫士大夫二" });
            personCollection.Add(new Person() { Name = "胡二", Age = 16, Email = "ff", Tel = "刘二", Sex = "刘二", Address = "刘士大夫士大夫二" });
            personCollection.Add(new Person() { Name = "黄七", Age = 14, Email = "ggg", Tel = "刘二", Sex = "刘二", Address = "刘士大夫士大夫二" });
            personCollection.Add(new Person() { Name = "朱八", Age = 15, Email = "gggh", Tel = "刘二", Sex = "刘二", Address = "刘士大夫士大夫二" });
            personCollection.Add(new Person() { Name = "周四", Age = 13, Email = "iiiii", Tel = "刘二", Sex = "刘二", Address = "刘士大夫士大夫二" });

            _TabCollection.Add("刘二");
            _TabCollection.Add("张三");
            this.SortCommand = new DelegateCommand<string>(this.Sort);
            this.ShowMessageBoxCommand = new DelegateCommand<System.Windows.Controls.ListView>(this.DbclickMsessage);
            this.TabCommand = new DelegateCommand<System.Windows.Controls.TabControl>(this.TabclickMsessage);
        }
        public ICollectionView TabCollectionView
        {
            get
            {
                if (_TabCollectionView == null)
                {
                    _TabCollectionView = CollectionViewSource.GetDefaultView(_TabCollection);
                }
                return _TabCollectionView;
            }
            set { SetProperty(ref _TabCollectionView, value); }
        }

        public ICollectionView PersonCollectionView
        {
            get
            {
                if (personCollectionView == null)
                {
                    personCollectionView = CollectionViewSource.GetDefaultView(personCollection);
                }
                return personCollectionView;
            }
            set { SetProperty(ref personCollectionView, value); }           
        }

        private void TabclickMsessage(System.Windows.Controls.TabControl e)
        {
            
            TabItem item = e.SelectedItem as TabItem;
            item.Focus();
            if (item.Header.ToString() == "listview")
            {
                item.Content = LIST;
            }
            else if (item.Header.ToString() == "datagrid")
            {
                item.Content = Listgrid;
            }
            else if (item.Header.ToString() == "treeview")
            {
                item.Content = treeview;
            }
            else if (item.Header.ToString() == "menu")
            {
                item.Content = menu;
            }
            else if (item.Header.ToString() == "menudrawer")
            {
                item.Content = menudrawer;
            }
            else if (item.Header.ToString() == "menudrawerfloat")
            {
                item.Content = menudrawerfloat;
            }
            else if (item.Header.ToString() == "signalr")
            {
                item.Content = singalrxaml;
            }
            //MessageBoxX.Show(item.Header.ToString(), "Infomation", null, MessageBoxButton.OK);
        }
        private void Sort(string HeadName)
        {
            if (PersonCollectionView.SortDescriptions.Count > 0 &&
                PersonCollectionView.SortDescriptions[0].PropertyName == HeadName &&
                PersonCollectionView.SortDescriptions[0].Direction == ListSortDirection.Ascending)
            {
                PersonCollectionView.SortDescriptions.Clear();
                PersonCollectionView.SortDescriptions.Add(new SortDescription(HeadName, ListSortDirection.Descending));
            }
            else
            {
                PersonCollectionView.SortDescriptions.Clear();
                PersonCollectionView.SortDescriptions.Add(new SortDescription(HeadName, ListSortDirection.Ascending));
            }
        }
        private void DbclickMsessage(System.Windows.Controls.ListView e)
        {          
            var person = e.SelectedItem as Person;
            var result = MessageBoxX.Show(person.Name, "Infomation", null, MessageBoxButton.OK);
            int rows = e.SelectedIndex;
            personCollection.Remove(person);
        }
    }
}
