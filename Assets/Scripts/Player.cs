using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float thrustingSpeed;
    public float turnSpeed = 1.0f;
     public bool thrusting;
     public float turnDirection;
    [SerializeField] private GameObject bubbleShield;
    
    private Rigidbody2D rigidbody;
    public GameObject gameManager;
    private GameManager gameManagerScript;

    GameObject shield;
     void Start()
     {
        shield = transform.Find("Shield").gameObject;
     }

    [SerializeField] private Bullet bulletPrefab;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        gameManagerScript = gameManager.GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
         thrusting =  Input.GetKey(KeyCode.UpArrow);
          if ( Input.GetKey(KeyCode.LeftArrow)) {
            turnDirection = 1f;
        } else if ( Input.GetKey(KeyCode.RightArrow)) {
            turnDirection = -1f;
        } else {
            turnDirection = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
             Shoot();
        }
           
        
    }

    private void FixedUpdate()
    {
        if(thrusting)
        {
            rigidbody.AddForce(transform.up * thrustingSpeed);
        }
        if(turnDirection != 0.0f)
        {
            rigidbody.AddTorque(turnDirection * turnSpeed);
        }
    } 

    private void Shoot()
    {
        Bullet bullet = Instantiate(this.bulletPrefab, this.transform.position, this.transform.rotation);
        bullet.project(this.transform.up);
    }
    public void Damage()
    {
       
    } 

   

   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Asteroid")
        {
            
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = 0.0f;
            gameObject.SetActive(false);

            gameManagerScript.PlayerDied();

        }
    }
}
