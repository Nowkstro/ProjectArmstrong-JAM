using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFail : MonoBehaviour {

    public GameObject lightGO;

    [Range(0, 100)]
    public int failChance = 20;
    
    private float timer;
    private float minTimer = 1f;

    public float blinkSpeed = 0.1f;
    private bool failing = false;

    void Start() {
        timer = minTimer;
        lightGO = transform.GetChild(0).gameObject;
    }

    void Update() {
        if (timer <= 0) {
            timer = minTimer;
            RollDice();
        }
        else
            timer -= Time.deltaTime;
    }

    void RollDice() {
        if (Random.Range(0, 100) < 20 && !failing) {
            StartCoroutine(BlinkLight());
        }
    }

    IEnumerator BlinkLight() {
        failing = true;

        lightGO.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        lightGO.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        lightGO.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        lightGO.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        lightGO.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        lightGO.SetActive(true);
        failing = false;
    }

}
