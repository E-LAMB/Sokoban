using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounds : MonoBehaviour
{

    public CameraScript my_camera;
    public string my_direction;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("run");
            my_camera.MoveCamera(my_direction);
        }
    }
}
