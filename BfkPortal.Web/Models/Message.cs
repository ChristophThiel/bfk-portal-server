using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BfkPortal.Web.Models
{
    public class Message
    {
        public string Action { get; set; }
        
        public object PayLoad { get; set; }

        public Message()
        {
            this.Action = "";
            this.PayLoad = new object();
        }

        public Message(string action, object payLoad)
        {
            this.Action = action;
            this.PayLoad = payLoad;
        }

        public override string ToString()
        {
            var settings = new JsonSerializerSettings {ContractResolver = new CamelCasePropertyNamesContractResolver()};
            return JsonConvert.SerializeObject(this, settings);
        }

        public static Message Error(string action) => new Message(action.ToLower(), new {Success = false});
    }
}
