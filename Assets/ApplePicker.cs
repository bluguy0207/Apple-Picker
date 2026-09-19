using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour {
[Header("Inscribed")]
public GameObject basketPrefab;
public int numBaskets = 3;
public float basketBottomY = -14f;
public float basketSpacingY = 2f;

public List<GameObject> basketList;

void Start () {
    basketList = new List<GameObject>();
    for (int i=0; i <numBaskets; i++) {
    GameObject tBasketGO = Instantiate<GameObject>( basketPrefab );
    Vector3 pos = Vector3.zero;
    pos.y = basketBottomY + ( basketSpacingY * i );
    tBasketGO.transform.position = pos;
    basketList.Add( tBasketGO );
}
}

public void AppleMissed()
{
    GameObject[] appleArray =
        GameObject.FindGameObjectsWithTag("Apple");

    // Destroy all non-poison apples
    foreach (GameObject tempGo in appleArray)
    {
        Apple apple = tempGo.GetComponent<Apple>();

        if (apple != null && apple.isPoison)
        {
            continue;
        }

        Destroy(tempGo);
    }

    // Remove one basket
    int basketIndex = basketList.Count - 1;

    GameObject basketGO = basketList[basketIndex];

    basketList.RemoveAt(basketIndex);

    Destroy(basketGO);

    // If all baskets are gone, go to the Lose screen
    if (basketList.Count == 0)
    {
        SceneManager.LoadScene("__Scene_0");
    }
}

}