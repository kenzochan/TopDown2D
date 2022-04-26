using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TopDown2D
{
    public class SkillSystem : MonoBehaviour
    {
        [Serializable]
        public struct Skill
        {
            public GameObject skill;
            public int skillLevel;
        }

        public Skill[] skills;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

