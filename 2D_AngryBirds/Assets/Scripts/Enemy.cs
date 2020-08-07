using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //[SerializeField] private GameObject _cloudPrefab;

    private void OnCollisionStay2D(Collision2D collision)
    {
        Animator anim = GetComponent<Animator>();
        Bird hit = collision.collider.GetComponent<Bird>();
        if (hit!=null)
        {
            //GameObject.Destroy(gameObject);
            //Instantiate(_cloudPrefab, transform.position,Quaternion.identity);
            anim.SetTrigger("Die");
            return;
        }

        if (collision.collider.GetComponent<Enemy>() != null)
        {
            return;
        }

        if (collision.contacts[0].normal.y < -0.5)
        {
            //Instantiate(_cloudPrefab, transform.position, Quaternion.identity);
            //GameObject.Destroy(gameObject);
            anim.SetTrigger("Die");
            return;
        }


    }
}
