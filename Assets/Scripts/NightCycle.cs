using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class NightCycle : MonoBehaviour
{

    [SerializeField] Light2D globalLight = default;
    
    public float transitionSpeed;
    public float coroutineSpeed;
    public float nightDayTime;

    public float nightBrightness;
    public float dayBrightness;

    /*private float timer = 0f;
    private float timerMax = 1f;

    private bool isDay = false;

    static private bool isGettingDark = false;*/
    static private bool isDawning = false;

    static float lightIntensity = 1f;

    // void Awake() {
    //     transitionSpeed = Time.deltaTime;
    // }

    void Start() {
        globalLight.intensity = lightIntensity;

        if (globalLight.intensity < dayBrightness)
        /*isGettingDark = true;
        else*/
            isDawning = true;

        StartCoroutine(StartCycle());
    }

    IEnumerator StartCycle() {
        while (true) {

            lightIntensity = globalLight.intensity;

            if (globalLight.intensity <= nightBrightness || globalLight.intensity >= dayBrightness) {
                transitionSpeed = -transitionSpeed;

                if (globalLight.intensity <= nightBrightness)
                    globalLight.intensity = nightBrightness + 0.01f;
                else if (globalLight.intensity >= dayBrightness)
                    globalLight.intensity = dayBrightness - 0.01f;

                yield return new WaitForSeconds(nightDayTime);
            }

            if (transitionSpeed < 0) {
                isDawning = false;
                /*isGettingDark = true;*/
            }
            else if (transitionSpeed > 0) {
                /*isGettingDark = false;*/
                isDawning = true;
            }

            if (isDawning)
                globalLight.intensity += (transitionSpeed * Time.deltaTime);
            else
                globalLight.intensity -= (transitionSpeed * Time.deltaTime);

            yield return new WaitForSeconds(coroutineSpeed);
        }
    }

}
