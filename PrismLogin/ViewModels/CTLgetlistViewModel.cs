using Panuon.UI.Silver;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using PrismLogin.Event;
using PrismLogin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace PrismLogin.ViewModels
{
    public class CTLgetlistViewModel : BindableBase
    {
        public DelegateCommand<string> SortCommand { get; private set; }
        public DelegateCommand<System.Windows.Controls.ListView> ShowMessageBoxCommand { get; private set; }
        private ObservableCollection<Person> personCollection = new ObservableCollection<Person>();
        private ICollectionView personCollectionView;
        private readonly IEventAggregator Subshier;//订阅  Prism模式
        public CTLgetlistViewModel(IEventAggregator _Subshier)
        {
            personCollection.Add(new Person() { Name = "刘二", Age = 17, Email = "aa", Tel = "刘二", Sex = "刘二", Address = "刘士大夫士大夫二" });
            personCollection.Add(new Person() { Name = "张三", Age = 18, Email = "bb", Tel = "刘二", Sex = "刘二", Address = "刘士大夫士大夫二" });
            personCollection.Add(new Person() { Name = "李四", Age = 17, Email = "cc", Tel = "刘二", Sex = "刘二", Address = "刘士大夫士大夫二" });
            personCollection.Add(new Person() { Name = "王五", Age = 19, Email = "dd", Tel = "刘二", Sex = "刘二", Address = "刘士大夫士大夫二" });
            personCollection.Add(new Person() { Name = "周六", Age = 18, Email = "ee", Tel = "刘二", Sex = "刘二", Address = "刘士大夫士大夫二" });
            personCollection.Add(new Person() { Name = "胡二", Age = 16, Email = "ff", Tel = "刘二", Sex = "刘二", Address = "刘士大夫士大夫二" });
            personCollection.Add(new Person() { Name = "黄七", Age = 14, Email = "ggg", Tel = "刘二", Sex = "刘二", Address = "刘士大夫士大夫二" });
            personCollection.Add(new Person() { Name = "朱八", Age = 15, Email = "gggh", Tel = "刘二", Sex = "刘二", Address = "刘士大夫士大夫二" });
            personCollection.Add(new Person() { Name = "周四", Age = 13, Email = "iiiii", Tel = "刘二", Sex = "刘二", Address = "刘士大夫士大夫二" });

            this.SortCommand = new DelegateCommand<string>(this.Sort);
            this.ShowMessageBoxCommand = new DelegateCommand<System.Windows.Controls.ListView>(this.DbclickMsessage);
            Subshier = _Subshier;
            Subshier.GetEvent<StudentTo>().Subscribe(SubMessage);
        }
        private void SubMessage(StudentInfo obj)
        {
            Person p = new Person
            { 
                Name=obj.Name,
                Age=55,
                Email="test@tt.com",
                Sex=obj.Sex
            };
            personCollection.Add(p);
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
