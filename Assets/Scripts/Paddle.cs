using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] Vector2 startingPos = new Vector2(8f, 1f);
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    Vector2 currentPos;
    GameSession session;
    Ball ball;

    // Start is called before the first frame update
    void Start()
    {
        currentPos = startingPos;
        session = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        //currentPos.x = Mathf.Clamp(Input.mousePosition.x / Screen.width * screenWidthInUnits, minX, maxX);
        currentPos.x = GetXPos();
        transform.position = currentPos;
    }

    float GetXPos()
    {
        if(session.IsAutoPlayEnabled())
        {
            return Mathf.Clamp(ball.transform.position.x, minX, maxX);
        }
        else
        {
            return Mathf.Clamp(Input.mousePosition.x / Screen.width * screenWidthInUnits, minX, maxX);
        }
    }
}
