using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip destructionSound;
    Level level;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.IncreaseBlockNumber();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            AudioSource.PlayClipAtPoint(destructionSound, Camera.main.transform.position);
            Destroy(this.gameObject); 
        }
    }
}
