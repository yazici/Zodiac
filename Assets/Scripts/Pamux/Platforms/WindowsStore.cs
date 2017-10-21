using UnityEngine;
using System.Collections;

using  Microsoft.Services.Store.Engagement;

namespace Pamux
{
  namespace Platforms
  {
    public class WindowsStore : Abstracts.Platform
    {
      public class PushNotifications : Interfaces.IPushNotifications
      {
        public void Register()
        {
          StoreServicesEngagementManager.RegisterNotificationChannel();
        }
        
        public void Unregister()
        {
          
        }
      }
      
      public WindowsStore()
      {
        pushNotifications = new PushNotifications();
      }
    }
  }
}
