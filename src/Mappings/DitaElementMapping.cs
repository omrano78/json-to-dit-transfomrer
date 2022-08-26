namespace Dita.Services.Mappings
{
    public static class DitaElementMapping
    {
        /// <summary>
        /// Represents mapping between each property and its dita equivalent 
        /// </summary>
        public static Dictionary<string, ElementMapping> DitMappings
        {
            get
            {
                var mappings = new Dictionary<string, ElementMapping>();
                mappings.Add("Article", new ElementMapping("map", "", "articleDitaCollection"));
                mappings.Add("EditorsNote", new ElementMapping("concept", "", "editorsNote"));
                mappings.Add("Profile", new ElementMapping("author", "", "profile"));
                mappings.Add("Image", new ElementMapping("image", "", "image"));
                mappings.Add("ImageType", new ElementMapping("othermeta", "@name:imageType", "imageType"));
                mappings.Add("MediaLink", new ElementMapping("xref", "@href", "url"));
                mappings.Add("AltText", new ElementMapping("alt", "", "altText"));
                mappings.Add("Identifier", new ElementMapping("", "@id", "identifier"));
                mappings.Add("PublishDate", new ElementMapping("created", "@date", "publishDate"));
                mappings.Add("RevisionDate", new ElementMapping("revised", "@revised", "revisionDate"));
                mappings.Add("Title", new ElementMapping("title", "", "title"));
                mappings.Add("Caption", new ElementMapping("title", "", "caption"));
                mappings.Add("SearchPriority", new ElementMapping("othermeta", "@name:searchPriority", "searchPriority"));
                mappings.Add("Role", new ElementMapping("othermeta", "@name:role", "role"));
                mappings.Add("ExpertiseArea", new ElementMapping("othermeta", "@name:expertiseArea", "expertiseArea"));
                mappings.Add("FirstName", new ElementMapping("firstname", "", "firstName"));
                mappings.Add("LastName", new ElementMapping("lastname", "", "lastName"));
                mappings.Add("Section", new ElementMapping("concept", "", "sectionCollection"));
                mappings.Add("HighlightText", new ElementMapping("ph", "", "highlightText"));
                mappings.Add("Paragraph", new ElementMapping("p", "", "paragraph"));
                mappings.Add("FullBlockGroup", new ElementMapping("section  ", "", "paragraphesCollection"));
                mappings.Add("positionTitle", new ElementMapping("othermeta", "@name:position title", "positionField"));

                return mappings;
            }
        }
    }
    public class ElementMapping
    {
        public ElementMapping(string ditaElemnt, string ditaAttribute, string contentfullField)
        {
            DitaElemnt = ditaElemnt;
            DitaAttribute = ditaAttribute;
            ContentfullField = contentfullField;
        }

        public string DitaElemnt { get; set; }
        public string DitaAttribute { get; set; }
        public string ContentfullField { get; set; }
    }
}
