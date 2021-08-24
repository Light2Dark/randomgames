using UnityEngine;

public class Ball : MonoBehaviour
{
    public float playerBounceSpeed;
    public float initialSpeed;
    public float increasingSpeedPercentage;
    private float initialBounceSpeed;
    public float minBounceAngle, maxBounceAngle;

    private Rigidbody2D ballbody;
    public float minForce, maxForce;
    private float force;

    private Vector3 ballPosition;
    public Gameboard gameboard;

    private bool roundOver = true;
    private bool player1turn = true;

    private void Awake() {
        ballbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        ballPosition = this.transform.position;
        initialBounceSpeed = playerBounceSpeed;
    }

    void Update() {
        if (Input.touchCount > 0 && roundOver) {
            StartBall(player1turn);
            roundOver = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Vector3 direction = new Vector3(other.GetContact(0).point.x - this.transform.position.x, other.GetContact(0).point.y - this.transform.position.y, this.transform.position.z);
        direction = -direction.normalized;

        playerBounceSpeed += playerBounceSpeed * (increasingSpeedPercentage / 100);
        force = Mathf.Clamp(playerBounceSpeed, minForce, maxForce);
            
        if (other.gameObject.tag == "Player1" || other.gameObject.tag == "Player2") { // hits player
            float bounceAngle = Random.Range(minBounceAngle, maxBounceAngle);
            Vector2 velocity = new Vector3(direction.x + bounceAngle, 1);
            Debug.Log(direction.x + bounceAngle);
            ballbody.AddForce(velocity);
        }

        // } else if (other.gameObject.tag == "gameboard") { // hits wall
        //     if (ballbody.velocity.y > 0) {
        //         direction.y += wallBounceAngle;
        //     } else if (ballbody.velocity.y < 0) {
        //         direction.y -= wallBounceAngle;
        //     } else if (ballbody.velocity.y == 0) {
        //         direction.y += wallBounceAngle;
        //         Debug.Log(ballbody.velocity);
        //     }
        //     ballbody.AddForce(force * direction);
        // }   

    }

    private Vector3 getBallPosition() {
        return ballPosition;
    }

    private void setBallPosition(Vector3 position) {
        ballPosition = position;
    }

    public void ResetBall(bool player1Turn) {
        float distanceFromCenter = gameboard.getCenter().y - ballPosition.y;

        if (!player1Turn) {
            distanceFromCenter = gameboard.getCenter().y + ballPosition.y;
        } 

        this.transform.position = new Vector3(ballPosition.x, distanceFromCenter, ballPosition.z);
        playerBounceSpeed = initialBounceSpeed;
        ballbody.velocity = new Vector2(0, 0);
    }

    private void StartBall(bool player1turn) {
        if (player1turn) {
            ballbody.AddForce(Vector2.down * initialSpeed);
        } else {
            ballbody.AddForce(Vector2.up * initialSpeed);
        }
    }

    public void PlayerScores(bool player1scored) {
        ResetBall(player1scored);
        player1turn = player1scored ? false : true;  // shld be smth wrong
        roundOver = true;
    }
}
