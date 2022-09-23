using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace FeedMe.Api.Configuration
{
    [ExcludeFromCodeCoverage]
    public class DynamoJsonSerializeConverter<T> : IPropertyConverter
    {
        public object FromEntry(DynamoDBEntry entry)
        {
            var primitive = entry as Primitive;
               
            return JsonConvert.DeserializeObject<T>(primitive);
        }

        public DynamoDBEntry ToEntry(object value)
        {
            return new Primitive(JsonConvert.SerializeObject(value));
        }
    }
}
