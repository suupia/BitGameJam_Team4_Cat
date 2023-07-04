using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{
    //押されたらゲーム終了
    public void QuitGame()
    {
#if UNITY_EDITOR
        //ゲームプレイ終了
        UnityEditor.EditorApplication.isPlaying = false;
#else
//ゲームプレイ終了
    Application.Quit();
#endif
    }
}
