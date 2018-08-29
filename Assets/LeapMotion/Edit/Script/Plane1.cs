using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;

namespace Leap.Unity
{

    public class Plane1 : MonoBehaviour
    {
        public GameObject controller;
        LeapServiceProvider service;
        bool accel = false;
        bool obst = false;
        bool righthandset = false;
        bool lefthandset = false;

        Hand righthand = null;
        Hand lefthand = null;

        Vector3 prepos;
        Vector3 preprepos;

        static int ring_count;
        float turnsize;


        // Use this for initialization
        void Start()
        {
            prepos = new Vector3(0f, 0f, 0f);
            preprepos= new Vector3(0f, 0f, 0f);
            ring_count = 0;
            service = controller.GetComponent<LeapServiceProvider>();
        }

        // Update is called once per frame
        void Update()
        {
            Frame frame = service.CurrentFrame;

            righthand = null;
            lefthand = null;



            foreach(Hand hand in frame.Hands)       /*右手の取得*/
            {
                if (hand.IsRight)
                {
                    righthand = hand;
                    righthandset = true;
                    break;
                }
            }

            foreach (Hand hand in frame.Hands)       /*左手の取得*/
            {
                if (hand.IsLeft)
                {
                    lefthand = hand;
                    lefthandset = true;
                    break;
                }

            }

            if (righthand == null)
            {
                righthandset = false;
            }
            if (lefthand == null)
            {
                lefthandset = false;
            }



            Debug.Log(ring_count+"  right is " +righthandset + "  left is "+lefthandset);

            if (righthand != null)                  /*右手の向きに機体を向ける*/
            {
                Vector3 palm_d = righthand.Direction.ToVector3();

                this.transform.forward = new Vector3((palm_d.x + prepos.x + preprepos.x)/3f, (palm_d.y + prepos.y + preprepos.y) / 3f, (palm_d.z + prepos.z + preprepos.z) / 3f);

                prepos = palm_d;
                preprepos = prepos;

                turnsize = (palm_d - (new Vector3(0, 0, 1f))).sqrMagnitude;
            }

        }


        public void OnTriggerEnter(Collider other)                  /*物体との衝突判定*/
        {
            if (other.gameObject.CompareTag("SpeedUpItem"))         /*SpeedUpItemとの衝突判定*/
            {
                accel = true;
            }

            if (other.gameObject.CompareTag("Ring"))
            {
                ring_count++;
            }

            if (other.gameObject.CompareTag("Obst") || other.gameObject.CompareTag("AbsoObst"))
            {
                obst = true;
            }

        }




        public bool GetAccel()                  /*accelを返す関数*/
        {
            return accel;
        }

        public void ChangeAccelToFalse()        /*accelをfalseにする関数*/
        {
            accel = false;
        }

        public bool GetObst()                   /*obstを返す関数*/
        {
            return obst;
        }

        public void ChangeObstToFalse()         /*obstをfalseにする関数*/
        {
            obst = false;
        }

        public bool Thumb()                     /*親指の折り曲げ判定*/
        {
            return righthand.Fingers[0].IsExtended;
        }

        public bool Index()                     /*人差し指の折り曲げ判定*/
        {
            return righthand.Fingers[1].IsExtended;
        }

        public bool RightHandSet()
        {
            return righthandset;
        }

        public bool LeftHandSet()
        {
            return lefthandset;
        }

        public static int GetRingCount()
        {
            return ring_count;
        }
    }
}
