using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace Kinoheld.Api.Client.Helper
{
    public class NewtonsoftJsonSerializer : ISerializer, IDeserializer
    {
        private readonly Newtonsoft.Json.JsonSerializer m_serializer;

        public NewtonsoftJsonSerializer(Newtonsoft.Json.JsonSerializer serializer)
        {
            this.m_serializer = serializer;
        }

        public string ContentType
        {
            get => "application/json";
            set { }
        }

        public string DateFormat { get; set; }

        public string Namespace { get; set; }

        public string RootElement { get; set; }

        public string Serialize(object obj)
        {
            using (var stringWriter = new StringWriter())
            {
                using (var jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    m_serializer.Serialize(jsonTextWriter, obj);

                    return stringWriter.ToString();
                }
            }
        }

        public T Deserialize<T>(RestSharp.IRestResponse response)
        {
            var content = response.Content;

            using (var stringReader = new StringReader(content))
            {
                using (var jsonTextReader = new JsonTextReader(stringReader))
                {
                    return m_serializer.Deserialize<T>(jsonTextReader);
                }
            }
        }

        public static NewtonsoftJsonSerializer Default =>
            new NewtonsoftJsonSerializer(new Newtonsoft.Json.JsonSerializer
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
    }
}