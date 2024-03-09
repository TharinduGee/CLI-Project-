using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI_Project
{
    public class UserMenuItems
    {
        private string title;
        private bool isSelected;


        public string  Title { get; set; }
        public bool IsSelected { get; set; }
        

        public UserMenuItems()
        {
            Title = null;
            IsSelected = false;
        }

        public UserMenuItems(string title, bool isselected)
        {
            Title = title;
            IsSelected = isselected;
        }
    }
}
