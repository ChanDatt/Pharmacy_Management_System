using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TL
{
    public class StaffsTL
    {
        int id;
        string name, note, phone, status, address;
        decimal salary;

        public StaffsTL(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
        public StaffsTL(int id, string name, string note, string phone, string status, decimal salary)
        {
            this.Id = id;
            this.Name = name;
            this.Note = note;
            this.Phone = phone;
            this.Status = status;
            this.Salary = salary;
        }

        public StaffsTL(int id, string name, string note, string phone, string status, decimal salary, string address) {
            this.Id = id;
            this.Name = name;
            this.Note = note;
            this.Phone = phone;
            this.Status = status;
            this.Salary = salary;
            this.Address = address;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Note { get => note; set => note = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Status { get => status; set => status = value; }
        public decimal Salary { get => salary; set => salary = value; }
        public string Address { get => address; set => address = value; }
    }
}
