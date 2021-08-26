using UnityEngine;
using UnityEngine.UIElements;

public class Setting : MonoBehaviour
{
    private Button continueBtn;
    private Button mainMenuBtn;
    public GameObject gearSetting;

    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        continueBtn = root.Q<Button>("ContinueBtn");
        mainMenuBtn= root.Q<Button>("MainMenuBtn");

        continueBtn.clicked += ContinueGame;
        mainMenuBtn.clicked += LoadMenuScene;
    }

    void ContinueGame() {
        gearSetting.SetActive(true);
        this.gameObject.SetActive(false);
    }

    void LoadMenuScene() {
        Debug.Log("load menu scene here");
    }
}
