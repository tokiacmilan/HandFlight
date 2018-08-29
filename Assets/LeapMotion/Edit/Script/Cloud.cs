using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {

    public GameObject plane;

    bool flag=true;
	
	// Update is called once per frame
	void Update () {
        if (plane.transform.position.z > 7000)
        {
            if (flag)
            {
                flag = false;
                this.GetComponent<AudioSource>().Play();
            }
        }
	}
}
