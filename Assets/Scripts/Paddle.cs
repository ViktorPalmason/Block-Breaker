using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] Vector2 startingPos = new Vector2(8f, 1f);

    Vector2 currentPos;

    // Start is called before the first frame update
    void Start()
    {
        currentPos = startingPos;
    }

    // Update is called once per frame
    void Update()
    {
        currentPos.x = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        transform.position = currentPos;
    }
}
