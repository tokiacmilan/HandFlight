using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Leap;

namespace Leap.Unity
{

    public class Set : MonoBehaviour
    {
        Plane plane;
        Rigidbody rg;

        public Text text;
        public Text whichhand;

        float counttime=3f;
        float gotime = 1f;
        bool flag;
        bool rightgo;
        bool leftgo;

        // Use this for initialization
        void Start()
        {
            plane = this.GetComponent<Plane>();
            rg = this.GetComponent<Rigidbody>();
            flag = true;
            rightgo = false;
            leftgo = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (flag)
            {
                rg.velocity = new Vector3(0f, 0f, 0f);

                if (plane.RightHandSet()==true || plane.LeftHandSet()==true)
                {
                    counttime -= Time.deltaTime;
                    text.text = ((int)counttime + 1).ToString();

                    if (plane.RightHandSet() == true && plane.LeftHandSet() == false)
                    {
                        whichhand.text = "You set right hand";
                    }
                    if (plane.RightHandSet() == false && plane.LeftHandSet() == true)
                    {
                        whichhand.text = "You set left hand";
                    }
                    if (plane.RightHandSet() == true && plane.LeftHandSet() == true)
                    {
                        whichhand.text = "";
                        text.text = "One side of hand only!";
                        counttime = 3f;
                    }
                }
                else
                {
                    counttime = 3f;
                    text.text = "Set hand!";
                    whichhand.text = "";
                }

                if (counttime <= 0)
                {
                    flag = false;
                    whichhand.text = "";

                    if (plane.RightHandSet()==true && plane.LeftHandSet()==false)
                    {
                        rightgo = true;
                    }
                    if (plane.RightHandSet()==false && plane.LeftHandSet()==true)
                    {
                        leftgo = true;
                    }
                    if(plane.RightHandSet() == true && plane.LeftHandSet() == true)
                    {
                        rightgo = true;
                    }
                }
            }
            else
            {
                text.text = "GO!!";
                gotime -= Time.deltaTime;
                if (gotime <= 0)
                    text.text = "";
            }
        }

        public bool RightGo()
        {
            return rightgo;
        }

        public bool LeftGo()
        {
            return leftgo;
        }
    }
}
