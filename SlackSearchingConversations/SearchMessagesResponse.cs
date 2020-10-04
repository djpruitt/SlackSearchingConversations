namespace SlackSearchingConversations
{
    public class SearchMessagesResponse
    {
        public bool ok { get; set; }
        public string query { get; set; }
        public SearchResultMessages messages { get; set; }
    }


}
