using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SharedLibrary.Dtos
{
    public class ResponseDto<T> where T : class
    {
        public T Data { get; private set; }
        public int StatusCode { get; private set; }

        [JsonIgnore]
        public bool IsScuccessful { get; set; }
        public ErrorDto Error { get; set; }
        public static ResponseDto<T> Success(T data, int statusCode)
        {
            return new ResponseDto<T> { Data = data, StatusCode = statusCode, IsScuccessful= true };

        }

        // Update veya silmede başka bir veri dönmeye gerek yok.
        public static ResponseDto<T> Success(int statusCode)
        {
            return new ResponseDto<T> { StatusCode = statusCode , IsScuccessful=true };
        }

        public static ResponseDto<T> Fail(ErrorDto errorDto,int statusCode)
        {
            return new ResponseDto<T> { Error = errorDto, StatusCode = statusCode , IsScuccessful=false};
        }

        public static ResponseDto<T> Fail(string errorMessage,int statusCode,bool isShow)
        {
            var errorDto = new ErrorDto(errorMessage, isShow);

            return new ResponseDto<T> { Error = errorDto,StatusCode = statusCode , IsScuccessful = false };
        }
    }
}
