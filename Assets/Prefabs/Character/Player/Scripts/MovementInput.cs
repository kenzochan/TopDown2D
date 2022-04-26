using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 What it does? Moves the *character* with the velocity *moveSpeed* using it's *rigidBody* by the player's inputs
 How it works? It needs the reference of the rigidbody and script Character that is being moved.
               It's speed is setted by the Character script
     */

namespace TopDown2D
{
    [RequireComponent(typeof(Character))]
    public class MovementInput : MonoBehaviour
    {
        [Header("Object Reference")]
        public Rigidbody2D rigidBody;
        public Character character;

        Vector2 movementDirection;
        float moveSpeed;

        private void Start()
        {
            moveSpeed = character.moveSpeedDefault;
        }

        //Get inputs
        private void Update()
        {
            movementDirection.x = UnityEngine.Input.GetAxis("Horizontal");
            movementDirection.y = UnityEngine.Input.GetAxis("Vertical");
            movementDirection.Normalize();
            SetFacingDirection();
        }

        private void FixedUpdate()
        {
            MoveCharacter(rigidBody, movementDirection, moveSpeed);
        }
        
        public void MoveCharacter(Rigidbody2D rb, Vector2 movementDirection, float moveSpeed)
        {
            rb.MovePosition(rb.position + movementDirection * moveSpeed * Time.fixedDeltaTime);
        }

        //Defines the direction the player is facing
        public void SetFacingDirection()
        {
            if (movementDirection.x > 0)
                character.isFacingRight = true;
            else if (movementDirection.x < 0)
                character.isFacingRight = false;
        }
    }
}