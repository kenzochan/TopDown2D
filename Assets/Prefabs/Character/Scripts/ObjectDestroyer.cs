using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/* What it does? Destroys the objects that contains the specified tags
 * How to use: Attach collider2d with is trigger enabled
 *             Add the values of the tags */

namespace TopDown2D
{
    public class ObjectDestroyer : MonoBehaviour
    {
        public string[] tags;

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (tags.Contains(collision.tag))
            {
                Destroy(collision.gameObject);
            }
        }
    }

}
