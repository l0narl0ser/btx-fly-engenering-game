using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class CameraController : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            Camera.main.gameObject.SetActive(false);
            Camera.main.gameObject.SetActive(true);
        }     

    }
}