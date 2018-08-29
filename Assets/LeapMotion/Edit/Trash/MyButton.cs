using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyButton : MonoBehaviour {

    public void OnClick()
    {
        Debug.Log("Button click!");
        gameObject.SetActive(false);

        MyCanvas.SetActive("Button2", true);
    } 
}
