using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SierraPlayer : MonoBehaviour
{
    public float moveSpeed = 5f;
    Vector2 direction;
    Rigidbody2D theRB;
    Animator anim;
    private Vector2 moveInput;

    private void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        theRB.velocity = direction * moveSpeed;
    }

    private void Update()
    {
        Movement();
        Animations();
    }

    public void Movement()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    public void Animations()
    {
        anim.SetFloat("Horizontal", moveInput.x);
        anim.SetFloat("Vertical", moveInput.y);
        moveInput.Normalize(); // Evita que diagonal sea más rápida

        if (moveInput.magnitude != 0)anim.Play("Run");
        else anim.Play("Idle");
        
    }

}
