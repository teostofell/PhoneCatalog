namespace CatalogApp.BLL.BusinessModel
{
    public class OperationDetails
    {
        public string Message { get; }
        public bool IsSucceed { get; }

        public OperationDetails(bool isSucceed, string message)
        {
            Message = message;
            IsSucceed = isSucceed;
        }
    }
}
