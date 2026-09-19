using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour {
[Header("Inscribed")]
// a
// Prefab for instantiating apples
public GameObject applePrefab;

// Prefab for instantiating gold apples
public GameObject goldApplePrefab;

// Prefab for instantiating poison apples
public GameObject poisonApplePrefab;

// Speed at which the AppleTree moves
public float speed = 1f;

// Chance that a dropped apple will be a Gold Apple
public float goldAppleChance = 0.1f;

// Chance that a dropped apple will be a Poison Apple
public float poisonAppleChance = 0.2f;

// Distance where AppleTree turns around
public float leftAndRightEdge = 10f;

// Chance that the AppleTree will change directions
public float changeDirChance = 0.2f;

// Seconds between Apples instantiations
public float appleDropDelay = 1f;

void Start () {
 // Start dropping apples
    Invoke( "DropApple", 2f) ;
// b
}

void DropApple()
{
    GameObject apple;

    float randomValue = Random.value;

    if (randomValue < goldAppleChance)
    {
        apple = Instantiate<GameObject>(goldApplePrefab);
    }

    else if (randomValue < poisonAppleChance)
    {
        apple = Instantiate<GameObject>(poisonApplePrefab);
    }

    else
    {
        apple = Instantiate<GameObject>(applePrefab);
    }

    apple.transform.position = transform.position;

    Invoke("DropApple", appleDropDelay);
}

 void Update () {
 // Basic Movement
 Vector3 pos = transform.position;

 pos.x += speed * Time.deltaTime;

 transform.position = pos;
// b
 // Changing Direction
    if ( pos.x < -leftAndRightEdge )
        {
            speed = Mathf.Abs(speed); // Move right

        }   
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); // Move left
        }


// b
 }

    void FixedUpdate()
    {
        if ( Random.value < changeDirChance )
        {
           speed *= -1;
        }
    }
}

