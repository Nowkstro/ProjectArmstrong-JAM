using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrap1 : MonoBehaviour {

    public static bool alreadyPickedup = false;

    void Start() {
        if (alreadyPickedup) {
            Destroy(gameObject);
        }
    }

}
