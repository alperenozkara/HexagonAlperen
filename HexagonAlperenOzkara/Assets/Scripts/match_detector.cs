using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class match_detector : MonoBehaviour
{
    public List<GameObject> hexs;
    public int check1,check2,check3;
    public bool match,firsttime;
    game_status gs;
   


    void Awake() {
        
    }
    void Start()
    {
        firsttime = true;
        Invoke("FirstCheck", 0.15f);
        
        gs = GameObject.FindGameObjectWithTag("game_status").GetComponent<game_status>();
        

    }
    /*
     * for (int i = 0; i < 3; i++)
        {
            if (hexs[i] = null)
            {
                hexs.Remove(hexs[i]);
            }
        }
     */

    void Update()
    {
        FindMatch();
        if (match && gs.is_selector_rotating == false) {
            gs.is_matched = true;
            Invoke("DestroyHexs", 0.3f);
            AfterDestroy();
            match = false;



        }
        if (!gs.is_selector_rotating) {
           
        }
        if(hexs.Count != 3)
        {
            gameObject.GetComponent<spawn_selector>().enabled = false;
        }
       
    }


    private void FindMatch() {

        if (hexs.Count == 3)
        {
            check1 = hexs[0].GetComponent<hex_identity>().hex_id; 
            check2 = hexs[1].GetComponent<hex_identity>().hex_id; 
            check3 = hexs[2].GetComponent<hex_identity>().hex_id;
         
                if (check1 == check2 && check2 == check3)
                {
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
        if (coll.gameObject.tag == "hex")
        {        
            hexs.Remove(coll.gameObject);
        }
    }

    private void DestroyHexs()
    {
        match = false;
        gs.is_selector_active = false;     
        gs.is_selector_reverted = false;
        gs.is_matched = false;
        Destroy(hexs[0].gameObject);
        hexs.Remove(hexs[0].gameObject);
        Destroy(hexs[1].gameObject);
        hexs.Remove(hexs[1].gameObject);
        Destroy(hexs[2].gameObject);
        hexs.Remove(hexs[2].gameObject);
       

    }
    private void FirstCheck() {
        firsttime = false;
       
    }
    private void AfterDestroy() {
        gs.timer();
    }



}
