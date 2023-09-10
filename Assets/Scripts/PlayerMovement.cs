using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Transform self_trans;
    public GameObject self_obj;

    public Vector3 ideal_position;

    public int direction;
    // 0 = up
    // 1 = right
    // 2 = down
    // 3 = left

    public Sprite[] my_sprites;
    public SpriteRenderer self_renderer;

    public bool can_move;

    public LayerMask other_layers;

    // Start is called before the first frame update
    void Start()
    {
        ideal_position = self_trans.position;
    }

    bool PerformMovementCheck(bool valid_attack, Vector3 check_position)
    {
        bool final_state = true;
        Vector3 check_direction = check_position - ideal_position;

        RaycastHit2D my_hit_data = Physics2D.Raycast(check_position, check_direction, 0.3f, other_layers);
        if (my_hit_data.collider != null)
        {
            if (my_hit_data.collider.gameObject.GetComponent<Identity>())
            {
                Debug.Log("Hit");
                // UnityEditor.EditorGUIUtility.PingObject(my_hit_data.collider.gameObject);

                if (my_hit_data.collider.gameObject.GetComponent<Identity>().can_pass == false)
                {
                    final_state = false;

                } else
                {
                    if (my_hit_data.collider.gameObject.GetComponent<Identity>().is_living == true && valid_attack)
                    {
                        my_hit_data.collider.gameObject.GetComponent<Identity>().is_living = false;
                        if (my_hit_data.collider.gameObject.GetComponent<Identity>().my_type == "person")
                        {
                            my_hit_data.collider.gameObject.GetComponent<Person>().Die();
                        }
                    }
                    final_state = true;
                }
            }
        }
        return final_state;
    }

    // Update is called once per frame
    void Update()
    {
        self_trans.position = Vector3.MoveTowards(self_trans.position, ideal_position, Time.deltaTime * 5f);
        self_renderer.sprite = my_sprites[direction];

        if (self_trans.position == ideal_position)
        {
            can_move = true;
        }

        if (Mind.player_cooldown > 0)
        {
            Mind.player_cooldown -= 1;
            can_move = false;
        }

        if (Input.GetKeyDown(KeyCode.W) && can_move)
        {
            direction = 0;
            can_move = PerformMovementCheck(true, (ideal_position + new Vector3(0f, 1f, 0f)));
            if (can_move)
            {
                ideal_position += new Vector3(0f, 1f, 0f);
                Mind.player_cooldown = 5;
            }
            can_move = false;
        }
        if (Input.GetKeyDown(KeyCode.S) && can_move)
        {
            direction = 2;
            can_move = PerformMovementCheck(true, (ideal_position + new Vector3(0f, -1f, 0f)));
            if (can_move)
            {
                ideal_position += new Vector3(0f, -1f, 0f);
                Mind.player_cooldown = 5;
            }
            can_move = false;
        }

        if (Input.GetKeyDown(KeyCode.A) && can_move)
        {
            direction = 3;
            can_move = PerformMovementCheck(true, (ideal_position + new Vector3(-1f, 0f, 0f)));
            if (can_move)
            {
                ideal_position += new Vector3(-1f, 0f, 0f);
                Mind.player_cooldown = 5;
            }
            can_move = false;
        }
        if (Input.GetKeyDown(KeyCode.D) && can_move)
        {
            direction = 1;
            can_move = PerformMovementCheck(true, (ideal_position + new Vector3(1f, 0f, 0f)));
            if (can_move)
            {
                ideal_position += new Vector3(1f, 0f, 0f);
                Mind.player_cooldown = 5;
            }
            can_move = false;
        }

    }
}
