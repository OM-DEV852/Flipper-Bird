using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 direction;
    public float gravity = -9.8f;
    public float strength = 5f;
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    //Array para guardar las imagenes del pollo
    private int spriteIndex;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void Update()
    {
        BirdMovement();
        Touches();
        BirdGravity();
    }

    private void AnimateSprite()
    {
        spriteIndex++;

        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];
    }

    private void BirdMovement() 
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) 
        {
            direction = Vector3.up * strength;
        }
    }

    private void Touches() 
    {
        if(Input.touchCount > 0) 
        {
            //Vamos a crear una variable para saber cómo esta el dedo.
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began) 
            {
                direction = Vector3.up * strength;
            }
        }
    }

    private void BirdGravity() 
    {
        direction.y += gravity * Time.deltaTime;

        transform.position += direction * Time.deltaTime;
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle") 
        {
            GameManager.gameManager.GameOver();
        }
        else if(collision.tag == "Scoring") 
        {
            GameManager.gameManager.IncreaseScore();
        }
    }
}
