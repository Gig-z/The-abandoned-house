using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Secret : MonoBehaviour
{
    public GameObject Secr;
    public Animator Anim;
    void Start()
    {
        Secr.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            Anim.Play("BigWall1");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Anim.Play("BigWall2");
        }
    }
    void Update()
    {
        
    }
}
