using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;

namespace Leap.Unity
{

    public class Plane : MonoBehaviour
    {
        public GameObject controller;
        public GameObject rain;
        LeapServiceProvider service;

        Set set;
        PlaneAudio pa;

        GameObject more;

        bool accel = false;
        bool obst = false;
        bool righthandset = false;
        bool lefthandset = false;
        bool More = false;
        bool rainflag=true;

        Hand righthand = null;
        Hand lefthand = null;

        Vector3 prepos;
        Vector3 preprepos;
        

        static int ring_count;

        float current_time;
        float pre_time;


        // Use this for initialization
        void Start()
        {
            pa = this.GetComponent<PlaneAudio>();
            set = this.GetComponent<Set>();
            more = this.transform.Find("morePlane").gameObject;
            prepos = new Vector3(0f, 0f, 0f);
            preprepos = new Vector3(0f, 0f, 0f);
            ring_count = 0;
            service = controller.GetComponent<LeapServiceProvider>();
            current_time = 0f;
        }

        // Update is called once per frame
        void Update()
        {
            Frame frame = service.CurrentFrame;

            righthand = null;
            lefthand = null;

            pre_time = current_time;
            current_time += Time.deltaTime;


            foreach (Hand hand in frame.Hands)       /*右手の取得*/
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



            Vector3 palm_d;
            Vector3 palm2;

            if (set.LeftGo() == false)
            {
                if (righthand != null)                  /*右手の向きに機体を向ける*/
                {
                    palm_d = righthand.Direction.ToVector3();

                    this.transform.forward = new Vector3((palm_d.x + prepos.x + preprepos.x) / 3f, (palm_d.y + prepos.y + preprepos.y) / 3f, (palm_d.z + prepos.z + preprepos.z) / 3f);

                    prepos = palm_d;
                    preprepos = prepos;

                    var rotate = this.transform.rotation.eulerAngles;

                    palm2 = new Vector3(this.transform.forward.x * 0.01f, this.transform.forward.y * 0.1f, this.transform.forward.z);
                    more.transform.forward = palm2;
                    more.transform.Rotate(0f, 0f, rotate.z);
                    more.transform.Rotate(rotate.x, 0f, 0f);
                    more.transform.Rotate(0f, rotate.y, 0f);


                }
            }


            if (set.RightGo() == false)
            {
                if (lefthand != null)                  /*左手の向きに機体を向ける*/
                {
                    palm_d = lefthand.Direction.ToVector3();

                    this.transform.forward = new Vector3((palm_d.x + prepos.x + preprepos.x) / 3f, (palm_d.y + prepos.y + preprepos.y) / 3f, (palm_d.z + prepos.z + preprepos.z) / 3f);

                    prepos = palm_d;
                    preprepos = prepos;

                    var rotate = this.transform.rotation.eulerAngles;

                    palm2 = new Vector3(this.transform.forward.x * 0.01f, this.transform.forward.y * 0.1f, this.transform.forward.z);
                    more.transform.forward = palm2;
                    more.transform.Rotate(0f, 0f, rotate.z);
                    more.transform.Rotate(rotate.x, 0f, 0f);
                    more.transform.Rotate(0f, rotate.y, 0f);


                }
            }

            if (this.transform.position.z > 7600)
            {
                if (rainflag)
                {
                    RainStart();
                    rainflag = false;
                }
            }

            if (this.transform.position.z > 10000)
            {
                RainStop();
            }


        }



        public void OnTriggerEnter(Collider other)                  /*物体との衝突判定*/
        {

            if (other.gameObject.CompareTag("SpeedUpItem"))         /*SpeedUpItemとの衝突判定*/
            {
                pa.PlayFastStart();

                if (GetAccel()) {
                    More = true;
                }
                else
                {
                    accel = true;
                }
                    
            }

            if (other.gameObject.CompareTag("Ring"))
            {
                if (current_time - pre_time > 0.0001)
                {
                    pa.PlayGetRing();
                    ring_count++;
                }
            }

            if (other.gameObject.CompareTag("Obst") || other.gameObject.CompareTag("AbsoObst"))
            {
                obst = true;
            }

            pre_time = current_time;

        }



        void RainStart()
        {
            rain.SetActive(true);
        }

        void RainStop()
        {
            rain.SetActive(false);
        }



        public bool GetAccel()                  /*accelを返す関数*/
        {
            return accel;
        }

        public void ChangeAccelToFalse()        /*accelをfalseにする関数*/
        {
            accel = false;
        }

        public bool MoreAccel()
        {
            return More;
        }

        public void ChangeMoreToFalse()
        {
            More = false;
        }

        public bool GetObst()                   /*obstを返す関数*/
        {
            return obst;
        }

        public void ChangeObstToFalse()         /*obstをfalseにする関数*/
        {
            obst = false;
        }

        public bool RightThumb()                     /*右手の親指の折り曲げ判定*/
        {
            return righthand.Fingers[0].IsExtended;
        }

        public bool LeftThumb()                     /*左手の親指の折り曲げ判定*/
        {
            return lefthand.Fingers[0].IsExtended;
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
