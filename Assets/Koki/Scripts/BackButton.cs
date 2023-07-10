using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var btn = GetComponent<Button>();
        btn.onClick.AddListener(ReturnToGameSelect);
    }
    void ReturnToGameSelect()
    {
        ProgressManager.Load(SceneName.GameSelect);
        FindObjectOfType<MusicController>().PlayButtonSE();

    }
}
