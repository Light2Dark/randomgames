using UnityEngine;

public class Gameboard : MonoBehaviour
{
    public bool singleplayer; // can make this private later on when we have UI
    private Ball ball;

    public delegate void OnBallScored();
    public event OnBallScored Player1Scores;
    public event OnBallScored Player2Scores;

    // Start is called before the first frame update
    void Start()
    {
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setSingleplayer(bool singleplayer) {
        this.singleplayer = singleplayer;
    }

    public bool getSingleplayer() {
        return singleplayer;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Ball") {
            if (other.transform.position.y < 0) { // player 2 scores
                ball.PlayerScores(false);
                if (Player2Scores != null) {
                    Player2Scores();
                }
            } else if (other.transform.position.y > 0) { // player 1 scores
                ball.PlayerScores(true);
                if (Player1Scores != null) {
                    Player1Scores();
                }
            }
        }
    }

    public Vector3 getCenter() {
        return this.transform.position;
    }
}
