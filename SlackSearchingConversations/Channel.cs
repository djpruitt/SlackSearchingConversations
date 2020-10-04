using System.Collections.Generic;

namespace SlackSearchingConversations
{
    public class Channel
    {
        public string id { get; set; }
        public bool is_channel { get; set; }
        public bool is_group { get; set; }
        public bool is_im { get; set; }
        public string name { get; set; }
        public bool is_shared { get; set; }
        public bool is_org_shared { get; set; }
        public bool is_ext_shared { get; set; }
        public bool is_private { get; set; }
        public bool is_mpim { get; set; }
        public List<object> pending_shared { get; set; }
        public bool is_pending_ext_shared { get; set; }
    }


}
