using UnityEngine;

public class mouvement : MonoBehaviour
{
    int speed=5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float Horizontal=Input.GetAxisRaw("Horizontal");
        float Vertical=Input.GetAxisRaw("Vertical");

        transform.Translate(new Vector3(Horizontal,Vertical,0)*speed*Time.deltaTime);
    }
}
