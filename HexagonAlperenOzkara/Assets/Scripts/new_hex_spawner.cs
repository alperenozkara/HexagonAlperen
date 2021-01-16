using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class new_hex_spawner : MonoBehaviour
{
    public GameObject grid_tile_Prefab;
    public int width;
    public int height;
    public List<GameObject> newHexs;
    void Start()
    {
        width = gameObject.GetComponent<game_board>().width;
        height = gameObject.GetComponent<game_board>().height;
        SetupNewHexTiles();
       
    }
    //this script for new hex's after pop :(

    void Update()
    {
        
    }
    public void SetupNewHexTiles()
    {
        for (float x = 0; x < width; x++)
        {
            float x_pos = x * 1.01f;
            GameObject tile = Instantiate(grid_tile_Prefab, new Vector2(x_pos, height + 5), Quaternion.identity) as GameObject;
            tile.transform.parent = this.transform;
            tile.name = (x + 1).ToString() + height.ToString();
            newHexs.Add(tile);

        }
    }
    public void newHexCall() {
        for (int i = 0; i < width; i++) {
            if (newHexs[i].transform.childCount == 0) { 
                
            }
        }
    }
}
