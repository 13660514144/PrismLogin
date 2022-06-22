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
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace PrismLogin.ViewModels
{
    public class DataListGridViewModel : BindableBase
    {
        //public DelegateCommand<System.Windows.Controls.DataGrid> ShowMessageBoxCommand { get; private set; }
        public DelegateCommand<object[]> ShowMessageBoxCommand { get; private set; }
        private ObservableCollection<StudentInfo> studentCollection = new ObservableCollection<StudentInfo>();
        private ICollectionView studentCollectionView;
        private int rowsindex = 0;
        private IEventAggregator Pubshier; //发布  Prism模式

        ICommand? saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (saveCommand == null)
                {
                    saveCommand = new DelegateCommand<StackPanel>(SaveChange);
                }
                return saveCommand;
            }
        }
        void SaveChange(StackPanel obj)
        {
            //var result = MessageBoxX.Show(this.TName, "Infomation", null, MessageBoxButton.OK);
            StudentInfo sTU = new StudentInfo
            {
                Name = this.TName,
                Class = this.TClass,
                Sex = this.TSex,
                ClassRank = this.ClassRank,
                SchoolRank = this.SchoolRank
            };
            studentCollection[rowsindex] = sTU;
            CleanTxt();
            Pubshier.GetEvent<StudentTo>().Publish(sTU); //发布  Prism模式
            obj.Visibility = Visibility.Collapsed;
        }
        void CleanTxt()
        {
            this.TName = string.Empty;
            this.TClass = string.Empty;
            this.TSex = string.Empty;
            this.ClassRank = 0;
            this.SchoolRank = 0;
        }
        private string tname;
        public string TName
        {
            get
            {
                return tname;
            }
            //set { SetProperty(ref _Tname, value); }
            set { tname = value; RaisePropertyChanged("TName"); }
        }
        private int classrank;
        public int ClassRank
        {
            get
            {
                return classrank;
            }
            set { SetProperty(ref classrank, value); }
        }
        private int schoolrank;
        public int SchoolRank
        {
            get
            {
                return schoolrank;
            }
            set { SetProperty(ref schoolrank, value); }
        }
        private string tclass;
        public string TClass
        {
            get
            {
                return tclass;
            }
            set { SetProperty(ref tclass, value); }
            //set { tclass = value; RaisePropertyChanged("TClass"); }
        }
        private string tsex;
        public string TSex
        {
            get { return tsex; }
            //set { SetProperty(ref _Tsex, value); }
            set { tsex = value; RaisePropertyChanged("TSex"); }
        }
        public DataListGridViewModel(IEventAggregator _pub)
        {
            InitPushData();
            //this.ShowMessageBoxCommand = new DelegateCommand<System.Windows.Controls.DataGrid>(this.DbclickMsessage);
            this.ShowMessageBoxCommand = new DelegateCommand<object[]>(this.DbclickMsessage);
            CleanTxt();
            Pubshier = _pub;
            Pubshier.GetEvent<DawerTo>().Subscribe(SubMessage);
        }
        private void SubMessage(StudentInfo obj)
        {
            studentCollection.Add(obj);
        }
        private void InitPushData()
        {
            studentCollection.Add(new StudentInfo()
            {
                Name = "张三",
                Class = "三班",
                Sex = "男",
                ClassRank = 10,
                SchoolRank = 103
            });
            studentCollection.Add(new StudentInfo()
            {
                Name = "张三",
                Class = "三班",
                Sex = "男",
                ClassRank = 10,
                SchoolRank = 103
            });
            studentCollection.Add(new StudentInfo()
            {
                Name = "李四",
                Class = "三班",
                Sex = "男",
                ClassRank = 12,
                SchoolRank = 110
            });
            studentCollection.Add(new StudentInfo()
            {
                Name = "李梅",
                Class = "三班",
                Sex = "女",
                ClassRank = 3,
                SchoolRank = 70
            });
        }
        public ICollectionView StudentCollectionView
        {
            get
            {
                if (studentCollectionView == null)
                {
                    studentCollectionView = CollectionViewSource.GetDefaultView(studentCollection);
                }
                return studentCollectionView;
            }
            set { SetProperty(ref studentCollectionView, value); }
        }
        //private void DbclickMsessage(System.Windows.Controls.DataGrid e)
        private void DbclickMsessage(object[] e)
        {
            var student =((DataGrid)e[0]).SelectedItem  as StudentInfo;
            var result = MessageBoxX.Show(student.Name, "Infomation", null, MessageBoxButton.OK);
            rowsindex = ((DataGrid)e[0]).SelectedIndex;
            TName = student.Name;
            TClass = student.Class;
            TSex = student.Sex;
            ClassRank = student.ClassRank;
            SchoolRank = student.SchoolRank;
            ((StackPanel)e[1]).Visibility = Visibility.Visible;
        }

    }
}
