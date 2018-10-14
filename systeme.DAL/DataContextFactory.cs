using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace systeme.DAL
{
    public class DataContextFactory
    {
        private static DataClasses1DataContext dataContext;
        public static DataClasses1DataContext DataContext
        {
            get
            {
                if (dataContext == null)
                    dataContext = new DataClasses1DataContext();
                return dataContext;
            }
        }   

    }

}


