using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    // config attributes
    // This manipulates the speed of the game. Its range is from 0.1 to 10. 1 is normal speed.
    [Range(0.1f, 10f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int currentScore = 0;
    [SerializeField] int scorePerBlockDestroyed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddPoints()
    {
        currentScore += scorePerBlockDestroyed;
    }
}
