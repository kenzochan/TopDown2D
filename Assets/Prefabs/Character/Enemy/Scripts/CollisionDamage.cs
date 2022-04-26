using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*What is does? Attacks every *attackCooldown* while colliding with the *target*, dealing *damage*
 * How to use it? The target must have the script Character and set the variables values*/

namespace TopDown2D
{
    public class CollisionDamage : MonoBehaviour
    {
        [Header("Set variables")]        
        public Character target;
        public int damage = 10;
        public float attackCooldown = 1;

        private float attackTimer = 0;        
        private string targetTag;
        [HideInInspector] public bool isCollidingWithTarget = false;
        // Start is called before the first frame update
        void Start()
        {            
            targetTag = target.tag;
        }

        // Update is called once per frame
        void Update()
        {
            attackTimer += Time.deltaTime;
            if (isCollidingWithTarget)
                DealDamage(damage, target);

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.tag == targetTag)
                isCollidingWithTarget = true;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.transform.tag == targetTag)
            {
                isCollidingWithTarget = false;
            }
                
        }

        private void DealDamage(int damageDealt, Character target)
        {
            if (attackTimer >= attackCooldown)
            {
                this.target.TakeDamage(damageDealt);
                attackTimer = 0;
            }
        }
    }
}