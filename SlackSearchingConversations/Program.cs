using System;
using System.Threading.Tasks;

namespace SlackSearchingConversations
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            const string TOKEN = "slack-auth-token-goes-here";  // slack oauth token

            var input = GetUserInput();

            var slackApiClient = new SlackApiClient(TOKEN);

            var response = await slackApiClient.SearchForMessagesAsync(input);

            var messages = response.messages;

            ConversationRepliesResponse convoAndReplies = null;

            Console.WriteLine();
            Console.WriteLine(string.Format("SEARCH QUERY: {0}", input));
            Console.WriteLine();

            foreach (var m in messages.matches)
            {
                convoAndReplies = await slackApiClient.GetConversationAndRepliesAsync(m.channel.id, m.ts);

                Console.WriteLine(string.Format("SEARCH MATCH: ts = {0} | Text = {1}", m.ts, m.text));
            }

            if(convoAndReplies == null || convoAndReplies.messages == null)
            {
                return;
            }

            foreach (var m in convoAndReplies.messages)
            {
                Console.WriteLine(string.Format("MESSAGE: ts = {0} | Text = {1} | thread ts = {2} | Message Type = {3}", m.ts, m.text, m.thread_ts, string.Equals(m.text, m.thread_ts) ? "Parent Message" : "Reply Message"));
            }
        }

        private static string GetUserInput()
        {
            Console.WriteLine("Message text search: ");
            var input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Input invalid.");

                GetUserInput();
            }

            return input;
        }
    }
}
