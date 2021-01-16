using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_board : MonoBehaviour
{
    public int width;
    public int height;
    private float x_direction = 0.611f;
    
    public GameObject grid_tile_Prefab;
    public List<GameObject> newHexs;
    private grid_tile[,] all_Tiles;
    void Start()
    {
        all_Tiles = new grid_tile[width, height];
        SetupArenaTiles();
       
    }

    
    void Update()
    {
        
    }
    //Fill the area with your desire
    private void SetupArenaTiles()
    {
        for (float x = 0; x < width; x++) {
            
            for (float y = 0; y < height; y++) {


                float x_pos = x * 1.01f;
               
                float y_pos = y * 1.18f;



                if (y % 2 == 1)
                {
                    

                }
                if (x % 2 == 1) {
                    y_pos -= 0.6f;
                }
 
                GameObject tile  = Instantiate(grid_tile_Prefab, new Vector2(x_pos,y_pos), Quaternion.identity) as GameObject;
                tile.transform.parent = this.transform;
                
                tile.name = (x+1).ToString() + y.ToString();
            }
        }
    }
    

    
}
