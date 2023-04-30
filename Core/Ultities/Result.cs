using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Ultities
{
    public class Result : IResult
    {
        public Result(bool success,string message):this(success)
        {
            Message = message;
            //Success= succes; altta kodu eşitliyoruz.
        }
        //Mesaj boş olursa
        public Result(bool success)
        {
            Success = success;
        }
        public bool Success { get; }

        public string Message { get; }
    }
}
