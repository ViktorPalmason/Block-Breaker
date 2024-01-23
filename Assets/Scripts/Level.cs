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
        // Get the Game Session object
        var session = FindObjectsOfType<GameSession>();
        if (session != null)
            // As there could be many Game Sessions objects in the scene
            // and we want the one that has been persistent throughout the game
            // we choose the last one in the array.
            session[session.Length-1].UpdateLevelName(LevelName);
        else
            Debug.Log("Could not find Game Session Object");
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
