
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_selector : MonoBehaviour
{
   
    public GameObject selector_Prefab;
    
    public bool reverted;
  
    public float test;
    game_status gs;
    void Start()
    {
        
        gs = GameObject.FindGameObjectWithTag("game_status").GetComponent<game_status>();
    }

    
    void Update()
    {
        //spawn hex selector for dot degress
        switch (gameObject.name)
        {
            case "0":
                reverted = false;
                break;
            case "60":
                reverted = true;
                break;
            case "120":
                reverted = false;
                break;
            case "180":
                reverted = true;
                break;
            case "240":
                reverted = false;
                break;
            case "300":
                reverted = true;
                break;
        }
        test = transform.eulerAngles.z;
    }
    void OnMouseDown()
    {
        //spawn selector
        if (gameObject.GetComponent<match_detector>().hexs.Count == 3)
        {
            if (gs.is_filling == false)
            {
                for (int i = 0; i < 3; i++)
                {

                }
                if (!gs.is_selector_active)
                {
                    if (!reverted)
                    {
                        //spawn normal selector
                        SpawnSelector();

                    }
                    if (reverted)
                    {
                        //spawn revert selector
                        SpawnSelector_Revert();

                    }
                }
            }
        }
    }
    public void SpawnSelector() {
        GameObject hex = Instantiate(selector_Prefab, transform.position, Quaternion.identity) as GameObject;      
        gs.is_selector_active = true;
        gs.is_selector_reverted = false;


    }
    public void SpawnSelector_Revert() {
        
        GameObject hex = Instantiate(selector_Prefab, transform.position, Quaternion.identity) as GameObject;
        
        
        gs.is_selector_active = true;
        gs.is_selector_reverted = true;


    }
    private void RotateSelector() { 
    
    }


    
}
