using System.Collections.Generic;

namespace SlackSearchingConversations
{
    public class ConversationRepliesResponse
    {
        public List<Message> messages { get; set; }
        public bool has_more { get; set; }
        public bool ok { get; set; }
    }
}
