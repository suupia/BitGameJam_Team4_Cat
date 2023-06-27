using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    public int levelIndex;
    private Button btn;

    void Start()
    {
        btn = GetComponent<Button>();
        btn.interactable = levelIndex <= ProgressManager.GetCompletedLevelIndex() + 1;
        btn.onClick.AddListener(OnButtonClicked);
    }

    void OnButtonClicked()
    {
        ProgressManager.CompleteLevelIndex(levelIndex);
        SceneManager.LoadScene("testStage");
    }
}
