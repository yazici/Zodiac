using UnityEngine;
using System.Collections;

namespace Pamux
{
  namespace Abstracts
  {
    public class Platform : MonoBehaviour
    {
      private class NoOpPushNotifications : Interfaces.IPushNotifications
      {
        public void Register() {}
        public void Unregister() {}
      }
      protected Interfaces.IPushNotifications pushNotifications = new NoOpPushNotifications();
      
      public Interfaces.IPushNotifications PushNotifications
      {
        get 
        {
          return pushNotifications;
        }
      }

    }
  }
}