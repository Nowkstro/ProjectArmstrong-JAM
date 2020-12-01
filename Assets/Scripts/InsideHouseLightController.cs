using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideHouseLightController : MonoBehaviour {

    private SpriteRenderer lightSR;

    void Awake() {
        lightSR = GetComponent<SpriteRenderer>();
    }

    void Start() {
        if (DayNightSystem.globalCurrentDayCycle == DayCycles.Sunset && DayNightSystem.globalCurrentTime > DayNightSystem.staticMaxTime / 1.7)
            lightSR.color = new Color(lightSR.color.r, lightSR.color.g, lightSR.color.b, 0.05f);

        if (DayNightSystem.globalCurrentDayCycle == DayCycles.Night)
            lightSR.color = new Color(lightSR.color.r, lightSR.color.g, lightSR.color.b, 0f);
        
        if (DayNightSystem.globalCurrentDayCycle == DayCycles.Midnight)
            lightSR.color = new Color(lightSR.color.r, lightSR.color.g, lightSR.color.b, 0.5f);
    }

}
