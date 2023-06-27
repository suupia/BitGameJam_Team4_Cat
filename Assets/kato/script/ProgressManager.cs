using UnityEngine;

public static class ProgressManager
{
    public const string KeyActiveLevelIndex = "ActiveLevelIndex";

    public static int GetCompletedLevelIndex()
    {
        return PlayerPrefs.GetInt(KeyActiveLevelIndex, 0);
    }

    public static void CompleteLevelIndex(int levelIndex)
    {
        int currentIndex = GetCompletedLevelIndex();
        if (levelIndex > currentIndex)
        {
            PlayerPrefs.SetInt(KeyActiveLevelIndex, levelIndex);
            PlayerPrefs.Save();
        }
    }

    public static void ResetLevelIndex()
    {
        PlayerPrefs.SetInt(ProgressManager.KeyActiveLevelIndex, 0);
        PlayerPrefs.Save();
        LevelButton.RefreshAllButtons();
    }
}
