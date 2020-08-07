using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  
    private void OnCollisionStay2D(Collision2D collision)
    {
        Animator anim = GetComponent<Animator>();
        Bird hit = collision.collider.GetComponent<Bird>();
        if (hit!=null)
        {
            //GameObject.Destroy(gameObject);
            anim.SetTrigger("Die");
            return;
        }

        if (collision.collider.GetComponent<Enemy>() != null)
        {
            return;
        }

        if (collision.contacts[0].normal.y < -0.5)
        {
            //GameObject.Destroy(gameObject);
            anim.SetTrigger("Die");
            return;
        }


    }
}
