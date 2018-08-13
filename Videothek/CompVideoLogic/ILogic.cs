namespace VideoLogic
{
    public interface ILogic
    {
		ILogicSearch Search {get;}
		ILogicLoan Loan {get;}
		void InitApp(ref int _nVideos, out object[] _arrayMakers);
    }
}
