using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
public enum SceneName
{
    TestStage,
    GameSelect
    // 他のシーンの名前
}

public class LevelButton : MonoBehaviour
{
    public int levelIndex;
    private Button btn;
    private Image img; // 新たに追加
    private static List<LevelButton> allLevelButtons = new List<LevelButton>();

    void Awake()
    {
        allLevelButtons.Add(this);
    }

    void OnDestroy()
    {
        allLevelButtons.Remove(this);
    }

    public static void Load(SceneName scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    void Start()
    {
        btn = GetComponent<Button>();
        img = GetComponent<Image>(); // 新たに追加
        RefreshButtonInteractableState();
        btn.onClick.AddListener(OnButtonClicked);
    }

    void OnButtonClicked()
    {
        Load(SceneName.TestStage);
    }

    public void RefreshButtonInteractableState()
    {
        bool isButtonInteractable = levelIndex <= ProgressManager.GetCompletedLevelIndex() + 1;
        btn.interactable = isButtonInteractable;

        // もしButtonが押せる(isButtonInteractable == true)なら透明度を1（全く透明でない）に、そうでないなら透明度を0.5（半透明）に設定
        img.color = new Color(img.color.r, img.color.g, img.color.b, isButtonInteractable ? 1f : 0.5f);
    }

    public static void RefreshAllButtons()
    {
        foreach (var levelButton in allLevelButtons)
        {
            levelButton.RefreshButtonInteractableState();
        }
    }
}
