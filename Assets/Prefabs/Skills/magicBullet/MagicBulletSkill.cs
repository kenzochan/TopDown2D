using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*What it does? Spawns a MagicBulletProjectile and sets its properties
 
     How it works? You must set the references of the prefab and the script AvaiableTargets*/

namespace TopDown2D
{
    public class MagicBulletSkill : MonoBehaviour
    {
        [Header("Set variables")]
        public int damage;
        public float cooldown;
        public float projectileSpeed;
        public LayerMask layerMask;

        [Header("Set references")]
        public Transform magicBulletProjectilePrefab;
        public AvaiableTargets avaiableTargets;        

        private MagicBulletProjectile magicBulletProjectile;
        private float cooldownTimer;

        // Start is called before the first frame update
        void Start()
        {
            layerMask = avaiableTargets.layerMask;
        }

        // Update is called once per frame
        void Update()
        {
            cooldownTimer += Time.deltaTime;
            if (avaiableTargets.hasAvaiableTarget())
            {
                if(cooldownTimer > cooldown)
                {
                    if(avaiableTargets.nearestTarget != null)
                    {
                        Transform nearestTarget = avaiableTargets.nearestTarget;
                        magicBulletProjectile = Instantiate(magicBulletProjectilePrefab, transform.position, Quaternion.identity).GetComponent<MagicBulletProjectile>();
                        magicBulletProjectile.damage = damage;
                        magicBulletProjectile.projectileSpeed = projectileSpeed;
                        magicBulletProjectile.target = nearestTarget;

                        cooldownTimer = 0;
                    }
                    
                }
            }
        }
    }
}

