using Prism.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace LichenOrganizer.UI.Events
{
    //When an event implements the PubSubEvent<>, the input parameter must be specified.  In this case, we will be sending 
    //the selected friend's 'Id' value to the event aggregator, which will be used by any event subscribers.
    //
    //The ViewModel is responsible for publishing the event.
    public class OpenFriendDetailViewEvent : PubSubEvent<int>
    {
    }
}
