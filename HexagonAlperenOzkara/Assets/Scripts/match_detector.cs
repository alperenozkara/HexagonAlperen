

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class match_detector : MonoBehaviour
{
    public List<GameObject> hexs;
    
    public bool match,firsttime;
    game_status gs;
   


    void Awake() {
        
    }
    void Start()
    {
        firsttime = true;
        Invoke("FirstCheck", 0.4f);
        
        gs = GameObject.FindGameObjectWithTag("game_status").GetComponent<game_status>();
        

    }
  

    void Update()
    {
        //looking for matches
        if (gs.is_filling == false)
        {
            if (gs.is_selector_rotating == false)
            {
                FindMatch();
            }
            if (match && gs.is_selector_rotating == false)
            {
                gs.is_matched = true;
                Invoke("DestroyHexs", 0.4f);

            }

        //if there is 3 connection point spawn selector or not
            if (hexs.Count != 3)
            {
                gameObject.GetComponent<spawn_selector>().enabled = false;
            }
            else {
                gameObject.GetComponent<spawn_selector>().enabled = true;
            }
        }
    }


    private void FindMatch() {

        if (hexs.Count == 3)
        {
                if (hexs[0].GetComponent<hex_identity>().hex_id == hexs[1].GetComponent<hex_identity>().hex_id && hexs[1].GetComponent<hex_identity>().hex_id == hexs[2].GetComponent<hex_identity>().hex_id)
                {
                //in the game starts for never colors matches
                    if (firsttime)
                    {
                        hexs[0].GetComponent<hex_identity>().hex_id = Random.Range(0, 6);
                        hexs[1].GetComponent<hex_identity>().hex_id = Random.Range(0, 6);
                        hexs[2].GetComponent<hex_identity>().hex_id = Random.Range(0, 6);
                    }
                    else {
                        match = true;
                  
                    }
                    
                }    
        }
       
    }
    
    private void OnTriggerEnter2D(Collider2D coll)
    {
       //finding 3 hex's in dot collider
        if (coll.gameObject.tag == "hex")
        {
            if (hexs.Count < 3)
            {
                hexs.Add(coll.gameObject);
              
            }
        }
        if (coll.gameObject.tag == "snap_destroyer") {
            gameObject.GetComponent<spawn_selector>().enabled = false;
        }
       
    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        //finding removing hex's in dot collider
        if (coll.gameObject.tag == "hex")
        {        
            hexs.Remove(coll.gameObject);

        }
    }
    
    private void DestroyHexs()
    {
     //if there is matches destroy all hex's  
        match = false;
        gs.is_selector_active = false;
        gs.is_selector_reverted = false;
        gs.is_matched = false;
        gs.Fill();
        Destroy(hexs[0].gameObject);
      
        Destroy(hexs[1].gameObject);
        
        Destroy(hexs[2].gameObject);
        hexs.Clear();
      
        
        
       

    }
    private void FirstCheck() {
        firsttime = false;
       
    }
    private void FillAgain() {
       
    }
   



}
