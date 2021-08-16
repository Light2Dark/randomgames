using UnityEngine;

public class paddle : MonoBehaviour
{
    public bool player1;
    private bool singleplayer;
    private GameObject gameboard;

    private float gameboardWidth;
    private float gameboardHeight;
    private Vector3 gameboardCenter;

    private Transform paddleTransform;
    private float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        gameboard = GameObject.FindGameObjectWithTag("gameboard");
        gameboardCenter = gameboard.transform.position;
        // gameboardWidth = gameboard.GetComponent<SpriteRenderer>().bounds.size.x;
        // gameboardHeight = gameboard.GetComponent<SpriteRenderer>().bounds.size.y;
        // Debug.Log("Gameboard width: " + gameboardWidth + " height: " + gameboardHeight);

        singleplayer = false;

        paddleTransform = this.GetComponent<Transform>();
        movementSpeed = 5;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate() {
        Move();
    }

    void Move() {
        for (int i = 0; i < Input.touchCount; i++) {
            Touch touch = Input.GetTouch(i);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            RaycastHit2D hitObject = Physics2D.Raycast(touchPosition, Vector2.down);
            Debug.Log("hitobject coldider: " + hitObject.collider);
        }
    }

    public void setSingleplayer(bool singleplayer) {
        this.singleplayer = singleplayer;
    }

    public Vector3 getCenterBoard() {
        return gameboardCenter;
    }
}

/*
            if (singleplayer) {
            // code for AI paddle

            } else {
                if (touchPosition.y < gameboardCenter.y) { // player 1
                    if (touchPosition.x < gameboardCenter.x) {
                        // move left
                        paddleTransform.Translate(-transform.right * movementSpeed * Time.fixedDeltaTime, Space.World);
                        Debug.Log("player1 move left");

                    } else if (touchPosition.x > gameboardCenter.x) {
                        // move right
                        Debug.Log("player1 move right");
                    }

                } else if (touchPosition.y > gameboardCenter.y) { // player 2
                    if (touchPosition.x < gameboardCenter.x) {
                        // move right
                        Debug.Log("player2 move right");
                    } else if (touchPosition.x > gameboardCenter.x) {
                        // move left
                        Debug.Log("player2 move left");
                    }
                }
            }
*/
