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
      
    }

   
    void Update()
    {
        
        Int32.TryParse(gameObject.name, out name);
        p_parent = transform.parent.gameObject;
        RePosition();
        tile_Text.text = p_parent.name;
        gameObject.name = p_parent.name;
        PickColor();
        if (gs.is_filling)
        {
         // StartCoroutine(swipe());
        }


    }
    //all hex's pick a id for itself
    void PickID() {
        hex_id = Random.Range(0, 6);
        PickColor();
    }
    //all hex's pick a color for its id
    void PickColor() {
        hex_sprite.color = colors[hex_id];
    }
   
    /*
    IEnumerator swipe() {
        if (name % 10 != 0)
        {
            yield return new WaitForSeconds(.3f);
            nextPos = GameObject.Find((name - 1).ToString()).gameObject;
            yield return new WaitForSeconds(.3f);
            if(nextPos.GetComponent<grid_tile>().empty == false)
            {
                RePosition();
            }
            if (nextPos.GetComponent<grid_tile>().empty == true && gs.is_filling == true)
            {
                transform.position = Vector3.Lerp(transform.position, nextPos.transform.position, 30f * Time.deltaTime);
            }
            
        }
    }
    */

    //Reposition hex's after is a match 
    public void RePosition() {
        if (gs.is_matched)
        {
            transform.rotation = transform.parent.transform.rotation;
            transform.position = transform.parent.transform.position;

        }
    }
    //Instantiate 6 dots for 6 corners in hexs
    void InstantiatePiece()
    {
        float angle = 360f / 6f;
        for (int i = 0; i < 6; i++)
        {
            Quaternion rotation = Quaternion.AngleAxis(i * angle, Vector3.forward);
            Vector3 direction = rotation * Vector3.right;
            Vector3 position = transform.position + (transform.forward * -2f) + (direction * 0.68f);
            Transform piece = Instantiate(dot, position, rotation);
            piece.parent = this.transform;
            piece.name = piece.eulerAngles.z.ToString();
            
        }
    }
    //If Hex hits the any tile it will be their child
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (!gs.is_selector_active)
        {
            if (coll.gameObject.tag == "tile")
            {
                transform.parent = coll.gameObject.transform;

            }
        }
        
    }
   
    

}
