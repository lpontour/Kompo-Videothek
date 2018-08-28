namespace VideoData.Access
{
    internal class CData : AData
    {
        #region ctor
        internal CData(string connection) : base(connection)
        {
            _provider = "System.Data.OleDb";
            _dataSearch = new CDataSearch(this);
            _dataLoan = new CDataLoan(this);
        }
        #endregion
    }
}