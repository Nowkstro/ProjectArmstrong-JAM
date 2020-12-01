using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenBT : Task
{
    [SerializeField] private List<GameObject> bodyParts = default;
    private int foundParts = 0;
    
    public override void DoTask(GameObject character, Action onTaskFinished)
    {
        foundParts++;
        Debug.Log("Partes coletadas: " + foundParts);
        if (foundParts == bodyParts.Count)
        {
            Debug.Log("Todas as partes coletadas!");
            GetComponent<DialogueTrigger>().ChangeConversation();
            onTaskFinished.Invoke();
        }
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
