using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Basket : MonoBehaviour {

    public ScoreCounter scoreCounter;
void Start ()
    {
        GameObject scoreGO = GameObject.Find( "ScoreCounter" );

        scoreCounter = scoreGO.GetComponent<ScoreCounter>();
    } // We’ll add code to Start() in Code Listing 29.12

void Update () {
// Get the current screen position of the mouse fromInput
    Vector3 mousePos2D = Input.mousePosition;
// a

// The Camera’s z position sets how far to push the mouse into 3D
// If this line causes a NullReferenceException, select the Main Camera
// in the Hierarchy and set its tag to MainCamera in the Inspector.
    mousePos2D.z = -Camera.main.transform.position.z;
// b
// Convert the point from 2D screen space into 3D game world space
    Vector3 mousePos3D = Camera.main.ScreenToWorldPoint( mousePos2D ); // c

// Move the x position of this Basket to the x position of the Mouse
    Vector3 pos = this.transform.position;
    pos.x = mousePos3D.x;
    this.transform.position = pos;

}
void OnCollisionEnter( Collision coll ) {
        GameObject collidedWith = coll.gameObject;

        if (collidedWith.CompareTag("Apple"))
        {

        Apple apple = collidedWith.GetComponent<Apple>();

        scoreCounter.score += apple.point;

        Destroy(collidedWith);

            HighScore.TRY_SET_HIGH_SCORE( scoreCounter.score );
        }

        if (scoreCounter.score >= 3000)
        {
        SceneManager.LoadScene("Scene_Win");
        }
        
}
}