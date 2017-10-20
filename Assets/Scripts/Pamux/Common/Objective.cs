using UnityEngine;
using System.Collections;

namespace Pamux
{
  namespace Abstracts
  {
    public abstract class Objective : MonoBehaviour
    {
      private bool _isAchieved = false;

      protected abstract bool vIsAchieved();

      internal bool IsAchieved()
      {
        _isAchieved = _isAchieved || vIsAchieved();
        return _isAchieved;
      }
    }


    public class LevelCompletedUntouched : Objective
    {
      protected override bool vIsAchieved()
      {
        return GameControllerBase.INSTANCE.summaryData.untouched;
      }
    }
  }

  namespace Zodiac
  {
    public class Killed70PercentEnemies : Abstracts.Objective
    {
      protected override bool vIsAchieved()
      {
        return (GameController.INSTANCE.summaryData.enemiesKilled * 100 / GameController.INSTANCE.summaryData.totalEnemies) >= 70;
      }
    }

    public class KilledAllEnemies : Abstracts.Objective
    {
      protected override bool vIsAchieved()
      {
        return GameController.INSTANCE.summaryData.totalEnemies == GameController.INSTANCE.summaryData.enemiesKilled;
      }
    }

    public class CollectedAllExtractables : Abstracts.Objective
    {
      protected override bool vIsAchieved()
      {
        return GameController.INSTANCE.summaryData.totalExtractables == GameController.INSTANCE.summaryData.extractablesExtracted;
      }
    }

    public class CollectedAllFunds : Abstracts.Objective
    {
      protected override bool vIsAchieved()
      {
        return GameController.INSTANCE.summaryData.totalFunds == GameController.INSTANCE.summaryData.fundsCollected && GameController.INSTANCE.summaryData.totalEnemies == GameController.INSTANCE.summaryData.enemiesKilled;
      }
    }
  }
}