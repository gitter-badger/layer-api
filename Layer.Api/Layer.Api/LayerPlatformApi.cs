using Layer.Api.Contracts;

namespace Layer.Api
{
    public class LayerPlatformApi : ILayerPlatformApi
    {
        public LayerPlatformApi(IConversationApi conversationApi,
            IMessagesApi messageApi,
            IUserApi userApi,
            IDataServiceApi dataServiceApi)
        {
            Conversations = conversationApi;
            Messages = messageApi;
            Users = userApi;
            DataService = dataServiceApi;
        }

        public IConversationApi Conversations { get; set; }

        public IMessagesApi Messages { get; set; }

        public IUserApi Users { get; set; }

        public IDataServiceApi DataService { get; set; }
    }
}