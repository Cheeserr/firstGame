using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    private float horizontalMove = 0f;
    public float speed = 20f;
    bool jump = false;
    bool attacking = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if(Input.GetKeyDown(KeyCode.Space))
        {
        jump = true;
        animator.SetBool("IsJumping", true);
        }
    }

    public void OnLanding()
    { 
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate()
    {
        if (!attacking)
        {
            controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
            jump = false;
        }
    }

    public void AttackState()
    {
        if(jump)
        {

        }
        attacking = true;
    }

    public void AttackFinished(int value)
    {
        if(value.Equals(1))
        {

        }
    }
}
