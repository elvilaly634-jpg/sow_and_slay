using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Composites;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class grid_placement : MonoBehaviour
{
    public Grid grid;
    public Tilemap tilemap;
    public Tile tile;
    Tile_Type current_tile=Tile_Type.grass;
    int length=Enum.GetValues(typeof(Tile_Type)).Length;
    int current_index=0;
    
    public List<tile_entry> tile_Entries=new List<tile_entry>();
    Dictionary<Vector3Int,Tile_Type> tiles=new Dictionary<Vector3Int, Tile_Type>();
    int height=30;
    int width=30;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int x = 0; x <= width; x++)
        {
            for(int y = 0; y <= height; y++)
            {
                tile_entry entry=GetTile_Entry(Tile_Type.grass);
                set_tile(entry.tiles[0],Tile_Type.grass,new Vector3Int(x,y));
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButton(0))
        {
            Vector3 mouse_pos=Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,-Camera.main.transform.position.z));
            place_tile(new Vector3Int(grid.WorldToCell(mouse_pos).x,grid.WorldToCell(mouse_pos).y,grid.WorldToCell(mouse_pos).z),current_tile);
        }
        if (Input.GetKeyDown(KeyCode.E)&& current_index < length - 2)
        {
            current_index+=1;
            current_tile=(Tile_Type)current_index;
        }
        else if (Input.GetKeyDown(KeyCode.Q) && current_index > 0)
        {
            current_index-=1;
            current_tile=(Tile_Type)current_index;
        }
    }

    public void place_tile(Vector3Int position,Tile_Type type)
    {
        
        if (get_tile_at(position) == Tile_Type.empty || get_tile_at(position)!=current_tile)
        {
            tile_entry entry=GetTile_Entry(type);
            int tile_index=0;
            if(entry.type==Tile_Type.soil){tile_index=get_varient(position,type);}
            set_tile(entry.tiles[tile_index],entry.type,position);
            if (entry.type == Tile_Type.soil)
            {
                List<Vector3Int> tiles_to_refresh=new List<Vector3Int>();
                tiles_to_refresh.Add(new Vector3Int(position.x,(position+Vector3Int.up).y,position.z));
                tiles_to_refresh.Add(new Vector3Int(position.x,(position+Vector3Int.down).y,position.z));
                tiles_to_refresh.Add(new Vector3Int((position+Vector3Int.right).x,position.y,position.z));
                tiles_to_refresh.Add(new Vector3Int((position+Vector3Int.left).x,position.y,position.z));
                refresh_tiles(tiles_to_refresh);
            }

            
        }
    }

    public Tile_Type get_tile_at(Vector3Int key)
    {
        if(tiles.TryGetValue(key,out Tile_Type val))
        {
            return val;
        }
        else
        {
            return Tile_Type.empty;
        }
    }

    public tile_entry GetTile_Entry(Tile_Type type)
    {
        foreach(tile_entry entry in tile_Entries)
        {
            if(entry.type==type){return entry;}
        }
        return null;
    }

    public void set_tile(Tile tile,Tile_Type type,Vector3Int position)
    {
        tilemap.SetTile(position,tile);
        tiles[position]=type;
    }
    public int get_varient(Vector3Int position,Tile_Type type)
    {
        int mask=0;
        if(get_tile_at(position+Vector3Int.up)==type){mask|=1;}
        if(get_tile_at(position+Vector3Int.right)==type){mask|=2;}
        if(get_tile_at(position+Vector3Int.down)==type){mask|=4;}
        if(get_tile_at(position+Vector3Int.left)==type){mask|=8;}

        return mask;
    }
    public void refresh_tiles(List<Vector3Int> target_keys)
    {
        foreach(Vector3Int key in target_keys)
        {
            Tile_Type type=tiles[key];
            if (type == Tile_Type.soil)
            {
                tile_entry entry=GetTile_Entry(type);
                int index=get_varient(key,type);
                set_tile(entry.tiles[index],type,key);
            }
        }
    }
}   

