using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Config params
    [SerializeField] AudioClip destructionSound; // The SFX til plays when detroyed
    [SerializeField] GameObject blockSparkleVFX; // The VFX til spawns when destroyed
    [SerializeField] int maxHits = 3; // The max hits it can take before being destroyed


    // Reference variables
    Level level;

    // State variables
    [SerializeField] int totalHits = 0; // Total hits the block has recieved by the ball (Only serialized for debugging)


    private void Start()
    {
        level = FindObjectOfType<Level>();
        if(tag == TagManager.BREAKABLE_TAG)
            level.IncreaseBlockNumber();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == TagManager.BALL_TAG)
        {
            if (tag == TagManager.BREAKABLE_TAG)
            {
                HandleHit();
            }
        }
    }

    private void HandleHit()
    {
        totalHits++;

        if (totalHits >= maxHits)
        {
            DestroyBlock();
        }
    }

    private void DestroyBlock()
    {
        // Add points to the player score
        IncreasePlayerScore();

        // Play SFX and VFX
        PlayBlockDestuctionSFX();
        TriggerSparklesVFX();

        // Reduce the number of blocks in the level and destroy the object.
        level.ReduceBlockNumber();
        Destroy(this.gameObject);
    }

    private void IncreasePlayerScore()
    {
        GameSession.Instance.AddPoints();
    }

    private void PlayBlockDestuctionSFX()
    {
        AudioSource.PlayClipAtPoint(destructionSound, Camera.main.transform.position);
    }

    private void TriggerSparklesVFX()
    {
        //Spawn the Sparkles partical effect at the blocks location
        GameObject sparkle = GameObject.Instantiate(blockSparkleVFX, transform.position, transform.rotation);
        Destroy(sparkle, 2f);
    }
}
