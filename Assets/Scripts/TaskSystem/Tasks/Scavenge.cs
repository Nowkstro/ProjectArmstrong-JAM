using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scavenge : Task
{
    public override void DoTask(GameObject character, Action onTaskFinished)
    {
        character.SetActive(false);
        isCooldown = true;
        Debug.Log("Exploração começou!");

        GetComponent<Timer>().AwaitForSeconds(2, () => {
            Debug.Log("Exploração terminada!");
            isCooldown = false;
            character.SetActive(true);
            onTaskFinished.Invoke();
        });
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
