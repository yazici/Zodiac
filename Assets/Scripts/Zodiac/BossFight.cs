using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System;


namespace Pamux
{
  namespace Zodiac
  {
    public class BossFight : Abstracts.GamePlayState
    {
      internal override IEnumerator DoRun()
      {
        yield return new WaitForSeconds(1);

        _doRunCompleted = Time.time;
        _isComplete = true;
      }

    }
  }
}