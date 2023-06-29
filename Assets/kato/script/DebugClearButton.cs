using UnityEngine;
using UnityEngine.UI;

public class DebugClearButton : MonoBehaviour
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
    }
}
