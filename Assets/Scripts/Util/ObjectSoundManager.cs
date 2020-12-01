using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectSoundManager : MonoBehaviour
{
    void PlayWalkingSounds()
    {
        // Alicias House
        if (SceneManager.GetActiveScene().buildIndex == 2) {
            FMODUnity.RuntimeManager.PlayOneShot("event:/sfx_gameplay/passos_madeira (multi)", gameObject.transform.position);
        }

        // City and Bunker
        if (SceneManager.GetActiveScene().buildIndex == 3 || SceneManager.GetActiveScene().buildIndex == 4 || SceneManager.GetActiveScene().buildIndex == 5 || SceneManager.GetActiveScene().buildIndex == 6) {
            FMODUnity.RuntimeManager.PlayOneShot("event:/sfx_gameplay/passos_concreto (multi, probality)", gameObject.transform.position);
        }
    }
}
