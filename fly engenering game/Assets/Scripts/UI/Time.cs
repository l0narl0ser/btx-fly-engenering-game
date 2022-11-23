using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Game
{

    public class Time : MonoBehaviour
    {
        public float time = 0f;
        public float sec = 0.1f;
        //public TextMeshProUGUI value;

        void Start()
        {

        }


        void Update()
        {
            Timer();
        }

        public void Timer()
        {
            GameObject timeGo = GameObject.Find("Time");
            TMP_Text timeText = timeGo.GetComponent<TMP_Text>();
            float tm = float.Parse(timeText.text);
            tm += sec;
            timeText.text = tm.ToString();

        }
    }

}