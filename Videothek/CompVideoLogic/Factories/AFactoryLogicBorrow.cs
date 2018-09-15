namespace VideoLogic.Factories
{
    public abstract class AFactoryLogicBorrow
    {
		//Erstellt eine neue der Factory eintsprechende Klasse
		public static void Create(ILogic logic, IDataLoan dataLoan) 
		{
			if(logic is CLogic)
			{
				(logic as CLogic).Loan = new CLogicLoan(dataLoan);
			}      
		} 
    }
}
