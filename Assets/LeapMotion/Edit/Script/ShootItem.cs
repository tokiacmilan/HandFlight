using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootItem : MonoBehaviour {

    private void Start()
    {
        this.GetComponent<Rigidbody>().angularVelocity = new Vector3(0f, 1f, 1f);
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player")){
            Destroy(this.gameObject);
        }
    }
}
