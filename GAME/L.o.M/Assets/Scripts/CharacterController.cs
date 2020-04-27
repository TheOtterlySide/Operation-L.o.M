﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 10.0f;
    private float translation;
    private float straffe;
    Rigidbody player; //allows what rigidbody the player will be
    public float jumpForce = 10f; //how much force you want when jumping
    private bool onGround; //allows the functions to determine whether player is on the ground or not

    // Use this for initialization
    void Start()
    {
        // turn off the cursor
        Cursor.lockState = CursorLockMode.Locked;
        //grabs the Rigidbody from the player
        player = GetComponent<Rigidbody>();
        //says that the player is on the ground at runtime
        onGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Input.GetAxis() is used to get the user's input
        // You can furthor set it on Unity. (Edit, Project Settings, Input)
        if (onGround == true)
        {
            straffe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        }
        else
        {
            straffe = Input.GetAxis("Horizontal") * (speed*0.3f) * Time.deltaTime; ;
        }
        translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(straffe, 0, translation);

        if (Input.GetKeyDown("escape"))
        {
            // turn on the cursor
            Cursor.lockState = CursorLockMode.None;
        }

        //checks if the player is on the ground when the "Jump" button is pressed
        if (Input.GetButton("Jump") && onGround == true)
        {
            //adds force to player on the y axis by using the flaot set for the variable jumpForce. Causes the player to jump
            player.velocity = new Vector3(0f, jumpForce, 0f);
            //says the player is no longer on the ground
            onGround = false;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        //checks if collider is tagged "ground"
        if (other.gameObject.CompareTag("ground"))
        {
            //if the collider is tagged "ground", sets onGround boolean to true
            onGround = true;
        }
    }
}
