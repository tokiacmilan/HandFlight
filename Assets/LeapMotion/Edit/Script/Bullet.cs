using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obst"))
        {
            this.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("AbsoObst"))
        {
            this.gameObject.SetActive(false);
        }
    }

}
