using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmRotation : MonoBehaviour
{

    // Arms object should be inside the player, and the two arms (if have two) inside this object
    [SerializeField] private Transform pivoArms = null;

    void FixedUpdate() {
        HandleArmRotation();
    }

    void HandleArmRotation() {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();

        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        pivoArms.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        // Facing left
        if (rotationZ < -90 || rotationZ > 90) {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            pivoArms.transform.localRotation = Quaternion.Euler(180f, 180f, -rotationZ);
        }
        // Facing right 
        else {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
    }

}
