using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Leap.Unity
{
    public class Ring : MonoBehaviour
    {

        private void Start()
        {
            this.GetComponent<Rigidbody>().angularVelocity = new Vector3(0f, 1f, 0f);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Destroy(this.gameObject);
            }
        }
    }
}