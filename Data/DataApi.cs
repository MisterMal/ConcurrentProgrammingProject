using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class DataApi
    {
        public static DataApi CreateAPI()
        {
            return new DataLayer();
        }

        public class DataLayer : DataApi
        {
            public DataLayer()
            {

            }
        }
    }


}
