using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockBullet : MonoBehaviour {

    private float timer = 0.4f;

    void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);
    }

    void Update() {
        timer -= Time.deltaTime;

        if (timer <= 0)
            Destroy(gameObject);
    }

}
