using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* You must assign the target and the Character*/

namespace TopDown2D
{
    [RequireComponent(typeof(Character), typeof(Transform))]
    public class MovementFollowTarget : MonoBehaviour
    {        
        public Transform target;
        public Character character;

        private Vector2 directionToTarget;        
        private Rigidbody2D rb;
        private float moveSpeed;
        private float acceleration;
        Vector2 movementDirection;
        Vector2 lastDirection;

        // Start is called before the first frame update
        void Start()
        {
            moveSpeed = character.moveSpeedDefault;
            rb = character.GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            SetFacingDirection();
        }

        private void FixedUpdate()
        {
            MoveCharacter(moveSpeed, acceleration);
        }

        public void MoveCharacter(float moveSpeed, float acceleration)
        {
            //face the player
            directionToTarget = (target.transform.position - character.transform.position).normalized;
            //move to player          
            rb.MovePosition(rb.position + directionToTarget * moveSpeed * Time.fixedDeltaTime);
        }

        //Defines the direction the enemy is facing
        public void SetFacingDirection()
        {
            float xDistance = character.transform.position.x - target.transform.position.x;
            if (xDistance > 0)
                character.isFacingRight = false;
            else if (xDistance < 0)
                character.isFacingRight = true;
        }
    }
}