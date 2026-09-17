using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class grid_placement : MonoBehaviour
{
    public float grid_size=1;
    public GameObject thing_to_place;
    public List<GameObject> things_to_place=new List<GameObject>();
    int index=0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            place_item();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (index < things_to_place.Count-1)
            {
                index+=1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            if (index > 0)
            {
                index-=1;
            }
        }
    }

    void place_item()
    {   
        Vector3 mouse_pos=Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,-Camera.main.transform.position.z));
        
        Vector2 snapped_pos=new Vector2(Mathf.Round(mouse_pos.x/grid_size)*grid_size,Mathf.Round(mouse_pos.y/grid_size)*grid_size);
        Collider2D collided2d=Physics2D.OverlapPoint(mouse_pos);
        if (collided2d==null){
            Instantiate(things_to_place[index],snapped_pos,Quaternion.identity);
        }
        else{Debug.Log(collided2d.gameObject.name +" is there");}
    }
}   

