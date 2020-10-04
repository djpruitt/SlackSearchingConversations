using System.Collections.Generic;

namespace SlackSearchingConversations
{
    public class Block
    {
        public string type { get; set; }
        public string block_id { get; set; }
        public List<Element> elements { get; set; }
    }


}
