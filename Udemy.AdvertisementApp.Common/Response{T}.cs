using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.AdvertisementApp.Common
{
    //BU response turu data tasiyan turudur.
    public class Response<T> : Response , IResponse<T>
    {

        //Burada responseType ve message'ı datasız bir sekilde base class'a gonderdik
        public Response(ResponseType responseType,string message) : base(responseType,message) 
        {
        }

        public Response(ResponseType responseType, T data): base(responseType)
        {
            Data = data;
        }

        public Response(T data, List<CustomValidationError> errors) : base(ResponseType.ValidationError)
        {
            Data=data;
            ValidationError = errors;
        }

        public T Data { get; set; }
        public List<CustomValidationError> ValidationError{ get; set; }
    }
}
