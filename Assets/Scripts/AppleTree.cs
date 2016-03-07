using UnityEngine;
using System.Collections;

public class AppleTree : MonoBehaviour {

    //Prefab for instatiating apples
    public GameObject applePrefab;

    //Speed the AppleTree moves in m/s
    public float speed = 1f;

    //Distance where AppleTree turns around
    public float leftAndRightEdge = 20f;

    //Chance that the AppleTree will change directions
    public float chanceToChangeDirections = 0.1f;

    //Rate Apples will be instatiated
    public float secondsBetweenAppleDrops = 1f;
    
	// Use this for initialization
	void Start () {
        //Droppping apples every second
        InvokeRepeating("DropApple", 2f, secondsBetweenAppleDrops);
	}

    void DropApple()
    {
        GameObject apple = Instantiate(applePrefab) as GameObject;
        apple.transform.position = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        //Basic Movement
            // defines V3 apos to current position of AppleTree
        Vector3 pos = transform.position;
            //x component of pos is increased by the speed times Time.deltaTime (measure of # of secs in last frame)
        pos.x += speed * Time.deltaTime;
            //assigns modified pos back to transform.position (moves AppleTree to new pos)
        transform.position = pos;
        
        //Changing Direction
	    if (pos.x < -leftAndRightEdge)
        {
            //move right
            speed = Mathf.Abs(speed);
        } else if (pos.x > leftAndRightEdge)
        {
            //move left
            speed = -Mathf.Abs(speed);
        }
	}

    void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
        {
            //change direction
            speed *= -1;
        }
    }
}
