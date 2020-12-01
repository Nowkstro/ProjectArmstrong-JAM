using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementByGoal : MonoBehaviour, IUnit
{
    private enum State
    {
        Idle,
        Moving,
        Animating,
    }

    private State state = State.Idle;
    public bool IsIdle()
    {
        return state == State.Idle;
    }

    void IUnit.MoveTo(Vector3 position, float stopDistance, Action onArrivedAtPosition)
    {
        if(Vector3.Distance(gameObject.transform.position, position) > stopDistance) {
            state = State.Moving;
            Vector3 moveDir = (position - transform.position).normalized;
            GetComponent<CharacterMovementVelocity>().MoveTowards(moveDir);
        }
        else {
            
            onArrivedAtPosition.Invoke();
            state = State.Idle;
        }
    }

    void IUnit.PlayAnimation(Vector3 lookAtPosition, Action onAnimationCompleted)
    {
        Debug.Log("Animação braba");
        onAnimationCompleted.Invoke();
    }
}
