using UnityEngine;
using UnityEngine.UI;

public class bits_test : MonoBehaviour
{
    string[] dooricons=new string[16];
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int mask=0;
        bool door1=true;
        bool door2=false;
        bool door3=true;
        bool door4=true;

        if(door1){mask|=1;}
        if(door2){mask|=2;}
        if(door3){mask|=4;}
        if(door4){mask|=8;}
        string[] doorIcons = new string[16];
        doorIcons[0]  = "none";
        doorIcons[1]  = "1";
        doorIcons[2]  = "2";
        doorIcons[3]  = "1 and 2";
        doorIcons[4]  = "3";
        doorIcons[5]  = "1 and 3";
        doorIcons[6]  = "2 and 3";
        doorIcons[7]  = "1, 2 and 3";
        doorIcons[8]  = "4";
        doorIcons[9]  = "1 and 4";
        doorIcons[10] = "2 and 4";
        doorIcons[11] = "1, 2 and 4";
        doorIcons[12] = "3 and 4";
        doorIcons[13] = "1, 3 and 4";
        doorIcons[14] = "2, 3 and 4";
        doorIcons[15] = "all four";
        
        Debug.Log(doorIcons[mask]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
