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
                throw new System.NotImplementedException();
            }
        }

    }

}