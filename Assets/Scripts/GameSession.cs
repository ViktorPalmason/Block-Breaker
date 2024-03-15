using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    // static reference to an instance of the class
    public static GameSession Instance { get; private set; }

    // config attributes

    // This manipulates the speed of the game. Its range is from 0.1 to 10. 1 is normal speed.
    [Range(0.1f, 10f)][SerializeField] float gameSpeed = 1f;
    // Current score that the player has on a level
    [SerializeField] int currentScore = 0;
    // The score the player gets by destroying a block
    [SerializeField] int scorePerBlockDestroyed = 10;
    [SerializeField] public bool isAutoPlayEnabled;

    // Reference variables
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI headerText;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddPoints()
    {
        currentScore += scorePerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public void UpdateLevelName(string levelName)
    {
        headerText.text = levelName;
    }

    public bool IsAutoPlayEnabled() { return isAutoPlayEnabled; }
}
