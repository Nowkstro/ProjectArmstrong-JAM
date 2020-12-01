using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskSystemPlayer : MonoBehaviour
{
    [SerializeField] private List<Task> taskList = new List<Task>();

    public void MakeTask(Task currentTask)
    {
        foreach(Task task in taskList)
        {
            if(currentTask == task)
            {
                task.DoTask(gameObject, () =>
                {
                    Debug.Log("Tarefa " + task.gameObject.name + " terminada.");
                    //task.gameObject
                });
                break;
            }

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
