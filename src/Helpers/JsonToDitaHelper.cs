using Dita.Services.Mappings;
using System.Dynamic;

namespace Dita.Services.Helpers
{
    public static class JsonToDitaHelper
    {
        public static string id;
        public static string TransformToDita(object input)
        {
            var res = string.Empty;
            dynamic items = input as ExpandoObject;
            if (items == null) items = input as List<ExpandoObject>;
            if (items == null) items = input;

            return Tranform(items);
        }
        public static ElementMapping GetMapping(string key)
        {
            var element = DitaElementMapping.DitMappings.FirstOrDefault(x => string.Equals(x.Value.ContentfullField, key, StringComparison.OrdinalIgnoreCase));
            return element.Value;
        }
        public static string GetXml(string ditaElement, string ditaAttribute, string value, string key)
        {
            if (key == "items") return value;
            if (key == "data") return $"<?xml version=\"1.0\" encoding=\"UTF-8\"?>{value}";
            ditaElement = string.IsNullOrEmpty(ditaElement) && string.IsNullOrEmpty(ditaAttribute) ? "unmappedElement" : ditaElement;
            ditaAttribute = string.IsNullOrEmpty(ditaAttribute) ? "" : ditaAttribute.Replace("@", "");
            var itemId = string.IsNullOrEmpty(id) ? "" : $"id=\"{id}\"";
            if (ditaElement == "map" || ditaElement == "topic")
                return $"\n<!DOCTYPE {ditaElement} PUBLIC \" -//OASIS//DTD DITA Map//EN\" \"output.xml\">\n <{ditaElement} {itemId}>{value}</{ditaElement}>";
            if (ditaAttribute == "id")
            {
                id = value;
                return string.Empty;
            }
            if (!string.IsNullOrEmpty(ditaAttribute) && !ditaAttribute.Contains(":"))
            {
                return $"\n<{ditaElement} {ditaAttribute}=\"{value}\"></{ditaElement}>";
            }
            else if (ditaAttribute.Contains(":"))
                return $"\n<{ditaElement} {ditaAttribute.Split(':')[0]}=\"{ditaAttribute.Split(':')[1]}\">{value}</{ditaElement}>";
            else
                return $"\n<{ditaElement} {ditaAttribute}>{value}</{ditaElement}>";

        }

        public static string Tranform(dynamic items)
        {
            var res = string.Empty;

            foreach (var prop in items)
            {
                if (prop is ExpandoObject)
                {
                    res += Tranform(prop);
                }
                else
                {
                    var mappings = GetMapping(prop.Key) as ElementMapping;

                    if (prop.Value != null && (prop.Value is ExpandoObject || (prop.Value as object).GetType() == typeof(List<object>)))
                    {
                        res += GetXml(mappings != null ? mappings.DitaElemnt : string.Empty,
                    mappings != null ? mappings.DitaAttribute : string.Empty,
                    Tranform(prop.Value), prop.Key);
                    }
                    else
                    {
                        res += GetXml(mappings != null ? mappings.DitaElemnt : string.Empty,
                   mappings != null ? mappings.DitaAttribute : string.Empty,
                   prop.Value != null ? prop.Value.ToString() : "", prop.Key);
                    }

                }

            }
            return res;
        }
    }
}
