using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result:IResult
    {
       

        public Result(bool success, string message):this(success)    //çok önemli hareket
        {
            Message = message; //getler constructor içinde set edilebilir
            
            
        }

        public Result(bool success)
        {
            Success = success;
        }


        public bool Success { get; }
        public string Message { get; }
    }
}
