using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{

    public Sprite blood;
    public SpriteRenderer self_renderer;

    public void Die()
    {
        self_renderer.sprite = blood;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
