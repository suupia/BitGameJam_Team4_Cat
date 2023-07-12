using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using TMPro;


public class LevelButton : MonoBehaviour
{
    public int levelIndex;
    public SceneName sceneToLoad;
    [SerializeField] Image img; // 新たに追加
    [SerializeField] TextMeshProUGUI buttonText;
    private static List<LevelButton> allLevelButtons = new List<LevelButton>();
    private Button btn;

    void Awake()
    {
        allLevelButtons.Add(this);
    }

    void OnDestroy()
    {
        allLevelButtons.Remove(this);
    }

   

    void Start()
    {
        btn = GetComponent<Button>();
        RefreshButtonInteractableState();
        btn.onClick.AddListener(OnButtonClicked);

        // buttonText.text = sceneToLoad.ToString();
        buttonText.text = $"Stage {levelIndex}";
    }

    void OnButtonClicked()
    {
        ProgressManager.Load(sceneToLoad);
        FindObjectOfType<MusicController>()?.PlaySelectStageSE();

    }

    public void RefreshButtonInteractableState()
    {
        bool isButtonInteractable = levelIndex <= ProgressManager.GetCompletedLevelIndex() + 1;
        btn.interactable = isButtonInteractable;

        // もしButtonが押せる(isButtonInteractable == true)なら透明度を1（全く透明でない）に、そうでないなら透明度を0.5（半透明）に設定
        img.color = new Color(img.color.r, img.color.g, img.color.b, isButtonInteractable ? 1f : 0.5f);
        buttonText.color = new Color(buttonText.color.r, buttonText.color.g, buttonText.color.b, isButtonInteractable ? 1f : 0.5f);
        Debug.Log($"img = {img}");
    }

    public static void RefreshAllButtons()
    {
        foreach (var levelButton in allLevelButtons)
        {
            levelButton.RefreshButtonInteractableState();
        }
    }
}
