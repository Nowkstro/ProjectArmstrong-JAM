using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskSystemAI : MonoBehaviour
{
    public static event EventHandler OnWorkerClicked;

    [SerializeField] private SpriteRenderer selector = default;
    private bool isSelected = false;

    private enum State
    {
        Idle,
        MovingToObjective,
        DoingTask,
    }

    private IUnit unit;
    private State state;
    private Transform resourceNodeTransform;
    [SerializeField] private GameObject brokenShipObj = default;
    private BrokenShip brokenShip;
    private Task currentTask;

    void Awake()
    {
        brokenShip = brokenShipObj.GetComponent<BrokenShip>();
        unit = gameObject.GetComponent<IUnit>();

        state = State.Idle;
    }

    void Update()
    {
        switch (state)
        {
            case State.Idle:
                GetComponent<CharacterMovementVelocity>().Stop();
                break;
            case State.MovingToObjective:
                unit.MoveTo(currentTask.transform.position, 4.7f, () =>
                {
                    state = State.DoingTask;
                });
                break;
            case State.DoingTask:
                if (unit.IsIdle())
                {
                    if (!currentTask.IsCooldown)
                    {
                        currentTask.DoTask(gameObject, () => {
                            state = State.Idle;
                        });
                    }
                }
                break;
        }
    }

    private void OnMouseDown()
    {
        isSelected = !isSelected;
        selector.enabled = isSelected;
        OnWorkerClicked?.Invoke(this, EventArgs.Empty);
    }

    public void SetTask(Task task)
    {
        this.currentTask = task;
        state = State.MovingToObjective;
    }
}
