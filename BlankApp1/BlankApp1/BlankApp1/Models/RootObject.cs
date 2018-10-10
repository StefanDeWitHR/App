using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{

    public class Enclosure
    {
        public string url { get; set; }
        public string type { get; set; }
        public string length { get; set; }
    }

    public class Item
    {
        public bool sticky { get; set; }
        public DateTime pubDate { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string link { get; set; }
        public Guid UniqueId { get; set; }
        public Enclosure enclosure { get; set; }
    }

    public class Channel
    {
        public string title { get; set; }
        public string link { get; set; }
        public string language { get; set; }
        public string description { get; set; }
        public List<Item> items { get; set; }
    }

    public class Rss
    {
        public Channel channel { get; set; }

        public string _version { get; set; }
    }   

}
