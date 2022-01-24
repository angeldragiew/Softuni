using SUHttpServer.HTTP;

namespace SUHttpServer.Responses
{
    public class UnathorizedResponse : Response
    {
        public UnathorizedResponse()
            : base(StatusCode.Unauthorized)
        {
        }
    }
}
