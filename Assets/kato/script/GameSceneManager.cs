using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    // 当てはめるものを定義します。具体的なゲームによって終了条件は異なります。
    void Update()
    {
        if (/*ゲームが終了したら*/true)
        {
            // 選択シーンに戻ります
            SceneManager.LoadScene("SelectionScene"); // "SelectionScene"はあなたが設定した選択シーンの名前に書き換えてください。
        }
    }
}
