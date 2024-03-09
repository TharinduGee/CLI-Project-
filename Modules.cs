using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI_Project
{
    public class Modules
    {
        private int id;
        private int credit;
        private int grade_point;
        private string grade;
        private string name;

        public int Id { get { return id; } set {  id = value; } }
        public int Credit { get {  return credit; } set { credit = value;} }
        public int Grade_Point { get {  return grade_point; } set {  grade_point = value; } }
        public string Grade { get; set; }
        public string Name { get; set; }

           

        public Modules(int id, string name,int credit)
        {
            Id = id;
            Credit = credit;
            Grade_Point = 0;
            Name = name;
        }




    }
}
