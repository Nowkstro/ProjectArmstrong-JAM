using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TPCorrectPlace : MonoBehaviour {

    public GameObject terry;
    public GameObject pointToTeleport;
    public static bool noMoreCutscene;

    void Start() {
        if (SceneManager.GetActiveScene().buildIndex == 4 && noMoreCutscene) {
            terry.transform.position = pointToTeleport.transform.position;
            terry.transform.eulerAngles = new Vector2(0, 180f);
        }
    }

}
