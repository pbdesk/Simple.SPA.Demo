using PBDeskDemos.SimpleSPA.DAL.DataModels;
using PBDeskDemos.SimpleSPA.DAL.EFRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBDeskDemos.SimpleSPA.DAL
{
    public class RepoHelper : UOWBase
    {
       

        public RepoHelper()
        {
            context = new CustomerContext();
        }

        private Repository<Customer> _Customers;
        public Repository<Customer> Customers
        {
            get
            {
                if (_Customers == null)
                {
                    _Customers = new Repository<Customer>(context);
                }
                return _Customers;
            }
        }

       
    }
}
