using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hex_identity : MonoBehaviour
{
    public int hex_id;
    public SpriteRenderer hex_sprite;
    public Color[] colors;
    void Start()
    {
        PickID();
    }

   
    void Update()
    {
        CheckEdges();
    }

    void PickID() {
        hex_id = Random.Range(0, 6);
        PickColor();
    }
    void PickColor() {
        hex_sprite.color = colors[hex_id];
    }

    void CheckEdges() { 
    
    }
}
