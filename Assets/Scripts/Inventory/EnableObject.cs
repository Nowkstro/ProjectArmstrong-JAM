using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableObject : MonoBehaviour {

    public GameObject scrapToActive;

    public void EnableScrap() {
        scrapToActive.SetActive(true);
    }

}
