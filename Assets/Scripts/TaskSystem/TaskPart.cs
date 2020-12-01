using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskPart : MonoBehaviour
{
    [SerializeField] GameObject player = default;
    [SerializeField] Task mainTask = default;
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TaskPart");
        if (collision.gameObject == player)
        {
            player.GetComponent<TaskSystemPlayer>().MakeTask(mainTask);
            Destroy(gameObject);
        }
    }
}
