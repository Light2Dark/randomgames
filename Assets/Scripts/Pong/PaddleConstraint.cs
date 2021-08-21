using UnityEngine;

public class PaddleConstraint : MonoBehaviour
{
    public int movementSpeed; // maybe can make this a setting and make it private

    // Start is called before the first frame update
    void Start()
    {
        setMovementSpeed(movementSpeed);
    }

    public void setMovementSpeed(int movementSpeed) {
        this.movementSpeed = movementSpeed;
    }

    public int getMovementSpeed() {
        return movementSpeed;
    }

    
}
