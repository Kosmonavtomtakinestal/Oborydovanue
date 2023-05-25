using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oborydovanie_Client.DataBase
{
    public class NewClient
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Passport { get; set; }
        public string Phone { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
    }
}
