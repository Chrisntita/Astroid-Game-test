using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Sprite[] sprites;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody;

    public GameObject gameManager;
    private GameManager gameManagerScript;

    public float size = 1.0f;
    public float speed = 15.0f;
    public float minSize = 0.5f;
    public float maxSize = 1.5f;
    private float maxLifeTime = 30.0f;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();

    
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();

    
    }

    void Start()
    {
        
      spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];

      this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 365.0f);
      this.transform.localScale = Vector3.one * this.size;

    }

     public void SetTrajectory(Vector2 direction)
    {
        // The asteroid only needs a force to be added once since they have no
        // drag to make them stop moving
        rigidbody.AddForce(direction * speed);
        Destroy(gameObject, maxLifeTime);
    }

      private void OnCollisionEnter2D(Collision2D collision)
     {
          if(collision.gameObject.tag == "Bullet")
          {
                if ((size * 0.5f) >= minSize)
            {
                SpawnSmallAsteroids();
                
            }
            gameManagerScript.AsteroidDestroyed(this);
            Destroy(gameObject);
          }
     }
     
     
    private void SpawnSmallAsteroids()
    {
        int randomInt = Random.Range(0, 2);

        for(int i = 0; i <= randomInt; i ++)
        {
         Vector2 position = transform.position;
         position += Random.insideUnitCircle * 0.5f;

         Asteroid smallAsteroid = Instantiate(this, position, transform.rotation);
         smallAsteroid.size = size * 0.5f;

         smallAsteroid.SetTrajectory(Random.insideUnitCircle.normalized);
        }
         
    }
     

     

}
