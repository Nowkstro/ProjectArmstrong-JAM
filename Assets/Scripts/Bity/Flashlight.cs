using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour {

    void FixedUpdate() {
        HandleRotation();
    }

    void HandleRotation() {
        // Convert mouse position into world coordinates
        Vector2 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        // Get direction you want to point at
        Vector2 direction = (mouseScreenPosition - (Vector2)transform.position).normalized;
        
        // Set vector of transform directly
        transform.up = direction;
    }

}
