using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_board : MonoBehaviour
{
    public int width;
    public int height;
    private float x_direction = 0.611f;
    private float y_direction = 0.220f;
    public GameObject grid_tile_Prefab;

    private grid_tile[,] all_Tiles;
    void Start()
    {
        all_Tiles = new grid_tile[width, height];
        SetupArenaTiles();
    }

    
    void Update()
    {
        
    }

    private void SetupArenaTiles()
    {
        for (float x = 0; x < width; x++) {
            
            for (float y = 0; y < height; y++) {


                float x_pos = x * 1.20f;
                float y_pos = y * 0.98f;



                if (y % 2 == 1)
                {
                    x_pos += x_direction;
                    

                }
 
                GameObject tile  = Instantiate(grid_tile_Prefab, new Vector2(x_pos,y_pos), Quaternion.identity) as GameObject;
                tile.transform.parent = this.transform;
                tile.name = "[" + x + "," + y + "]";
            }
        }
    }
}
