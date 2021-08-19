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
        movementSpeed = 30;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate() {
        Move();
    }

    public void setSingleplayer(bool singleplayer) {
        this.singleplayer = singleplayer;
    }

    public Vector3 getCenterBoard() {
        return gameboardCenter;
    }

    private void Move() {
        for (int i = 0; i < Input.touchCount; i++) {
            Touch touch = Input.GetTouch(i);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            Vector2 touchPos = new Vector2(touchPosition.x, touchPosition.y);
            Collider2D objectCol = Physics2D.OverlapPoint(touchPos);
            touchPos.y = this.transform.position.y; // setting this to original so that object does not move verticall

            if (objectCol != null) {
                if (objectCol.tag == "Player1" && this.gameObject.tag == "Player1" && touch.phase == TouchPhase.Moved) {
                    this.transform.position = Vector2.Lerp(this.transform.position, touchPos, Time.fixedDeltaTime * movementSpeed);

                } else if (objectCol.tag == "Player2" && !singleplayer && this.gameObject.tag == "Player2" && touch.phase == TouchPhase.Moved) {
                    this.transform.position = Vector2.Lerp(this.transform.position, touchPos, Time.fixedDeltaTime * movementSpeed);
                }
            }
            
        }
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
