using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int numberOfBlocks;
    [SerializeField] public string LevelName;

    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        // Get the Game Session Instance
        var session = GameSession.Instance;
        if (session != null)
            // update the level name when entering a new level
            session.UpdateLevelName(LevelName);
        else
            Debug.Log("Could not find Game Session Instance");
    }

    public void IncreaseBlockNumber()
    {
        numberOfBlocks++;
    }

    public void ReduceBlockNumber()
    {
        numberOfBlocks--;
        if(numberOfBlocks < 1)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
