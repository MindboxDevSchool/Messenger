namespace Messenger.Domain
{
    public enum OperationStatus
    {
        Success,
        Failure,
        NotHaveCredentials,
        NoSuchChatter,
        NoSuchMessage,
        NoSuchModerator,
        ConcurrentAccessFailure
    }
}