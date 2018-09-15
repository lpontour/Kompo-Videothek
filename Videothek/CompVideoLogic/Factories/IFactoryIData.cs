namespace VideoLogic.Factories
{
    public interface IFactoryIData
    {
		//Erstellt ein neues der Factory eintsprechendes Interface
		IData Create(string connection);
    }
}
