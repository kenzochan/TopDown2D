using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This is the main script of the TopDown2D project, most of scripts of this project use it.
 * What it does? Set and control the stats of the Character
 * How it works? Set mannualy the max and default stats of the character
                 Other scripts may call this script to change it's values*/


namespace TopDown2D
{
    public class Character : MonoBehaviour
    {
        [Header("Variable stats")]
        public int healthCurrent;
        public float moveSpeedCurrent;
        public bool isFacingRight = true;
        public bool isInvulnerable;

        [Header("Max stats")]
        public int healthMax;
        public int moveSpeedMax;

        [Header("Default stats")]
        public int healthDefault = 100;
        public float moveSpeedDefault = 1;
        public float invulnerabilityAfterTakingDamage;

        private Vector3 lastPosition;
        private Rigidbody2D rigidBody;

        // Start is called before the first frame update
        void Start()
        {
            rigidBody = GetComponent<Rigidbody2D>();
            healthCurrent = healthDefault;
        }

        private void Update()
        {
            
        }

        private void FixedUpdate()
        {
            CalculateMoveSpeed();
        }

        //Calculates the move speed of this character
        private void CalculateMoveSpeed()
        {
            moveSpeedCurrent = (transform.position - lastPosition).magnitude / Time.deltaTime;
            lastPosition = transform.position;
        }

        //Deal *damageAmount* damage to this character if it is not invulnerable
        public void TakeDamage(int damageAmount)
        {
            if (!isInvulnerable)
            {
                healthCurrent -= damageAmount;
                if (healthCurrent <= 0)
                {
                    //destroy this character
                    Die(transform.gameObject);
                }
            }
        }

        //Heal this character by the *healAmount* and if it overcome the max amount, set the current health to the max amount
        public void HealMe(int healAmount)
        {
            healthCurrent += healAmount;
            if (healthCurrent >= healthMax)
            {
                healthCurrent = healthMax;
            }
        }

        //Destroy the character
        public void Die(GameObject character)
        {
            Destroy(character);
        }
    }
}
