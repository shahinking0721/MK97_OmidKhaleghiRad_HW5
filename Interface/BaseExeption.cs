using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesRuleProject.Interface
{
    public class BaseExeption : SystemException
    {
        string mas=string.Empty;
        public BaseExeption(string maasage)
        {
            mas = maasage;
        }

        public override string Message => mas;
    }
}
   
       
  
        
           

        
    


