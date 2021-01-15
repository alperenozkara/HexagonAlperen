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
    void Start()
    {
        SetupHex();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (myHex == null)
        {
            empty = true;
        }
        else
        {
            empty = false;
        }
        

    }

    void SetupHex() {
        GameObject hex = Instantiate(hex_Prefab, transform.localPosition, Quaternion.identity) as GameObject;
        hex.transform.parent = this.transform;       
        myHex = hex;
    }
}
