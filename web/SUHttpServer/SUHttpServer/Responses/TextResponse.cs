using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SUHttpServer.HTTP;

namespace SUHttpServer.Responses
{
    public class TextResponse : ContentResponse
    {
        public TextResponse(string content, Action<Request,Response> preRenderAction = null)
            : base(content, ContentType.PlainText, preRenderAction)
        {
        }
    }
}
