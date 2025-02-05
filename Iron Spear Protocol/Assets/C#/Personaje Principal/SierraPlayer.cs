using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SierraPlayer : MonoBehaviour
{
    public float moveSpeed = 5f;
    Vector2 direction;
    Rigidbody2D theRB;

    private void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        theRB.velocity = direction * moveSpeed;
    }

    private void Update()
    {
        Movement();
    }

    public void Movement()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }
}
