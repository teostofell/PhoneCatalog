using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogApp.BLL.BusinessModel
{
    public class OperationDetails
    {
        public string Message { get; set; }
        public bool isSucceed { get; set; }

        public OperationDetails(bool isSucceed, string message)
        {
            Message = message;
            this.isSucceed = isSucceed;
        }
    }
}
