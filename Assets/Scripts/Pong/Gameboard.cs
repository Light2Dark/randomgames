using UnityEngine;

public class Gameboard : MonoBehaviour
{
    public bool singleplayer; // can make this private later on when we have UI

    // Start is called before the first frame update
    void Start()
    {
        
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
}
