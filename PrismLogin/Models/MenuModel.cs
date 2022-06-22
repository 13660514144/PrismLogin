using System;
using System.Collections.Generic;
using System.Text;

namespace PrismLogin.Models
{
    public class MenuModel
    {
        public int Id { get; set; }

        public int ParentId { get; set; }

        public string MenuName { get; set; }
        public MenuModel()
        {
        }
        public MenuModel(int menuId, string menuName, int parentMenuId, params MenuModel[] subItems)
        {
            this.Id = menuId;
            this.MenuName = menuName;
            this.ParentId = parentMenuId;
        }
    }
}
