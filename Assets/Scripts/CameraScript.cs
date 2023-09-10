using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public Transform my_camera;
    public Vector3 camera_position;
    public PlayerMovement player;

    public bool move_state;

    void Start()
    {
        camera_position = my_camera.position;
    }

    void Update()
    {
        my_camera.position = camera_position;
        if (move_state == true && player.can_move == true)
        {
            move_state = false;
        }
    }

    public void MoveCamera(string direction)
    {
        if (player.can_move != true && move_state == false)
        {
            move_state = true;
            Debug.Log("run");
            if (direction == "up")
            {
                camera_position += new Vector3 (0f, 8f, 0f);
            }
            if (direction == "down")
            {
                camera_position += new Vector3 (0f, -8f, 0f);
            }
            if (direction == "left")
            {
                camera_position += new Vector3 (-8f, 0f, 0f);
            }
            if (direction == "right")
            {
                camera_position += new Vector3 (8f, 0f, 0f);
            }

        }
    }
}
