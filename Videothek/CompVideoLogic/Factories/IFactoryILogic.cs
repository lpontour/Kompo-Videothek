namespace VideoLogic.Factories
{
    public interface IFactoryILogic
    {
		ILogic Create(IData data);
    }
}
