using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoRecruitment.Core.OperationResults
{
    public class OperationResult
    {
        public OperationResultType OperationResultType { get; set; }
        public string ErrorMessage { get; set; }
    }
}
