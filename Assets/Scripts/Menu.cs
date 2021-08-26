using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private Button PongBtn;
    private Button MathBtn;
    private Button SettingsBtn;
    private Button CreditsBtn;
    
    public GameObject creditsPanel;

    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        PongBtn = root.Q<Button>("PongBtn");
        MathBtn = root.Q<Button>("MathBtn");
        SettingsBtn = root.Q<Button>("SettingsBtn");
        CreditsBtn = root.Q<Button>("CreditsBtn");

        PongBtn.clicked += GoToPongGameScene;
        CreditsBtn.clicked += Credits;
    }

    void GoToPongGameScene() {
        SceneManager.LoadScene(1); // 1 represents pong game
    }

    void Credits() {
        creditsPanel.SetActive(true);
    }

}
