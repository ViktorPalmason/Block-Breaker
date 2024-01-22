using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int numberOfBlocks;

    public void IncreaseBlockNumber()
    {
        numberOfBlocks++;
    }

}
