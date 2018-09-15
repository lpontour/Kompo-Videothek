namespace VideoLogic.Factories
{
    public interface IFactoryIDialog
    {
		//Erstellt ein neues der Factory eintsprechendes Interface
		IDialog Create(ILogic logic);
    }
}
