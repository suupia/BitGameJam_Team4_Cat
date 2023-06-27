using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class returnButton : MonoBehaviour
{
    // Start is called before the first frame update
    private Button btn;

    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(OnButtonClicked);
    }

    void OnButtonClicked()
    {
        SceneManager.LoadScene("GameSelect");
    }
}
