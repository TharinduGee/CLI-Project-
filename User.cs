using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;



namespace CLI_Project
{
    public class User
    {

        private int id;
        private string firstName;
        private string lastName;
        private string dob;
        private string address;
     
        

        public int Id { get { return id; } set { id = value;  } }
        public string FirstName { get { return firstName; } set {firstName = value ; } }
        public string LastName { get; set; }
        public string Dob { get; set; }
        public string Address { get; set; }

        public List<Modules> modules = new List<Modules>();

        public User()
        {
            Id = 0;
            FirstName = null;
            LastName = null;
            Dob = null;
            Address = null;
        }


        public User(int id , string firstname,string lastname,string dob,string address)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            Dob = dob;
            Address = address; 

        }

        //public double calculate_gpa(User user)
        //{
        //    double point = 0;
        //    double cred = 0;
        //    foreach(var module in user.modules)
        //    {
        //        point = point + (module.Grade_Point) + (module.Credit);
        //        cred += module.Credit;
        //    }
        //    double gpa =point/cred;
        //    return gpa;
        //}


       

    }

    
}
