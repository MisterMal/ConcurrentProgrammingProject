using Logic;
using System.Collections.ObjectModel;

namespace Model
{
    public abstract class ModelApi
    {
        private ObservableCollection<BallModel> ballModelsCollection = new ObservableCollection<BallModel>();

        public static ModelApi CreateApi(LogicApi logicLayer = default)
        {
            return new ModelLayer(logicLayer ?? LogicApi.CreateApi());
        }

        public abstract void Start();
        public abstract void Visualisation(float xSpeed, float ySpeed, int radius, int howMany);

        public ObservableCollection<BallModel> BallModelsCollection
        {
            get => BallModelsCollection;
            set => BallModelsCollection = value;
        }

        public class ModelLayer : ModelApi
        {
            private readonly LogicApi logicApi;

            public ModelLayer(LogicApi logic)
            {
                logicApi = logic;
            }

            public override void Start()
            {
                logicApi.Start();
            }

            public override void Visualisation(float xSpeed, float ySpeed, int radius, int howMany)
            {
                logicApi.BallsCreating((float)0.5, (float)0.5, 10, 5);
            }
        }
    }

    


}
