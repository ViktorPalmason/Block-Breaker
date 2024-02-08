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
                // Add points to the player score
                IncreasePlayerScore();

                // Play SFX and VFX
                PlayBlockDestuctionSFX();
                TriggerSparklesVFX();

                DestroyBlock();
            }
        }
    }

    private void DestroyBlock()
    {
        // Reduce the number of blocks in the level and destroy the object.
        level.ReduceBlockNumber();
        Destroy(this.gameObject);
    }

    private void TriggerSparklesVFX()
    {
        //Spawn the Sparkles partical effect at the blocks location
        GameObject sparkle = GameObject.Instantiate(blockSparkleVFX, transform.position, transform.rotation);
        Destroy(sparkle, 2f);
    }

    private void PlayBlockDestuctionSFX()
    {
        AudioSource.PlayClipAtPoint(destructionSound, Camera.main.transform.position);
    }

    private void IncreasePlayerScore()
    {
        GameSession.Instance.AddPoints();
    }
}
