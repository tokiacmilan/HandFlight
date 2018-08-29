using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Leap.Unity
{

    public class Goal : MonoBehaviour
    {
        static float time=0;
        static float finaltime;
        public Text time_text;
        Set set;

        private void Start()
        {
            set = GameObject.Find("Plane").gameObject.GetComponent<Set>();
            time = 0;
        }

        private void Update()
        {
            if (set.RightGo()==true || set.LeftGo()==true)
            {
                time += Time.deltaTime;
            }
            time_text.text = "TIME: " + time + "\n" + "Ring: " + Plane.GetRingCount();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                finaltime = time;
                Debug.Log("GOAL!!!");
                SceneManager.LoadScene("Goal");

            }
        }

        public static float GetTime()
        {
            return finaltime;
        }
    }
}
