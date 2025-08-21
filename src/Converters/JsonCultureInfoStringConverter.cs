using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace KebabGGbab.Json.Converters
{
    public class JsonCultureInfoStringConverter : JsonConverter<CultureInfo>
    {
        public override CultureInfo? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string? cultureName = reader.GetString();

            if (cultureName == null)
            {
                return null;
            }

            return CultureInfo.GetCultureInfo(cultureName);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Проверить аргументы или открытые методы", Justification = "<Ожидание>")]
        public override void Write(Utf8JsonWriter writer, CultureInfo value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.Name);
        }
    }
}
