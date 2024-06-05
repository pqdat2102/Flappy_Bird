using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public Sprite[] sprites;

    private int spriteIndex;

    private Vector3 direction;

    public float gravity = -9.8f;

    public float strength = 5f;

    public AudioClip flyClip;

    public AudioSource audioSourcefly;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }

    private void Start()
    {
        audioSourcefly = GetComponent<AudioSource>();
        audioSourcefly.clip = flyClip;
        

        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f); 
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {   
            audioSourcefly.Play();
            direction = Vector3.up * strength;
            audioSourcefly.Play();
        }

        // Check how many fingers touch the screen (for Mobile)
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * strength;
            }
        }

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

    private void AnimateSprite()
    {
        spriteIndex++;
           
        if(spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            FindObjectOfType<GameManager>().GameOver();
        }
        else
        {
            if(other.gameObject.tag == "Scoring")
            {
                FindObjectOfType<GameManager>().IncreaseScore();
            }
        }
    }

}
