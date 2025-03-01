using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TL
{
    public class CustomersTL
    {
        private int id;
        private string name;
        private int age;
        private string gender;
        private string phone;
        private DateTime lastDateVisited;
        private string lastMedicalExamination;
        private string status;

        public CustomersTL(int id, string name, int age, string gender, string phone)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.gender = gender;
            this.phone = phone;
        }

        public CustomersTL(int id, string name, int age, string gender, string phone, DateTime lastDateVisited, string lastMedicalExamination, string status)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.gender = gender;
            this.phone = phone;
            this.lastDateVisited = lastDateVisited;
            this.lastMedicalExamination = lastMedicalExamination;
            this.status = status;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Phone { get => phone; set => phone = value; }
        public DateTime LastDateVisited { get => lastDateVisited; set => lastDateVisited = value; }
        public string LastMedicalExamination { get => lastMedicalExamination; set => lastMedicalExamination = value; }
        public string Status { get => status; set => status = value; }
    }
}
