using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Leap;

namespace Leap.Unity {

    public class Move : MonoBehaviour
    {

        Rigidbody rg;
        Plane plane;
        Obst obst;
        Set set;
        PlaneAudio pa;

        GameObject fire;

        GameObject wing;
        GameObject wing2;

        float accel_timeout=3f;
        float obst_timeout = 1.5f;
        float timeElapsed=0f;

        public float Velocity = 10;
        public float Accel = 20;

        bool AccelNow;

        // Use this for initialization
        void Start()
        {
            accel_timeout = 3f;
            obst_timeout = 1.5f;
            timeElapsed = 0f;


            rg = this.GetComponent<Rigidbody>();
            plane = this.GetComponent<Plane>();
            rg.velocity = new Vector3(0f, 0f, Velocity);
            set = this.GetComponent<Set>();
            pa = this.GetComponent<PlaneAudio>();

            fire = transform.Find("Fire").gameObject;

            wing = transform.Find("morePlane/WingEffect").gameObject;
            wing2 = transform.Find("morePlane/WingEffect2").gameObject;

            wing.GetComponent<ParticleSystem>().Stop();
            wing2.GetComponent<ParticleSystem>().Stop();
        }

        private void Update()
        {
            Vector3 fw = this.transform.forward.normalized;     /*飛行機の正面のベクトルを取得*/

            if (set.RightGo()==true || set.LeftGo()==true)
            {
                if (plane.GetAccel())           /*加速アイテムを取ったときの処理*/
                {
                    pa.PlayFast();


                    if (plane.MoreAccel())
                    {
                        timeElapsed = 0f;
                        plane.ChangeMoreToFalse();
                    }

                    rg.velocity = Accel * fw;
                    timeElapsed += Time.deltaTime;

                    wing.GetComponent<ParticleSystem>().Play();
                    wing2.GetComponent<ParticleSystem>().Play();

                    

                    if (timeElapsed > accel_timeout)
                    {
                        pa.StopFast();

                        plane.ChangeAccelToFalse();
                        timeElapsed = 0;
                        wing.GetComponent<ParticleSystem>().Stop();
                        wing2.GetComponent<ParticleSystem>().Stop();
                    }
                }

                if (plane.GetObst())            /*障害物に当たったときの処理*/
                {
                    pa.StopPlaneAudio();
                    pa.PlayExp();

                    if (plane.GetAccel())       /*まず加速処理を取り消す*/
                    {
                        plane.ChangeAccelToFalse();
                        timeElapsed = 0f;
                        wing.GetComponent<ParticleSystem>().Stop();
                        wing2.GetComponent<ParticleSystem>().Stop();
                    }

                    fire.SetActive(true);

                    rg.velocity = 0f * fw;
                    timeElapsed += Time.deltaTime;

                    if (timeElapsed > obst_timeout)
                    {
                        //pa.StopExp();
                        //pa.PlayPlaneAudio();

                        //this.transform.position = new Vector3(0f, 0f, 0f);
                        //timeElapsed = 0f;

                        //fire.SetActive(false);

                        //plane.ChangeObstToFalse();

                        SceneManager.LoadScene("test4");
                    }

                }

                if (plane.GetAccel() == false && plane.GetObst() == false)
                {
                    rg.velocity = Velocity * fw;
                }



////////////////////////////////////////////////コース内に留まらせる//////////

                float x = this.transform.position.x;
                float y = this.transform.position.y;
                float z = this.transform.position.z;


                //if (this.transform.position.x > 250)
                //{
                //    Debug.Log("right over");
                //    this.transform.position=new Vector3(250f,y,z);
                //}
                //if (this.transform.position.x < -250)
                //{
                //    Debug.Log("left over");
                //    this.transform.position = new Vector3(-250f, y, z);
                //}
                if (this.transform.position.y > 150)
                {
                    Debug.Log("up over");
                    this.transform.position = new Vector3(x, 100, z);
                }
                if (this.transform.position.y < -130)
                {
                    Debug.Log("down over");
                    this.transform.position = new Vector3(x, -130, z);
                }

            }
        }
    }

}
