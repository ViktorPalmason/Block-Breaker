using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // The sound it plays when destoyed
    [SerializeField] AudioClip destructionSound;
    [SerializeField] GameObject blockSparkleVFX;

    // Reference variables
    Level level;
    GameSession game;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.IncreaseBlockNumber();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            // Add points to the player score
            game = FindObjectOfType<GameSession>();
            game.AddPoints();

            // Play SFX and VFX
            AudioSource.PlayClipAtPoint(destructionSound, Camera.main.transform.position);
            GameObject sparkle = GameObject.Instantiate(blockSparkleVFX, transform.position, transform.rotation);
            Destroy(sparkle, 2f);

            // Reduce the number of blocks in the level and destroy the object.
            level.ReduceBlockNumber();
            Destroy(this.gameObject);
        }
    }
}
