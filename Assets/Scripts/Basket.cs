using UnityEngine;
using System.Collections;

public class Basket : MonoBehaviour {

    public GUIText scoreGT;

	// Update is called once per frame
	void Update () {
        //Get the current screen position of the mouse from the Input
        Vector3 mousePos2D = Input.mousePosition;

        //The camera's z position sets how far to push the mouse into 3D
        mousePos2D.z = -Camera.main.transform.position.z;

        //Convert the point from 2D screen space into 3D game world space
        Vector3 mousePos3d = Camera.main.ScreenToWorldPoint(mousePos2D);

        //Move the x position of this Basket to the x position of the Mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3d.x;
        this.transform.position = pos;

	}
    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreGT = scoreGO.GetComponent<GUIText>();
        scoreGT.text = "0";
    }
    void OnCollisionEnter(Collision coll)
    {
        //Find out what hit this basket
        GameObject collidedWith = coll.gameObject;
            if (collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);
        }
        int score = int.Parse(scoreGT.text);
        score += 100;
        scoreGT.text = score.ToString();

        if (score > HighScore.score)
        {
            HighScore.score = score;
        }
    }
}
