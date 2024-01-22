using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip destructionSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            AudioSource.PlayClipAtPoint(destructionSound, transform.position);
            Destroy(this.gameObject); 
        }
    }
}
