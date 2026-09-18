using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public enum Tile_Type
{
    soil,
    grass,
    
    
    empty
}

[System.Serializable]
public class tile_entry
{
    public Tile_Type type;
    public List<Tile> tiles=new List<Tile>();

}
// public class Player
// {
//     public string name;
//     public int health;
//     public Player(string name,int health)
//     {
//         this.name=name;
//         this.health=health;
//     }

    
// }
// public class Enemy
// {
//     public string name;
//     public int health;
//     public int damage;

//     public Enemy(string name,int health,int damage)
//     {
//         this.name=name;
//         this.health=health;
//         this.damage=damage;

//     }

//     public void attack( Player target)
//     {
//         target.health-=damage;
//     }
// }
public class tile_type : MonoBehaviour
{
    public List<tile_entry> tile_Entries=new List<tile_entry>();
    // List<Player> players=new List<Player>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // players.Add(new Player("el vilay",20));
        // players.Add(new Player("alex",30));
        // players.Add(new Player("epsteine",10));
        // Enemy enemy=new Enemy("zombie",20,10);
        // foreach(Player e in players)
        // {
        //     Debug.Log(e.name+" has an hp of "+e.health);
        //     enemy.attack(e);
        // }
        //         foreach(Player e in players)
        // {
        //     Debug.Log("now "+e.name+" has an hp of "+e.health);
            
        // }
        
        
        

        // foreach(tile_entry entry in tile_Entries)
        // {
        //     Debug.Log(entry.tile+" , "+entry.sprite);
        // }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

