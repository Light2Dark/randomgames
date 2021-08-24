using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI player1score, player2score;
    int score1, score2;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<Gameboard>().Player1Scores += IncreaseScorePlayer1;
        FindObjectOfType<Gameboard>().Player2Scores += IncreaseScorePlayer2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IncreaseScorePlayer1() {
        score1++;
        player1score.SetText(score1.ToString());
    }

    void IncreaseScorePlayer2() {
        score2++;
        player2score.SetText(score2.ToString());
    }
}
