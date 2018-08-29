using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyButton2 : MonoBehaviour {

	// Use this for initialization
public void OnClick()
    {
        Debug.Log("Button2 click!");

        gameObject.SetActive(false);

        MyCanvas.SetActive("Button", true);
    }
}
