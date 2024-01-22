using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int numberOfBlocks;

    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
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
