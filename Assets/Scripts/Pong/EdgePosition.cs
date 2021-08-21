using UnityEngine;

public class EdgePosition : MonoBehaviour
{
    public Gameboard gameboard;
    public bool left;
    
    // Start is called before the first frame update
    void Start()
    {
        float gameboardPosx = gameboard.transform.position.x;
        float xPos;

        if (left) {
            xPos = gameboardPosx - (gameboard.transform.localScale.x / 2); // setting this object to the left edge of gameboard
        } else {
            xPos = gameboardPosx + (gameboard.transform.localScale.x / 2); // setting this object to the right edge of gameboard
        }

        this.transform.position = new Vector3(xPos, this.transform.position.y, this.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
