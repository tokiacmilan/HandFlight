using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Leap.Unity
{

    public class PlaneAudio : MonoBehaviour
    {

        public AudioClip standard;
        public AudioClip fast;
        public AudioClip faststart;
        public AudioClip shoot;
        public AudioClip exp;
        public AudioClip getring;
        public AudioClip getitem;

        bool fast_flag;
        bool shoot_flag;
        bool exp_flag;
        bool getring_flag;
        bool getitem_flag;


        AudioSource child_as;
        AudioSource this_as;
        Set set;

        // Use this for initialization
        void Start()
        {
            child_as = transform.Find("morePlane").gameObject.GetComponent<AudioSource>();
            this_as = this.GetComponent<AudioSource>();
            set = this.GetComponent<Set>();
            child_as.Play();

            fast_flag = true;
            shoot_flag = true;
            exp_flag = true;
            getring_flag = true;
            getitem_flag = true;
        }

        // Update is called once per frame
        void Update()
        {

            child_as.UnPause();

            if (set.RightGo() == false && set.LeftGo() == false)
            {
                child_as.Pause();
            }

        }


        public void PlayPlaneAudio()
        {
            child_as.UnPause();
        }

        public void StopPlaneAudio()
        {
            child_as.Pause();
        }
        

        public void PlayFast()
        {
            if (fast_flag)
            {
                fast_flag = false;
                child_as.clip = fast;
                child_as.Play();
            }
        }

        public void StopFast()
        {
            fast_flag = true;
            child_as.clip=standard;
            child_as.Play();
        }
        

        public void PlayFastStart()
        {
            this_as.clip = faststart;
            this_as.Play();
        }


        public void PlayShoot()
        {
            this_as.clip = shoot;
            this_as.Play();
        }


        public void PlayExp()
        {
            if (exp_flag)
            {
                exp_flag = false;
                this_as.clip = exp;
                this_as.Play();
                Debug.Log("exp!!");
            }
        }

        public void StopExp()
        {
            exp_flag = true;
            this_as.Stop();
        }


        public void PlayGetRing()
        {
            this_as.clip = getring;
            this_as.Play();
        }


        public void PlayGetItem()
        {
            this_as.clip = getitem;
            this_as.Play();
        }
    }
}
