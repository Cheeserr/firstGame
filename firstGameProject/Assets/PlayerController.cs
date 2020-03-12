using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController2D controller;

    private float horizontalMove = 0f;
    public float speed = 20f;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");

    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * speed * Time.fixedDeltaTime, false, false);
    }
}
