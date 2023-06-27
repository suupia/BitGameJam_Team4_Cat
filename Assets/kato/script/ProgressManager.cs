using UnityEngine;

public static class ProgressManager
{
    private const string KeyActiveLevelIndex = "ActiveLevelIndex";

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
}
