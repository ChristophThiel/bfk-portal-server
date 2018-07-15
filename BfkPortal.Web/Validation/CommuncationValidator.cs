using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using BfkPortal.Web.Models;
using Newtonsoft.Json;

namespace BfkPortal.Web.Validation
{
    public class CommuncationValidator
    {
        public static bool ValidateHeader(string token)
        {
            // TODO Token validation
            return true;
        }

        public static bool ValidateBody(Message request)
        {
            if (request == null)
                return false;

            if (IsStringValid(request.Action))
                return false;

            return request.PayLoad != null;
        }

        public static bool ValidatePayload(string json, dynamic definition)
        {
            object payload;
            try
            {
                var settings = new JsonSerializerSettings {MissingMemberHandling = MissingMemberHandling.Error};
                payload = JsonConvert.DeserializeAnonymousType(json, definition, settings);
            }
            catch (JsonException)
            {
                return false;
            }

            var properties = payload.GetType().GetProperties();
            return properties.All(property => property.GetValue(payload) != null);
        }

        private static bool IsStringValid(string value) =>
            string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);
    }
}
