using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PongMenu : MonoBehaviour
{
    public Button MenuButton;

    // Start is called before the first frame update
    void Start()
    {
        MenuButton.onClick.AddListener(GoToMenuScene);
    }

    void GoToMenuScene() {
        SceneManager.LoadScene(0);
    }
}
