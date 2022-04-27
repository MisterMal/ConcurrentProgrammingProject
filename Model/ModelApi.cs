using Logic;
using System.Collections.ObjectModel;

namespace Model
{
    public abstract class ModelApi
    {
        private ObservableCollection<IBallModel> ballModelsCollection = new ObservableCollection<IBallModel>();

        public static ModelApi CreateApi(LogicApi logic = default)
        {
            return new ModelLayer(logic ?? LogicApi.CreateApi());
        }
        public abstract void Visualisation(float xSpeed, float ySpeed, int radius, int howMany);

        public ObservableCollection<IBallModel> BallModelsCollection
        {
            get => ballModelsCollection;
            set => ballModelsCollection = value;
        }

        public class ModelLayer : ModelApi
        {
            private readonly LogicApi logicApi;

            public ModelLayer(LogicApi logic)
            {
                logicApi = logic;
            }


            public override void Visualisation(float xSpeed, float ySpeed, int radius, int howMany)
            {
  
                logicApi.BallsCreating(1, 1, radius, howMany);
                foreach (IBall b in logicApi.GetBallList())
                {
                    ballModelsCollection.Add(new BallModel(b));
                }

                logicApi.Start();
            }
        }

        static public void Main()
        {

        }
    }

    


}
