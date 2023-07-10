using UnityEngine;
using UnityEngine.UI;

public class ResetButton : MonoBehaviour
{
    private Button btn;
    private void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        ProgressManager.ResetLevelIndex();
        FindObjectOfType<MusicController>().PlayButtonSE();

    }
}
