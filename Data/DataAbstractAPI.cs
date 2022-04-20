using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class DataAbstractAPI
    {
        public class Data : DataAbstractAPI
        {
            public Data()
            {

            }
        }

        public static DataAbstractAPI CreateAPI()
        {
            return new Data();
        }
    }


}
