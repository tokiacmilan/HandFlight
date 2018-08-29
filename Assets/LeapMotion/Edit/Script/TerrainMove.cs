using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainMove : MonoBehaviour {

    public Transform plane;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 p = this.transform.position;

        if ((plane.position.z - p.z) > 2500)
        {
            this.transform.position = new Vector3(p.x, p.y, p.z + 4000);
        }
	}
}
