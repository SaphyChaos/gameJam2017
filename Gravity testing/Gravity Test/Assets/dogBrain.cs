using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class dogBrain : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {

        }
        private void OnEnable()
        {
            this.gameObject.GetComponentInParent<Platformer2DUserControlCombat>().enabled = true;
        }
        private void OnDisable()
        {
            this.gameObject.GetComponentInParent<Platformer2DUserControlCombat>().enabled = false;
        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}