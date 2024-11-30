using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batute : MonoBehaviour
{
    public Animator Anim;
    public GameObject Button;

    public float bounce = 20f;
    void Start()
    {
        Button.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Button.SetActive(true);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Button.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Button.activeInHierarchy)
        {
            Anim.Play("Batute2");
        }
        else
        {
            Anim.Play("Batute1");
        }
    }
}
