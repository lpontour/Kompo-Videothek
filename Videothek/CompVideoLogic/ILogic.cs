namespace VideoLogic
{
    public interface ILogic
    {
		//Das Video Interface
		ILogicSearch Search {get;}
		ILogicLoan Loan {get;}
    }
}
