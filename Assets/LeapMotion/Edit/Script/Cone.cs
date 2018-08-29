using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cone : MonoBehaviour {

    GameObject parent;

	// Use this for initialization
	void Start () {
        parent = this.transform.root.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.eulerAngles=new Vector3(0f,0f,0f);
        this.transform.position = parent.transform.position;
	}
}
