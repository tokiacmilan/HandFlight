using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Leap.Unity
{

    public class Shoot : MonoBehaviour
    {

        public GameObject bullet;
        public GameObject shootpoint;
        public Text shoot_text;
        Plane plane;
        Set set;
        PlaneAudio pa;

        float speed=500;
        int item;
        bool shoot_flag;

        float current_time;
        float pre_time;

        // Use this for initialization
        void Start()
        {
            pa = this.GetComponent<PlaneAudio>();
            set=this.GetComponent<Set>();
            shootpoint = transform.Find("ShootPoint").gameObject;
            plane = this.GetComponent<Plane>();
            item =0;
            current_time = 0f;
        }

        // Update is called once per frame
        void Update()
        {
            current_time += Time.deltaTime;

            Debug.Log(set.RightGo() + "" + set.LeftGo());

            if (set.RightGo())
            {
                if (plane.RightThumb() == true)
                    shoot_flag = true;

                if (plane.RightThumb() == false && shoot_flag == true)
                {
                    if (item > 0)
                    {
                        ShootBullet();
                        item--;
                        shoot_flag = false;
                    }
                }
            }

            if (set.LeftGo())
            {
                if (plane.LeftThumb() == true)
                    shoot_flag = true;

                if (plane.LeftThumb() == false && shoot_flag == true)
                {
                    if (item > 0)
                    {
                        ShootBullet();
                        item--;
                        shoot_flag = false;
                    }
                }
            }

            shoot_text.text = "SHOT: " + item;
        }

        void ShootBullet()
        {
            pa.PlayShoot();
            bullet = GameObject.Instantiate(bullet) as GameObject;
            bullet.SetActive(true);
            bullet.transform.position = shootpoint.transform.position;

            Vector3 force = this.transform.forward * speed;
            bullet.GetComponent<Rigidbody>().velocity = force;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("ShootItem"))
            {
                Debug.Log(current_time - pre_time + " " + set.RightGo() + " " +set.LeftGo());
                if ((current_time - pre_time) > 0.1)
                {
                    pa.PlayGetItem();
                    item++;
                }
            }

            pre_time = current_time;
        }
    }
}
