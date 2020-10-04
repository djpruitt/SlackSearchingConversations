using System.Collections.Generic;

namespace SlackSearchingConversations
{
    public class Match
    {
        public string iid { get; set; }
        public string team { get; set; }
        public Channel channel { get; set; }
        public string type { get; set; }
        public string user { get; set; }
        public string username { get; set; }
        public string ts { get; set; }
        public List<Block> blocks { get; set; }
        public string text { get; set; }
        public string permalink { get; set; }
        public bool no_reactions { get; set; }
    }


}
