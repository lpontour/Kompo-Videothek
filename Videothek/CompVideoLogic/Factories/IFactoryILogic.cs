namespace VideoLogic.Factories
{
    public interface IFactoryILogic
    {
		//Erstellt ein neues der Factory eintsprechendes Interface
		ILogic Create(IData data);
    }
}
