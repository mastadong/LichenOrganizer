using Prism.Events;

namespace LichenOrganizer.UI.Events
{
    public class AfterFriendSavedEvent : PubSubEvent<AfterFriendSavedEventArgs>
    {
    }

    public class AfterFriendSavedEventArgs
    {
        //We need to think about what information we'd like to send back to the FriendDetailViewModel in
        //order to refresh the View.
        public int Id { get; set; }
        public string DisplayMember { get; set; }
    }
}
