using static Projects.Models.STSKnowledgebase;

namespace Projects.Models
{
    public class STSKnowledgebase
    {


        public class Rootobject
        {
            public JsonData[] Property1 { get; set; }
        }

        public class JsonData
        {
            public string internalName { get; set; }
            public string text { get; set; }
            public string tag { get; set; }
            public string size { get; set; }
            public Headerdescription headerDescription { get; set; }
            public string cardName { get; set; }
            public string subheading { get; set; }
            public Description description { get; set; }
            public Thumbnail thumbnail { get; set; }
            public string sectionTitle { get; set; }
            public Card[] cards { get; set; }
            public Richtext richText { get; set; }
            public string fileName { get; set; }
            public string fileType { get; set; }
            public string fileSize { get; set; }
            public string fileDescription { get; set; }
            public Documentthumbnail documentThumbnail { get; set; }
            public Documentfile documentFile { get; set; }
            public string sectionDescrition { get; set; }
        }

        public class Headerdescription
        {
            public Data data { get; set; }
            public Content[] content { get; set; }
            public string nodeType { get; set; }
        }

        public class Data
        {
        }

        public class Content
        {
            public Data1 data { get; set; }
            public Content1[] content { get; set; }
            public string nodeType { get; set; }
        }

        public class Data1
        {
        }

        public class Content1
        {
            public Data2 data { get; set; }
            public object[] marks { get; set; }
            public string value { get; set; }
            public string nodeType { get; set; }
            public Content2[] content { get; set; }
        }

        public class Data2
        {
            public string uri { get; set; }
        }

        public class Content2
        {
            public Data3 data { get; set; }
            public object[] marks { get; set; }
            public string value { get; set; }
            public string nodeType { get; set; }
        }

        public class Data3
        {
        }

        public class Description
        {
            public Data4 data { get; set; }
            public Content3[] content { get; set; }
            public string nodeType { get; set; }
        }

        public class Data4
        {
        }

        public class Content3
        {
            public Data5 data { get; set; }
            public Content4[] content { get; set; }
            public string nodeType { get; set; }
        }

        public class Data5
        {
        }

        public class Content4
        {
            public Data6 data { get; set; }
            public object[] marks { get; set; }
            public string value { get; set; }
            public string nodeType { get; set; }
            public Content5[] content { get; set; }
        }

        public class Data6
        {
            public string uri { get; set; }
        }

        public class Content5
        {
            public Data7 data { get; set; }
            public object[] marks { get; set; }
            public string value { get; set; }
            public string nodeType { get; set; }
        }

        public class Data7
        {
        }

        public class Thumbnail
        {
            public Sys sys { get; set; }
        }

        public class Sys
        {
            public string type { get; set; }
            public string linkType { get; set; }
            public string id { get; set; }
        }

        public class Richtext
        {
            public Data8 data { get; set; }
            public Content6[] content { get; set; }
            public string nodeType { get; set; }
        }

        public class Data8
        {
        }

        public class Content6
        {
            public Data9 data { get; set; }
            public Content7[] content { get; set; }
            public string nodeType { get; set; }
        }

        public class Data9
        {
        }

        public class Content7
        {
            public Data10 data { get; set; }
            public object[] marks { get; set; }
            public string value { get; set; }
            public string nodeType { get; set; }
        }

        public class Data10
        {
        }

        public class Documentthumbnail
        {
            public Sys1 sys { get; set; }
        }

        public class Sys1
        {
            public string type { get; set; }
            public string linkType { get; set; }
            public string id { get; set; }
        }

        public class Documentfile
        {
            public Sys2 sys { get; set; }
        }

        public class Sys2
        {
            public string type { get; set; }
            public string linkType { get; set; }
            public string id { get; set; }
        }

        public class Card
        {
            public Sys3 sys { get; set; }
        }

        public class Sys3
        {
            public string type { get; set; }
            public string linkType { get; set; }
            public string id { get; set; }
        }

        //public string Laptop { get; set; }
        //public string Broadband { get; set; }
    }

    public class Cards
    {
        public string cardTitle { get; set; }
        public string cardDescription { get; set; }
        public string cardLink { get; set; }
        public string publishedDate { get; set; }
        public CardsThumbnail thumbnail { get; set; }
        public Sys1 sys { get; set; }
        public Metadata metadata { get; set; }
    }

    public class CardsThumbnail
    {
        public Sys sys { get; set; }
    }

    public class CardsSys
    {
        public string type { get; set; }
        public string linkType { get; set; }
        public string id { get; set; }
    }

    public class CardsSys1
    {
        public Space space { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public Environment environment { get; set; }
        public int revision { get; set; }
        public Contenttype contentType { get; set; }
        public string locale { get; set; }
    }

    public class Space
    {
        public CardsSys2 sys { get; set; }
    }

    public class CardsSys2
    {
        public string type { get; set; }
        public string linkType { get; set; }
        public string id { get; set; }
    }

    public class Environment
    {
        public CardsSys3 sys { get; set; }
    }

    public class CardsSys3
    {
        public string id { get; set; }
        public string type { get; set; }
        public string linkType { get; set; }
    }

    public class Contenttype
    {
        public CardsSys4 sys { get; set; }
    }

    public class CardsSys4
    {
        public string type { get; set; }
        public string linkType { get; set; }
        public string id { get; set; }
    }

    public class Metadata
    {
        public object[] tags { get; set; }
    }
    public class Jsondatafinal
    {
        public string Page { get; set; }
        public string cards { get; set; }
        public string image { get; set; }
    }

    public class Finaldataview
    {
        public List<JsonData> Page { get; set; }
        public List<Cards> cards { get; set; }
        public List<string> image { get; set; }
    }
    public class ComponentTitle
    {
        public string internalName { get; set; }
        public string Text { get; set; }
    }
}
