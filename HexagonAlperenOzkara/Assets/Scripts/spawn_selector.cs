
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_selector : MonoBehaviour
{
   
    public GameObject selector_Prefab;
    public bool reverted;
    game_status gs;
    void Start()
    {
        gs = GameObject.FindGameObjectWithTag("game_status").GetComponent<game_status>();
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.F)) {
            SpawnSelector();
        }
    }
    void OnMouseDown()
    {
        if (!gs.is_selector_active)
        {
            if (!reverted)
            {
                SpawnSelector();
            }
            if (reverted)
            {
                SpawnSelector_Revert();
            }
        }
    }
    public void SpawnSelector() {
        GameObject hex = Instantiate(selector_Prefab, transform.position, Quaternion.identity) as GameObject;
        
        gs.is_selector_active = true;


    }
    public void SpawnSelector_Revert() {
        
        GameObject hex = Instantiate(selector_Prefab, transform.position, Quaternion.identity) as GameObject;
        hex.transform.Rotate(0, 0, -180,Space.Self);
        
        gs.is_selector_active = true;


    }
    private void RotateSelector() { 
    
    }

    
}
