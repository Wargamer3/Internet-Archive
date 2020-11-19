using System;
using System.Threading.Tasks;
using Hayden.Models;

namespace Api
{
    public enum YotsubaResponseType
    {
        Ok,
        NotModified,
        NotFound
    }

    public struct ApiResponse<T>
    {
        public T Reponse;
        public YotsubaResponseType ResponseType;

        public ApiResponse(T Response, YotsubaResponseType ResponseType)
        {
            this.Reponse = Response;
            this.ResponseType = ResponseType;
        }
    }
}
