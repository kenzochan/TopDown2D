using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*What it does? Controls some visuals of the character
 * How it works? It calls the Character script to check it's facing position, fliping the sprite*/

namespace TopDown2D
{
    public class CharacterVisual : MonoBehaviour
    {
        public Character character;
        SpriteRenderer spriteRenderer;

        // Start is called before the first frame update
        void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            //Flip the sprite according to facing direction (left/right)
            if (character.isFacingRight)
                spriteRenderer.flipX = false;
            else
                spriteRenderer.flipX = true;
        }
    }
}