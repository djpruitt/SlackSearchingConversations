using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace SlackSearchingConversations
{
    internal sealed class SlackApiClient
    {
        private readonly string token;

        public SlackApiClient(string token)
        {
            this.token = token;
        }

        public async Task<SearchMessagesResponse> SearchForMessagesAsync(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                throw new ArgumentException(nameof(query));
            }

            SearchMessagesResponse responseObj;

            string requestUri = string.Format("https://slack.com/api/search.messages?query={0}", query);

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization =
                             new AuthenticationHeaderValue("Bearer", this.token);
                var response = await client.GetAsync(requestUri);

                using (Stream responseReading = await response.Content.ReadAsStreamAsync())
                {
                    using (StreamReader reader = new StreamReader(responseReading))
                    {
                        var responseData = reader.ReadToEnd();

                        responseObj = JsonConvert.DeserializeObject<SearchMessagesResponse>(responseData);
                    }
                }
            }

            return responseObj;
        }


        public async Task<ConversationRepliesResponse> GetConversationAndRepliesAsync(string channelId, string ts)
        {
            if (string.IsNullOrEmpty(channelId))
            {
                throw new ArgumentException(nameof(channelId));
            }

            if (string.IsNullOrEmpty(ts))
            {
                throw new ArgumentException(nameof(ts));
            }

            ConversationRepliesResponse responseObj;

            string requestUri = string.Format("https://slack.com/api/conversations.replies?query={0}&ts={1}", channelId, ts);

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization =
                             new AuthenticationHeaderValue("Bearer", this.token);
                var response = await client.GetAsync(requestUri);

                using (Stream responseReading = await response.Content.ReadAsStreamAsync())
                {
                    using (StreamReader reader = new StreamReader(responseReading))
                    {
                        var responseData = reader.ReadToEnd();

                        responseObj = JsonConvert.DeserializeObject<ConversationRepliesResponse>(responseData);
                    }
                }
            }

            return responseObj;
        }
    }
}
