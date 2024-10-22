﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneName
{
    GameTitle,
    GameSelect,
    Tutorial,
    
    Stage1,
    Stage2,
    Stage3,
    
    TestStage,
    // 他のシーンの名前
    
    FirstStageA,
    FirstStageB,
    FirstStageC,
    
    SasakiStageA,
    SasakiStageB,
    SasakiStageC,
    
    KatoStageA,
    KatoStageB,
    KatoStageC,
    
    HamanoStageA,
    HamanoStageB,
    HamanoStageC,
}

public static class ProgressManager
{
     const string KeyActiveLevelIndex = "ActiveLevelIndex";
    public static int GetCompletedLevelIndex()
    {
        return PlayerPrefs.GetInt(KeyActiveLevelIndex, -1);
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
        PlayerPrefs.SetInt(ProgressManager.KeyActiveLevelIndex, -1);
        PlayerPrefs.Save();
        LevelButton.RefreshAllButtons();
    }

    public static void Load(SceneName scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    public static void ClearStage(int levelIndex)
    {
        CompleteLevelIndex(levelIndex);
        Load(SceneName.GameSelect);
    }
}
