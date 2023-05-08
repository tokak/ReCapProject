using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Ultities.Result
{
    //Temel voidler için başlangıç
    public interface IResult
    {
        //get : sadece okunabilirlik set: üzerine yazmak için kullanırız.

        bool Success { get; }
        string Message { get; }
    }
}
