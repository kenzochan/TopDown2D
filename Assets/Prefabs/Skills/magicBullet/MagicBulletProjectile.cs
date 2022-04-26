using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 What it does? When spawned, moves straight in line with *projectileSpeed* speed to the *target* location, dealing *damage* to Characters in the way
 How it works? Commonly spawned by the MagicBulletSkill script. The values of this script is setted on the skill MagicBulletSkill
     */

namespace TopDown2D
{
    public class MagicBulletProjectile : MonoBehaviour
    {
        [HideInInspector] public int damage;
        [HideInInspector] public float projectileSpeed;
        [HideInInspector] public Transform target;
        Vector3 targetPosition;
        Vector3 normalizedDirection;

        // Start is called before the first frame update
        void Start()
        {         
            targetPosition = target.position;
            normalizedDirection = (target.position - transform.position).normalized;

            //rotate projectile
            Vector3 relative = transform.InverseTransformPoint(target.position);
            float angle = Mathf.Atan2(relative.y, relative.x) * Mathf.Rad2Deg;
            transform.Rotate(0, 0, angle);
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            //move infinitely forward
            transform.position += normalizedDirection * projectileSpeed * Time.fixedDeltaTime;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(target != null)
                if (collision.gameObject.layer == target.gameObject.layer)
                    collision.GetComponent<Character>().TakeDamage(damage);            
        }
    }

}
