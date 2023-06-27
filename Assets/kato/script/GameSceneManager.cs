using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    // 当てはめるものを定義します。具体的なゲームによって終了条件は異なります。
    void Update()
    {
        if (/*ゲームが終了したら*/true)
        {
            LevelButton.Load(SceneName.GameSelect);
            // 選択シーンに戻ります
        }
    }
}
