

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_status : MonoBehaviour
{

    public bool is_selector_active;
    public bool is_selector_rotating;
    public bool is_selector_reverted;
    public bool is_matched;
    public bool is_filling;
    
    void Start()
    {
        
    }

    
    void Update()
    {
      
    }
    public void timer() {
        

    }
    public void Fill()
    {
        is_filling = true;

        Invoke("FillOff", 5f);
        
         
    }
    public void FillOff()
    {
        is_filling = false;

    }


}
