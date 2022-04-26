using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class DataApi
    {
        public abstract void Connect();

        public static DataApi CreateAPI()
        {
            return new DataLayer();
        }

        internal class DataLayer : DataApi
        {
            public override void Connect()
            {
                throw new NotImplementedException();
            }
        }
    }


}