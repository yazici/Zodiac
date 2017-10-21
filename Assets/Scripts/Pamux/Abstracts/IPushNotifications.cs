using UnityEngine;
using System.Collections;

namespace Pamux
{
  namespace Interfaces
  {
    public interface IPushNotifications
    {
      void Register();
      void Unregister();
    }
  }
}