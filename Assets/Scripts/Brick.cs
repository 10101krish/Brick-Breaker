using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private Ball ball;
    private GameManager gameManager;

    private SpriteRenderer spriteRenderer;

    public Sprite[] brickSprites;

    [SerializeField] public int health;
    [SerializeField] bool unbreakable = false;
    public int perHitScore = 50;
    private int baseScore;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        ball = FindObjectOfType<Ball>();
        gameManager = FindObjectOfType<GameManager>();
        health = System.Array.IndexOf(brickSprites, spriteRenderer.sprite) + 1;
        baseScore = perHitScore * health;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!unbreakable)
        {
            health--;
            if (health <= 0)
            {
                gameManager.AddToScore(baseScore);
                gameManager.BrickDestroyed();
                Destroy(gameObject);
            }
            else
            {
                gameManager.AddToScore(perHitScore);
                spriteRenderer.sprite = brickSprites[health - 1];
            }
        }
    }
}
