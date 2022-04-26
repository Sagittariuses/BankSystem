using BankSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Classes
{
    public class DBConnect
    {
        private static BankDBEntities ConObj;
        public static BankDBEntities GetContext()
        {
            if (ConObj == null)
                ConObj = new BankDBEntities();
            return ConObj;

        }
    }
}
