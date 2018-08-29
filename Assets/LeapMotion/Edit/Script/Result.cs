using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Leap.Unity
{
    public class Result : MonoBehaviour
    {

        Text text;
        public Text score;

        // Use this for initialization
        void Start()
        {
            text = this.GetComponent<Text>();
            text.text = "Your time is " + Goal.GetTime().ToString("N3") + "\n" + "You got " + Plane.GetRingCount() + " ring bonus\n" + "Your final time is...";
            score.text = (Goal.GetTime() - Plane.GetRingCount()).ToString("N3");
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}