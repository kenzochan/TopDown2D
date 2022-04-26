using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* What is does? Find for avaiable targets with the variable *avaiableTargets* and the nearest target with the variable *nearestTarget*
 * How it works? You must assign layermask targets and set the Transform that own this script*/

public class AvaiableTargets : MonoBehaviour
{
    public LayerMask layerMask;

    [HideInInspector] public List<Transform> avaiableTargets;
    [HideInInspector] public Transform nearestTarget;
    [HideInInspector] public float nearestTargetDistance = 1000000;

    [Header("Script Owner")] [Tooltip("Character that is using this script")]
    public Transform character;

    private void Awake()
    {
        FindNearestTarget();
    }

    private void Update()
    {
        FindNearestTarget();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if(layerMask == (layerMask | (1 << collision.gameObject.layer)))
        {
            avaiableTargets.Add(collision.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (layerMask == (layerMask | (1 << collision.gameObject.layer)))
        {
            avaiableTargets.Remove(collision.transform);
            if(collision.transform == nearestTarget)
            {
                nearestTargetDistance = 1000000;
                nearestTarget = null;
            }
        }
    }

    void FindNearestTarget()
    {                
        foreach (Transform target in avaiableTargets)
        {
            float distance = Vector2.Distance(character.position, target.position);            
            if (distance < nearestTargetDistance)
            {
                nearestTargetDistance = distance;
                nearestTarget = target;
            }            
        }
        nearestTargetDistance = 1000000;
    }

    public bool hasAvaiableTarget()
    {
        if (avaiableTargets != null) return true;
        else
        {
            nearestTarget = null;
            return false; 
        }
        
    }
}
