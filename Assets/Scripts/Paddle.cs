using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    Vector2 startingPos;

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
    }

    void UpdatePosition()
    {
        Vector2 mouseScreenPos = Input.mousePosition;
        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        float updatedPaddleXPos = Mathf.Clamp(mouseWorldPos.x, -15, +15);
        transform.position = new Vector2(updatedPaddleXPos, transform.position.y);
    }

    public void Reset()
    {
        transform.position = startingPos;
    }
}
