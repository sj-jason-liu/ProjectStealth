using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    //check for trigger of player
    //update the main camera to direct angle
    [SerializeField]
    private GameObject _camera;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Camera.main.transform.position = _camera.transform.position;
            Camera.main.transform.rotation = _camera.transform.rotation;
        }
    }
}
