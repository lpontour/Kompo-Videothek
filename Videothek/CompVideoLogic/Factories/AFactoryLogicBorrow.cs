namespace VideoLogic.Factories
{
    public abstract class AFactoryLogicBorrow
    {
		public static void Create(ILogic logic, IDataLoan dataLoan) 
		{
			if(logic is CLogic)
			{
				(logic as CLogic).Loan = new CLogicLoan(dataLoan);
			}      
		} 
    }
}
