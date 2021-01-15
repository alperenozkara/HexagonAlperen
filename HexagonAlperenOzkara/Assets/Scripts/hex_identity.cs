using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class hex_identity : MonoBehaviour
{
    public TextMesh tile_Text;
    public int hex_id;
    public SpriteRenderer hex_sprite;
    public Color[] colors;
    public List<GameObject> Dots;
    public Transform dot;
    public GameObject p_parent;
    public GameObject nextPos;
    public int name;
    game_status gs;
    void Start()
    {
        gs = GameObject.FindGameObjectWithTag("game_status").GetComponent<game_status>();
        InstantiatePiece();
        PickID();
        foreach (Transform child in transform)
        {
            Dots.Add(child.gameObject);
        }
        
    }

   
    void Update()
    {
        
        Int32.TryParse(gameObject.name, out name);
        p_parent = transform.parent.gameObject;
        CheckEdges();
        tile_Text.text = p_parent.name;
        gameObject.name = p_parent.name;
        PickColor();
        RePosition();
        if (name % 10 != 0)
        {
            nextPos = GameObject.Find((name - 1).ToString()).gameObject;
        }
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
    void ChangeColor() { 
    
    }
    void RePosition() {
        if (gs.is_matched)
        {
            transform.rotation = p_parent.transform.rotation;
            transform.position = p_parent.transform.position;
        }
    }
    void InstantiatePiece()
    {
        float angle = 360f / 6f;
        for (int i = 0; i < 6; i++)
        {
            Quaternion rotation = Quaternion.AngleAxis(i * angle, Vector3.forward);
            Vector3 direction = rotation * Vector3.right;
            Vector3 position = transform.position + (transform.forward * -2f) + (direction * 0.68f);
            Transform piecee = Instantiate(dot, position, rotation);
            piecee.parent = this.transform;
            piecee.name = piecee.eulerAngles.z.ToString();
            
        }
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "tile")
        {
            transform.parent = coll.gameObject.transform;
        }
    }

}
