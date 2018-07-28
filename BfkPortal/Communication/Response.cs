using System.Net;

namespace BfkPortal.Models
{
    public class Response
    {
        public HttpStatusCode Code { get; set; }

        public object Payload { get; set; }

        public Response()
        {
            this.Code = HttpStatusCode.OK;
            this.Payload = new object();
        }

        public Response(HttpStatusCode code, object payload)
        {
            this.Code = code;
            this.Payload = payload;
        }
    }
}
