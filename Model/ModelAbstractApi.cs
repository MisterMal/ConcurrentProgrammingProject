using Logic;


namespace Model
{
    public abstract class ModelApi
    {
        public static ModelApi CreateApi(ModelApi logicLayer = default)
        {
            return new ModelLayer(logicLayer ?? LogicApi.CreateApi());
        }
    }
}
