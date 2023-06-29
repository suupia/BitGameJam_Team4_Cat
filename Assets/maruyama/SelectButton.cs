using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SelectButton : MonoBehaviour
{
    //押されたら
    public void OnClickToGameSceneButton()
    {
        //セレクトシーンに移行
        SceneManager.LoadScene("GameSelect");
    }
}
