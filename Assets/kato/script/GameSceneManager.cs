using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    void Update()
    {
        if (/*ゲームが終了したら*/true)
        {
            LevelButton.Load(SceneName.GameSelect);
            // 選択シーンに戻ります
        }
    }
}
