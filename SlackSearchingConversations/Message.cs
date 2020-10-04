using System.Collections.Generic;

namespace SlackSearchingConversations
{
    public class Message
    {
        public string client_msg_id { get; set; }
        public string type { get; set; }
        public string text { get; set; }
        public string user { get; set; }
        public string ts { get; set; }
        public string team { get; set; }
        public List<Block> blocks { get; set; }
        public string thread_ts { get; set; }
        public string parent_user_id { get; set; }
    }
}
