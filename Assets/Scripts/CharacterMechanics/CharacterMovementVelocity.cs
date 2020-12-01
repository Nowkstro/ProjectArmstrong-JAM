using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementVelocity : MonoBehaviour
{
    private int moveSpeed;

    private Vector3 velocityVector;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Awake()
    {
        moveSpeed = GetComponent<CharacterStats>().MoveSpeed;
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetVelocity(Vector3 velocityVector)
    {
        this.velocityVector = velocityVector;
    }

    public void MoveTowards(Vector3 target)
    {
        this.velocityVector = target;
    }

    public void Stop()
    {
        this.velocityVector = Vector3.zero;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = velocityVector * moveSpeed;
        velocityVector = Vector3.zero;
    }
}
