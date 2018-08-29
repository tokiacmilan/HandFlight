using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Leap.Unity
{

    public class AbsoObst : MonoBehaviour
    {

        public Set set;
        Rigidbody rg;

        private void Start()
        {
            rg = this.GetComponent<Rigidbody>();
        }


        // Update is called once per frame
        void Update()
        {
            if(set.RightGo()==true || set.LeftGo() == true)
            {
                rg.velocity = new Vector3(0f, 0f, -20f);
                rg.angularVelocity = new Vector3(-1f, 0f, 0f);
            }
        }
    }
}
