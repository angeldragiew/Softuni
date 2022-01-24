using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SUHttpServer.HTTP;

namespace SUHttpServer.Responses
{
    public class TextFileResponse : Response
    {
        public string FileName { get; init; }

        public TextFileResponse(string filename)
            : base(StatusCode.OK)
        {
            FileName = filename;
            this.Headers.Add(Header.ContentType, ContentType.PlainText);
        }

        public override string ToString()
        {
            if (File.Exists(FileName))
            {
                this.Body = File.ReadAllTextAsync(this.FileName).Result;

                var fileBytesCount = new FileInfo(this.FileName).Length;
                this.Headers.Add(Header.ContentLength, fileBytesCount.ToString());

                this.Headers.Add(Header.ContentDisposition, $"attachment; filename=\"{FileName}\"");
            }
            return base.ToString();
        }
    }
}
