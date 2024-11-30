using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : MonoBehaviour
{
    
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(CanvasAnims.Souls < 7)
            {
                CanvasAnims.Souls++;
                Destroy(this.gameObject);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
