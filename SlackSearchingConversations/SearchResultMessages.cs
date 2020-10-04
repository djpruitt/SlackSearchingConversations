using System.Collections.Generic;

namespace SlackSearchingConversations
{
    public class SearchResultMessages
    {
        public int total { get; set; }
        public Pagination pagination { get; set; }
        public Paging paging { get; set; }
        public List<Match> matches { get; set; }
    }


}
