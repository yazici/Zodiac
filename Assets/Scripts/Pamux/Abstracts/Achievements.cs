using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Pamux
{
  namespace Abstracts
  {

    public class Achievement
    {
      string id;
      string description;

      public Achievement(Dictionary<string, int> headerNameToColMap, string[] fields)
      {
        id = fields[0];
        description = fields[1];

        Achievements.allAchievements[id] = this;
      }
    }

    public class Achievements : ITextAssetHandler
    {
      public static Dictionary<string, Achievement> allAchievements = new Dictionary<string, Achievement>();
      private HashSet<string> completedAchievements = new HashSet<string>();


      public Achievements()
      {
        TextAssetHelper.Load("achievements", this);

        if (!PlayerPrefs.HasKey("Player.Achievements"))
        {
          return;
        }
        foreach (string str in PlayerPrefs.GetString("Player.Achievements").Split(','))
        {
          completedAchievements.Add(str);
        }
      }

      #region ITextAssetHandler

      public void AddItems(Dictionary<string, int> headerNameToColMap, string[] fields)
      {
        new Achievement(headerNameToColMap, fields);
      }

      public void SetVariable(string name, string value)
      {

      }
      public void OnItemsReady()
      {

      }
      #endregion

      public bool IsAchievementCompleted(string achievementId)
      {
        return completedAchievements.Contains(achievementId);
      }
      public void SetAchievementCompleted(string achievementId)
      {
        if (achievementId.Length == 0 || completedAchievements.Contains(achievementId))
        {
          return;
        }

        completedAchievements.Add(achievementId);

        string completedStr = "";
        foreach (string str in completedAchievements)
        {
          completedStr += str + ",";
        }
        PlayerPrefs.SetString("Player.Achievements", completedStr);
      }

      public bool IsLevelObjectiveCompleted(int objectiveId, int levelId, Difficulties difficulty)
      {
        return IsAchievementCompleted(GetAchievementKey(objectiveId, levelId, difficulty));
      }

      public void SetLevelObjectiveComplete(int objectiveId, int levelId, Difficulties difficulty)
      {
        SetAchievementCompleted(GetAchievementKey(objectiveId, levelId, difficulty));
      }

      public bool IsLevelUnlocked(int levelId, Difficulties difficulty)
      {
        if (difficulty == Difficulties.Easy)
        {
          return levelId == 0 || IsLevelCompleted(levelId - 1, difficulty);
        }
        return IsLevelCompleted(levelId, difficulty - 1);
      }
      public bool IsLevelCompleted(int levelId, Difficulties difficulty)
      {
        return IsAchievementCompleted(GetAchievementKey(0, levelId, difficulty));
      }
      public void MarkLevelComplete(int levelId, Difficulties difficulty)
      {
        SetAchievementCompleted(GetAchievementKey(0, levelId, difficulty));
      }

      private string GetAchievementKey(int levelId, int objectiveId, Difficulties difficulty)
      {
        return string.Format("O{0}L{1}D{2}", objectiveId, levelId, (int)difficulty);
      }
    }
  }
}