using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // The sound it plays when destoyed
    [SerializeField] AudioClip destructionSound;

    // Reference variables
    Level level;
    GameSession game;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.IncreaseBlockNumber();
        game = FindObjectOfType<GameSession>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            AudioSource.PlayClipAtPoint(destructionSound, Camera.main.transform.position);
            level.ReduceBlockNumber();
            game.AddPoints();
            Destroy(this.gameObject);
        }
    }
}
