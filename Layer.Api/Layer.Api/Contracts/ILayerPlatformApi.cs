namespace Layer.Api.Contracts
{
    public interface ILayerPlatformApi
    {
        IConversationApi Conversations { get; set; }
        IMessagesApi Messages { get; set; }
        IUserApi Users { get; set; }
        IDataServiceApi DataService { get; set; }
    }
}