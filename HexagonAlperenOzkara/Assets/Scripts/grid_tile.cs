using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grid_tile : MonoBehaviour
{
    public GameObject hex_Prefab;

    public GameObject myHex;
    public int myHex_name;
    public bool empty;
    public int name;
    game_status gs;
    void Start()
    {

        SetupHex();
        gs = GameObject.FindGameObjectWithTag("game_status").GetComponent<game_status>();
    }

    
    void Update()
    {
        //if there is multiple hex's in one tile
        if (gameObject.transform.childCount > 1) {
            Destroy(gameObject.transform.GetChild(1).gameObject);
        }
        //if there is one hex's in one tile
        if (gameObject.transform.childCount == 1) {
            empty = false;
        }
        Int32.TryParse(gameObject.name, out name);

        if (myHex == null)
        {
            empty = true;
            
        }

       

    }
    //Instantiate a hex in the grid tile and in this form
    void SetupHex() {
        GameObject hex = Instantiate(hex_Prefab, transform.localPosition, Quaternion.identity) as GameObject;
        hex.transform.parent = this.transform;       
        myHex = hex;
    }
    //check if a hex in grid tile
    void OnTriggerEnter2D(Collider2D coll)
    {     
            if (coll.gameObject.tag == "hex")
            {
            empty = false;
            myHex = coll.gameObject;
                
            }
    }

    //check if a not hex in grid tile
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "hex")
        {
            myHex = null;
           

        }

    }
 
}
