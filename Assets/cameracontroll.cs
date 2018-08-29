using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Leap.Unity
{

    public class cameracontroll : MonoBehaviour
    {

        public GameObject cameraPosition;
        public float move;
        public float fast;

        Plane plane;

        // Use this for initialization
        void Start()
        {
            plane = transform.root.gameObject.GetComponent<Plane>();
        }

        // Update is called once per frame
        void Update()
        {
            float x_val = Random.Range(-0.1f, 0.1f);
            float y_val = Random.Range(-0.1f, 0.1f);
            float z_val = Random.Range(-0.1f, 0.1f);
            transform.position = cameraPosition.transform.position + new Vector3(x_val, y_val, z_val) * move;

            if (plane.GetAccel())
            {
                transform.position = cameraPosition.transform.position + new Vector3(x_val, y_val, z_val) * fast;

            }
        }
    }
}
