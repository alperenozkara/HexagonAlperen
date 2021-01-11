using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grid_tile : MonoBehaviour
{
    public GameObject hex_Prefab;
    void Start()
    {
        SetupHex();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetupHex() {
        GameObject hex = Instantiate(hex_Prefab, transform.localPosition, Quaternion.identity) as GameObject;
        hex.transform.parent = this.transform;
    }
}
