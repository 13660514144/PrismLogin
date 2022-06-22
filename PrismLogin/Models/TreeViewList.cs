using System;
using System.Collections.Generic;
using System.Text;

namespace PrismLogin.Models
{
    public class TreeViewList
    {
        public TreeViewList()
        {

        }
        public string Menu_Name { get; set; }///子菜单编号
        public string Menu_Level { get; set; }//主菜单编号（"000"为主菜单，其他为子项）
        public string SORT_NO { get; set; }
        private List<TreeViewList> _Name;

        public List<TreeViewList> Childs
        {
            get { return _Name; }
            set { _Name = value; }
        }
    }
}
