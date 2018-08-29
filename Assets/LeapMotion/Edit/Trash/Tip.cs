using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Leap.Unity
{

    public class Tip : MonoBehaviour
    {
        LeapServiceProvider sp;
        public GameObject obj;



        // Use this for initialization
        void Start()
        {
            sp = obj.GetComponent<LeapServiceProvider>();
        }

        void Update()
        {
            Frame frame = sp.CurrentFrame;
            Hand r_hand=null;

            foreach (Hand hand in frame.Hands)
            {
                if (hand.IsRight)
                {
                    r_hand = hand;
                    break;
                }
            }

            Vector3 tip = r_hand.Fingers[1].TipPosition.ToVector3();
            tip.x *= 4580;
            tip.y *= 2320;

            this.transform.position = tip;

            Debug.Log(r_hand.Fingers[1].Direction + "    " + r_hand.Confidence);
        }

    }
}