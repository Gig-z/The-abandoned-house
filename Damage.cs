using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float damage;
    public Health health;

    public Moving PlaMove;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlaMove.KBCounter = PlaMove.KBTotalTime;
            if (collision.transform.position.x <= transform.position.x)
            {
                PlaMove.KnockFromRight = true;
            }
            if (collision.transform.position.x > transform.position.x)
            {
                PlaMove.KnockFromRight = false;
            }
            health.TakeDamage(damage);
        }
    }
}
