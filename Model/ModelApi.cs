using Logic;
using System.Collections.ObjectModel;

namespace Model
{
    public abstract class ModelApi
    {
        private ObservableCollection<BallModel> ballModelsCollection = new ObservableCollection<BallModel>();

        public static ModelApi CreateApi(LogicApi logic = default)
        {
            return new ModelLayer(logic ?? LogicApi.CreateApi());
        }
        public abstract void Visualisation(float xSpeed, float ySpeed, int radius, int mass, int numberOfBalls);
        public abstract void Stop();
        public abstract void Start();

        public ObservableCollection<BallModel> BallModelsCollection
        {
            get => ballModelsCollection;
            set => ballModelsCollection = value;
        }

        internal class ModelLayer : ModelApi
        {
            private readonly LogicApi logicApi;

            public ModelLayer(LogicApi logic)
            {
                logicApi = logic;
            }


            public override void Visualisation(float xSpeed, float ySpeed, int radius, int mass, int numberOfBalls)
            {
                Stop();
                logicApi.BallsCreating(radius, mass, numberOfBalls);

                //ballModelsCollection.Clear();

                foreach (LogicBall ball in logicApi.GetBalls())
                {
                    ballModelsCollection.Add(new BallModel(ball));
                }

                Start();
            }

            public override void Stop()
            {
                logicApi.Stop();
            }

            public override void Start()
            {
                logicApi.Start();
            }
        }

    }

    


}
