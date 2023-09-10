using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Transform self_trans;
    public GameObject self_obj;

    public int direction;
    // 0 = up
    // 1 = right
    // 2 = down
    // 3 = left

    public Sprite[] my_sprites;
    public SpriteRenderer self_renderer;

    public bool can_move;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    bool PerformMovementCheck(bool valid_attack)
    {

    }

    // Update is called once per frame
    void Update()
    {
        self_renderer.sprite = my_sprites[direction];

        can_move = true;

        if (Input.GetKeyDown(Keycode.W))
        {
            direction = 0;
            can_move = false;
            PerformMovementCheck(true);
        }
        if (Input.GetKeyDown(Keycode.A))
        {
            
        }
        if (Input.GetKeyDown(Keycode.S))
        {
            
        }
        if (Input.GetKeyDown(Keycode.D))
        {
            
        }
        if (Input.GetKeyDown(Keycode.E))
        {
            
        }
        if (Input.GetKeyDown(Keycode.Q))
        {
            
        }

    }
}
