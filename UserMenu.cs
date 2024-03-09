using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CLI_Project
{
    public class UserMenu
    {
        public int ColPos { get; set; }
        public int RowPos { get; set; }
        public List<UserMenuItems> MenuItems { get; set; }
        public List<UserMenuItems> SubMenuItems { get; set; }
        public List<User> Users { get; set; }

        public UserMenu()
        {
            ColPos = 1;
            RowPos = 1;

            MenuItems = new List<UserMenuItems>
            {
                new UserMenuItems("Add User",true),
                new UserMenuItems("Select User",false),
                new UserMenuItems("Delete User",false),
                new UserMenuItems("Display All Users",false),
                new UserMenuItems("Quit",false)
                 
            };

            SubMenuItems = new List<UserMenuItems>
               {
                new UserMenuItems("Modify User",true),
                new UserMenuItems("Add Modules",false),
                new UserMenuItems("Remove Modules",false),
                new UserMenuItems("Add Grade",false),
                new UserMenuItems("Back",false)

               };



            Users = new List<User> { };

            
        }


        public void DisplayAllUsers(List<User> users)
        {
            int i = 2;
            Console.SetCursorPosition(0, i);
            Console.Write($"Id");
            Console.SetCursorPosition(25, i);
            Console.Write($"First Name");
            Console.SetCursorPosition(50, i);
            Console.Write($"Last Name");
            Console.SetCursorPosition(75, i);
            Console.Write($"Date of Birth");
            Console.SetCursorPosition(100, i);
            Console.Write($"Address");
            Console.SetCursorPosition(0, i+1);
            Console.WriteLine("========================================================================================================================");
            i = 5;
            foreach (User user in users)
            {
                Console.SetCursorPosition(0,i);
                Console.Write($"{user.Id}   ");
                Console.SetCursorPosition(25,i);
                Console.Write($"{user.FirstName} ");
                Console.SetCursorPosition(50,i);
                Console.Write($"{user.LastName}");
                Console.SetCursorPosition(75,i);
                Console.Write($"{user.Dob} ");
                Console.SetCursorPosition(100,i);
                Console.Write($"{user.Address}  ");
                i += 2;

            }
            Console.ReadKey();
            Console.Clear();
        }


        public void selectUser(List<User> users)
        {

            int i = 2;
            foreach (User user in users)
            {
                Console.SetCursorPosition(0, i);
                Console.Write($"{user.Id}   ");
                Console.SetCursorPosition(25, i);
                Console.Write($"{user.FirstName} ");
                Console.SetCursorPosition(50, i);
                Console.Write($"{user.LastName}");
                Console.SetCursorPosition(75, i);
                Console.Write($"{user.Dob} ");
                Console.SetCursorPosition(100, i);
                Console.Write($"{user.Address}  ");
                i += 2;

            }
            Console.SetCursorPosition(0, i+3);
            Console.WriteLine("Enter the ID of user that you want to select: ");
            int id = Convert.ToInt32(Console.ReadLine());
            submenu(id);

        }

        public void Modify_user(int id)
        {
            
            Console.Clear ();
            int i = 2;
            foreach (User user in Users)
            {
                if (user.Id == id) {

                    Console.SetCursorPosition(0, i);
                    Console.Write($"{user.Id}   ");
                    Console.SetCursorPosition(25, i);
                    Console.Write($"{user.FirstName} ");
                    Console.SetCursorPosition(50, i);
                    Console.Write($"{user.LastName}");
                    Console.SetCursorPosition(75, i);
                    Console.Write($"{user.Dob} ");
                    Console.SetCursorPosition(100, i);
                    Console.Write($"{user.Address}  ");
                    
                }

            }
            Console.SetCursorPosition(10, 4);
            Console.WriteLine("\nEnter 1 : Change First Name: ");
            Console.WriteLine("Enter 2 : Change Last Name: ");
            Console.WriteLine("Enter 3 : Change Date of Birth ");
            Console.WriteLine("Enter 4 : Change the Address");
            Console.WriteLine("Enter 5 : Go to Main Menu");


            int choice = Convert.ToInt32(Console.ReadLine());




            switch (choice) 
            {
                case 1:
                    Console.WriteLine("\nEnter New First Name: ");
                    string First_Name = Console.ReadLine();
                    Users.Where(w => w.Id ==id).ToList().ForEach(s => s.FirstName = First_Name);
                    Console.WriteLine("First Name was changed Succesfully");
                    Console.ReadKey();
                    Console.Clear();
                    Modify_user(id);


                    break;
                case 2:

                    Console.WriteLine("\nEnter New Last Name: ");
                    string Last_Name = Console.ReadLine();
                    Users.Where(w => w.Id == id).ToList().ForEach(s => s.LastName = Last_Name);
                    Console.WriteLine("Last Name was changed Succesfully");
                    Console.ReadKey();
                    Console.Clear();
                    Modify_user(id);
                    break;


                case 3:
                    Console.WriteLine("\nEnter New Date of Birth: ");
                    string Dob = Console.ReadLine();
                    Users.Where(w => w.Id == id).ToList().ForEach(s => s.Dob = Dob);
                    Console.WriteLine("Date of Birth was changed Succesfully");
                    Console.ReadKey();
                    Console.Clear();
                    Modify_user(id);


                    break;


                case 4:

                    Console.WriteLine("\nEnter New Address: ");
                    string AD = Console.ReadLine();
                    Users.Where(w => w.Id == id).ToList().ForEach(s => s.Address = AD);
                    Console.WriteLine("Address was changed Succesfully");
                    Console.ReadKey();
                    Console.Clear();
                    Modify_user(id);
                    break;
                case 5:
                    DisplayMenu();
                    
                    break;

                default:
                    Console.WriteLine("Error");
                    break;
            }
            Console.ReadKey();
            Console.Clear();
        }

        public void RemoveModule(int id)
        {



            
            
            Console.WriteLine("\n \n Enter the Module code of user that you want to delete : ");
            int code = Convert.ToInt32(Console.ReadLine());

         
            
            foreach (var users in Users) {
                if (id == users.Id) {
                    foreach (var k in users.modules) {
                        if (k.Id == code) {

                            Console.WriteLine("Do you want to delete user (y/n):");
                            string res = Console.ReadLine();

                            if(res == "y")
                            {
                                users.modules.Remove(k);
                                Console.WriteLine($"{code} Module has deleted");
                                break;
                            }else if(res == "n")
                            {
                                break;
                            }
                            
                        }
                    }

                }
            }

            Console.ReadKey();
            DisplayMenu();



        }

        public void addModules(int id) 
        {
            Console.Clear();
            Console.SetCursorPosition(1, 0);
            Console.WriteLine("All ready registered Modules are ");
            Console.SetCursorPosition(70,0);
            Console.WriteLine("Available Modules are");
            Console.SetCursorPosition(70, 3);
            Console.WriteLine("# 3305 Signal and Systems");
            Console.SetCursorPosition(70, 4);
            Console.WriteLine("# 3301 Analog Electronics");
            Console.SetCursorPosition(70, 5);
            Console.WriteLine("# 3302 Data Structures and Algorithms");
            Console.SetCursorPosition(70, 6);
            Console.WriteLine("# 3203 Measurement");
            Console.SetCursorPosition(70, 7);
            Console.WriteLine("# 3251 GUI Prgramming");
            Console.SetCursorPosition(70, 8);
            Console.WriteLine("# 3250 Programming  Project\n\n");

            foreach (var user in Users) 
            {
                if (user.Id == id) {
                    int i = 2;
                    foreach(var k in user.modules)
                    {
                        Console.SetCursorPosition(1, i);
                        Console.WriteLine($"{k.Id}   {k.Name}");
                        i++;
                    }
                }
            }
           
            


            Console.WriteLine("\n Press any key to continue ...");
            Console.ReadKey();


            Console.WriteLine("\n \n \n Enter the Module Code that you want to Add to user : ");
         
            int code_id = Convert.ToInt32(Console.ReadLine());
            switch (code_id)
            {
                case 3305:
                    Modules SAS = new Modules(3305, "Signal and Systems", 3);
                    Users.Where(w => w.Id == id).ToList().ForEach(s => s.modules.Add(SAS));
                    Console.WriteLine($"User {code_id} is registed to {SAS.Name}");
                    break;
                case 3301:
                    Modules AE = new Modules(3301, "Analog Electronics", 3);
                    Users.Where(w => w.Id == id).ToList().ForEach(s => s.modules.Add(AE));
                    Console.WriteLine($"User {code_id} is registed to {AE.Name}");
                    break;
                case 3302:
                    Modules DSA = new Modules(3302, "Data Structures and Algorithems", 3);
                    Users.Where(w => w.Id == id).ToList().ForEach(s => s.modules.Add(DSA));
                    Console.WriteLine($"User {code_id} is registed to {DSA.Name}");
                    break;
                case 3203:
                    Modules M = new Modules(3203, "Measurement", 2);
                    Users.Where(w => w.Id == id).ToList().ForEach(s => s.modules.Add(M));
                    Console.WriteLine($"User {code_id} is registed to {M.Name}");

                    break;
                case 3251:
                    Modules GUI = new Modules(3251, "GUI Prgramming", 2);
                    Users.Where(w => w.Id == id).ToList().ForEach(s => s.modules.Add(GUI));
                    Console.WriteLine($"User {code_id} is registed to {GUI.Name}");
                    break;
                case 3250:
                    Modules PP = new Modules(3250, "Programming  Project", 3);
                    Users.Where(w => w.Id == id).ToList().ForEach(s => s.modules.Add(PP));
                    Console.WriteLine($"User {code_id} is registed to {PP.Name}");
                    break;
                default:
                    Console.WriteLine("Invalid Module Id");

                    break;


            }
            Console.ReadKey();
            Console.Clear();
            DisplayMenu();


        }


       


        public User AddUser()
        {
            User nu = new User();
            Console.Write("Enter your ID : ");
            nu.Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter your first name : ");
            nu.FirstName = Console.ReadLine();
            Console.Write("Enter your last tname : ");
            nu.LastName = Console.ReadLine();
            Console.Write("Enter your Date of Birth (yyyy/mm//dd) : ");
            nu.Dob = Console.ReadLine();
            Console.Write("Enter your address : ");
            nu.Address = Console.ReadLine();
            Console.WriteLine($"\n \n The user has added");
            
            Console.ReadKey();
            Console.Clear();
            return nu;

        }
        public List<User> DeleteUser(List<User> users)
        {
            Console.WriteLine("Enter the id of user that you want to delete : ");
            int pos = Convert.ToInt32(Console.ReadLine());
            
            //bug in when there is no such a user in list should handle it try catch can be used for this i thinkkk
            try
            {
                var del_user = users.Where(user => user.Id == pos).First();
                while (true)
                {
                    Console.WriteLine("Do you want to delete user (y/n):");
                    string res = Console.ReadLine();
                    if (res == "y")
                    {
                        var new_users = users.Where(user => user.Id != pos).ToList();
                        Console.WriteLine("User deleted");
                        Console.ReadKey();
                        Console.Clear();
                        return new_users;

                    }
                    else if (res == "n")
                    {

                        Console.Clear();
                        return users;

                    }
                    Console.WriteLine("Invalid input");
                }
            }
            catch
            {
                Console.WriteLine("No such a user");
                Console.ReadKey();
                Console.Clear();
                return users;
            }
            //if( del_user != null)
            //{
                
            //    while (true)
            //    {
            //        Console.WriteLine("Do you want to delete user (y/n):");
            //        string res = Console.ReadLine();
            //        if(res == "y")
            //        {
            //            var new_users = users.Where(user => user.Id != pos).ToList(); 
            //            Console.WriteLine("User deleted");
            //            Console.ReadKey();
            //            Console.Clear();
            //            return new_users;
                        
            //        }
            //        else if(res == "n")
            //        {
                        
            //            Console.Clear();
            //            return users;
                        
            //        }
            //        Console.WriteLine("Invalid input");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("No seuch a user");
            //    Console.ReadKey();
            //    Console.Clear();
            //    return users;
            //}
            
        }

        public void DisplayMenu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;

            Console.Clear();
            Console.CursorVisible = false;
            bool running = true;

            while (running)
            {
                Console.SetCursorPosition(ColPos, RowPos);
                int SelectedItem = 0;

                for (int i = 0; i < MenuItems.Count; i++)
                {
                    Console.SetCursorPosition(ColPos, RowPos + i);


                    if (MenuItems[i].IsSelected)
                    {

                        SelectedItem = i;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{i + 1} {MenuItems[i].Title}");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{i + 1} {MenuItems[i].Title}");
                    }
                }

                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.DownArrow)
                {
                    MenuItems[SelectedItem].IsSelected = false;
                    SelectedItem = (SelectedItem + 1) % MenuItems.Count;
                    MenuItems[SelectedItem].IsSelected = true;
                }

                if (key.Key == ConsoleKey.UpArrow)
                {
                    MenuItems[SelectedItem].IsSelected = false;
                    SelectedItem = SelectedItem - 1;
                    if (SelectedItem < 0)
                    {
                        SelectedItem = MenuItems.Count - 1;
                    }

                    MenuItems[SelectedItem].IsSelected = true;
                }

                if (key.Key == ConsoleKey.Enter)
                {
                    Console.SetCursorPosition(2, 0);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine($"You selected {MenuItems[SelectedItem].Title}");


                    switch (SelectedItem)
                    {
                        case 0:
                            

                            Console.Clear();
                            Console.SetCursorPosition(2, 0);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine($"You selected {MenuItems[SelectedItem].Title}");

                            
                            Users.Add(AddUser());
                            break;
                        case 1://select user methods

                            Console.Clear();
                            Console.SetCursorPosition(2, 0);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine($"You selected {MenuItems[SelectedItem].Title}");
                            selectUser(Users);

                            break; 


                        case 2://delete user

                            Console.Clear();
                            Console.SetCursorPosition(2, 0);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine($"You selected {MenuItems[SelectedItem].Title}");
                            Users = DeleteUser(Users);
                            break;

                        
                        case 3:

                            Console.Clear();
                            Console.SetCursorPosition(2, 0);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine($"You selected {MenuItems[SelectedItem].Title}");
                            DisplayAllUsers(Users);
                            break;
                        default:
                            Console.WriteLine("Error");
                            break;
                    }

                    if (MenuItems[SelectedItem].Title == "Quit")
                    {
                        Console.Clear();
                        running = false;
                    }

                }


            }
        }

        public void submenu(int selected_id)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkMagenta;

            Console.Clear();
            Console.CursorVisible = false;
            bool running = true;

            while (running)
            {
                Console.SetCursorPosition(ColPos, RowPos);
                int SelectedItem = 0;

                for (int i = 0; i < SubMenuItems.Count; i++)
                {
                    Console.SetCursorPosition(ColPos, RowPos + i);


                    if (SubMenuItems[i].IsSelected)
                    {

                        SelectedItem = i;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{i + 1} {SubMenuItems[i].Title}");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{i + 1} {SubMenuItems[i].Title}");
                    }
                }

                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.DownArrow)
                {
                    SubMenuItems[SelectedItem].IsSelected = false;
                    SelectedItem = (SelectedItem + 1) % SubMenuItems.Count;
                    SubMenuItems[SelectedItem].IsSelected = true;
                }

                if (key.Key == ConsoleKey.UpArrow)
                {
                    SubMenuItems[SelectedItem].IsSelected = false;
                    SelectedItem = SelectedItem - 1;
                    if (SelectedItem < 0)
                    {
                        SelectedItem = SubMenuItems.Count - 1;
                    }

                    SubMenuItems[SelectedItem].IsSelected = true;
                }

                if (key.Key == ConsoleKey.Enter)
                {
                    Console.SetCursorPosition(2, 0);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine($"You selected {SubMenuItems[SelectedItem].Title}");


                    switch (SelectedItem)
                    {
                        case 0:


                            Console.Clear();
                            Console.SetCursorPosition(2, 0);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine($"You selected {SubMenuItems[SelectedItem].Title}");
                            running = false;
                            Modify_user(selected_id);

                            break;
                        case 1:

                            Console.Clear();
                            Console.SetCursorPosition(2, 0);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine($"You selected {SubMenuItems[SelectedItem].Title}");
                            addModules(selected_id);

                            break;


                        case 2://delete user

                            Console.Clear();
                            Console.SetCursorPosition(2, 0);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine($"You selected {SubMenuItems[SelectedItem].Title}");
                            RemoveModule(selected_id);
                            break;


                        case 3:

                            Console.Clear();
                            Console.SetCursorPosition(2, 0);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine($"You selected {SubMenuItems[SelectedItem].Title}");
                            //Calculate_gpa();
                            break;
                        default:
                            Console.WriteLine("Error");
                            break;
                    }

                    if (MenuItems[SelectedItem].Title == "Quit")
                    {
                        running = false;
                    }

                }


            }

        }


    }
}
