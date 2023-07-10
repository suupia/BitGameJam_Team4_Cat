using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    void Start()
    {
        var btn = GetComponent<Button>();
        btn.onClick.AddListener(OnClickToGameSelect);
    }

     void OnClickToGameSelect()
    {
        //セレクトシーンに移行
        ProgressManager.Load(SceneName.GameSelect);
        FindObjectOfType<MusicController>().PlayButtonSE();
    }
}
