using ElectronicTrade.BusinessLayer.OperationManagers;
using ElectronicTrade.DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicTrade.BusinessLayer.TestingManagers
{
    public class Testing
    {
        public void DatabaseTestMethod()
        {
            DatabaseContext db = new DatabaseContext();
            db.db_member.ToList();
        }
    }
}
