using UnityEngine;
using UnityEngine.UI;

public class returnButton : MonoBehaviour
{
    // Start is called before the first frame update
    private Button btn;
    public int levelIndex;
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(OnButtonClicked);
    }

    void OnButtonClicked()
    {
        ProgressManager.ClearStage(levelIndex);
        FindObjectOfType<MusicController>().PlayButtonSE();

    }
}
