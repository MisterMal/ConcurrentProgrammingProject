namespace Data
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