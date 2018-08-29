using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Leap.Unity
{
    public class Obst : MonoBehaviour
    {
        public GameObject sound;
        public GameObject Particle;
        public GameObject ring;

        Rigidbody rg;
        Set set;

        GameObject plane;

        private void Start()
        {
            plane = GameObject.Find("Plane");
            rg = this.GetComponent<Rigidbody>();
            set = plane.GetComponent<Set>();
        }

        private void Update()
        {
            if (set.RightGo() == true || set.LeftGo() == true)
            {
                rg.velocity = new Vector3(0f, 0f, -40f);
                rg.angularVelocity = new Vector3(-3f, 0f, 0f);
            }

            if (plane.transform.position.z - this.transform.position.z > 10)
            {
                Destroy(this.gameObject);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Bullet"))
            {
                Instantiate(sound, this.transform.position,Quaternion.identity);

                GameObject part = Instantiate(Particle, this.transform.position, Quaternion.identity);

                part.transform.localScale = this.transform.lossyScale;

                GameObject r = GameObject.Instantiate(ring) as GameObject;
                r.transform.position = this.transform.position;

                Destroy(this.gameObject);
            }
        }
    }
}