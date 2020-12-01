using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunGun : MonoBehaviour {

    [SerializeField] Transform firePoint = default;
    [SerializeField] GameObject bulletPrefab = default;
    private float bulletForce = 20f;
    
    private float rechargeTimer = 0f;
    private float rechargeTimerMax = 0.6f;

    void Update() {
        HandleInput();
    }

    void HandleInput() {
        if (rechargeTimer > 0)
            rechargeTimer -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0)) {
            if (rechargeTimer <= 0)
            {
                Fire();
                rechargeTimer = rechargeTimerMax;
            }
        }

        Debug.Log(rechargeTimer);
    }

    void Fire() {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D bulletRig = bullet.GetComponent<Rigidbody2D>();
        bulletRig.AddForce(firePoint.up + firePoint.right * bulletForce, ForceMode2D.Impulse);
    }

}
