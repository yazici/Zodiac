using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

namespace Pamux
{
  namespace Zodiac
  {
    namespace UI
    {
      public sealed class Credits : Abstracts.UI
      {

        public static Credits INSTANCE = null;

        void Awake()
        {
          INSTANCE = this;
        }
      }
    }
  }
}