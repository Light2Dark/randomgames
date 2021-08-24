using UnityEngine;

public class Paddle : MonoBehaviour
{
    public bool player1;
    private GameObject gameboard;
    private bool singleplayer;

    private float leftEdge, rightEdge;
    private Vector3 gameboardCenter;
    private Transform paddleTransform;
    private float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        gameboard = GameObject.FindGameObjectWithTag("gameboard");
        gameboardCenter = gameboard.transform.position;
        leftEdge = gameboard.transform.position.x - (gameboard.transform.localScale.x / 2) + (this.transform.localScale.x / 2);
        rightEdge = gameboard.transform.position.x + (gameboard.transform.localScale.x / 2) - (this.transform.localScale.x / 2);

        singleplayer = gameboard.GetComponent<Gameboard>().getSingleplayer();
        movementSpeed = this.GetComponentInParent<PaddleConstraint>().getMovementSpeed();
        paddleTransform = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public Vector3 getCenterBoard() {
        return gameboardCenter;
    }

    private void Move() {
        for (int i = 0; i < Input.touchCount; i++) {
            
            Touch touch = Input.GetTouch(i);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            float xPosition = Mathf.Clamp(touchPosition.x, leftEdge, rightEdge);

            Vector2 touchPos = new Vector2(xPosition, touchPosition.y);
            Collider2D objectCol = Physics2D.OverlapPoint(touchPos);
            touchPos.y = this.transform.position.y; // setting this to original so that object does not move vertically

            if (objectCol != null) {
                if (objectCol.tag == "Player1" && this.gameObject.tag == "Player1" && touch.phase == TouchPhase.Moved) {
                    this.transform.position = Vector2.Lerp(this.transform.position, touchPos, Time.fixedDeltaTime * movementSpeed);

                } else if (objectCol.tag == "Player2" && !singleplayer && this.gameObject.tag == "Player2" && touch.phase == TouchPhase.Moved) {
                    this.transform.position = Vector2.Lerp(this.transform.position, touchPos, Time.fixedDeltaTime * movementSpeed); // enable movement of 2nd player onlu if single player is unticked
                }
            }
            
        }
    }
}