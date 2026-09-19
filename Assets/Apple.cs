using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour {
// a
public static float bottomY = -20f;

public int point = 100;
// b

public bool isPoison = false;

void Update () {
    if ( transform.position.y < bottomY ) {
        Destroy( this.gameObject );

        ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();

        if (!isPoison)
        {
                apScript.AppleMissed();
        }
// c
}
}


}