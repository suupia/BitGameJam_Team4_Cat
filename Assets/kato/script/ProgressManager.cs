using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneName
{
    TestStage,
    GameSelect,
    Tutorial
    // 他のシーンの名前
}

public static class ProgressManager
{
    public const string KeyActiveLevelIndex = "ActiveLevelIndex";
    public static string[] sceneNames = new string[] { "TestStage", "GameSelect", "Tutorial" };
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

    public static void Load(SceneName scene)
    {
        SceneManager.LoadScene(sceneNames[(int)scene]);
    }

    public static void ClearStage(int levelIndex)
    {
        CompleteLevelIndex(levelIndex);
        Load(SceneName.GameSelect);
    }
}
