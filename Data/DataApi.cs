<<<<<<< HEAD
﻿namespace Data
{
    public abstract class DataApi
    {
        public static DataApi CreateAPI()
        {
            return new DataLayer();
        }

        internal class DataLayer : DataApi
        {
            public DataLayer()
            {

            }
        }

        static public void Main()
        {

        }


    }


}
=======
﻿using System;
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
>>>>>>> 4884d2ec8e4cfd94eb8daa6223aa275d4f88f2a7
