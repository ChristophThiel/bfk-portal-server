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

            if (request.PayLoad == null)
                return false;

            return true;
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
            foreach (var property in properties)
                if (property.GetValue(payload) == null)
                    return false;

            return true;
        }

        private static bool IsStringValid(string value) =>
            string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);
    }
}
