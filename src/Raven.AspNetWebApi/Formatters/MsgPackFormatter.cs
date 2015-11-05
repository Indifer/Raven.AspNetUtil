using MsgPack.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;

namespace Raven.AspNetWebApi.Formatters
{
    public class MsgPackFormatter : MediaTypeFormatter
    {
        public override bool CanReadType(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            return true;
        }

        public override bool CanWriteType(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            return true;
        }


        public override Task<object> ReadFromStreamAsync(Type type, Stream readStream, System.Net.Http.HttpContent content, IFormatterLogger formatterLogger)
        {
            var serializer = SerializationContext.Default.GetSerializer(type);
            var obj = serializer.Unpack(readStream);
            return Task.FromResult(obj);
        }
        

        public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, System.Net.Http.HttpContent content, TransportContext transportContext)
        {
            var serializer = SerializationContext.Default.GetSerializer(type);
            serializer.Pack(writeStream, value);
            return writeStream.FlushAsync();
        }
    }
}
