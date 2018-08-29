using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour {

    GameObject plane;

	// Use this for initialization
	void Start () {
        plane = GameObject.Find("Plane");
	}
	
	// Update is called once per frame
	void Update () {
        if (plane.transform.position.z - this.transform.position.z > 20)
        {
            Destroy(this.gameObject);
        }
	}
}
