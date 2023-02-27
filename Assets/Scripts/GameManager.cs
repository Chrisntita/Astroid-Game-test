using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
     public Player player;
     public TextMeshProUGUI scoreIndicator;
     public TextMeshProUGUI livesIndicator;
     public Transform gameOverPanel;
      public int lives = 3;
      public int score = 0;
      public bool gameOver = false;
      public float spawnDelay = 3.0f;
      
    
      public float layerChangeDelay = 3.0f;
      

      public ParticleSystem explosion;

      public void Update()
      {
        livesIndicator.text = lives.ToString();
        scoreIndicator.text = score.ToString();

        if (gameOver)
        {
          if (Input.GetKey(KeyCode.Return))
          {
             SceneManager.LoadScene("Asteroids");
          }
        }
      }

      public void AsteroidDestroyed(Asteroid asteroid)
      {
        explosion.transform.position = asteroid.transform.position;
        explosion.Play();

        if(asteroid.size < 0.88f)
        {
            score += 65;
        }/*else if(asteroid.size < 1.21)
        {
          score += 15;
        }else{
            score += 15;
        }*/
      }

      public void PlayerDied()
      {
        explosion.transform.position = player.transform.position;
        explosion.Play();
        lives -= 1;
        if(lives <= 0)
        {
            GameOver();
        }else{
           Invoke(nameof(Respawn), spawnDelay);
        }
         
       
        
      }

      private void Respawn()
      {
        player.transform.position = Vector3.zero;
        player.gameObject.layer = LayerMask.NameToLayer("Ignore Collisions");
        player.gameObject.SetActive(true);
        Invoke(nameof(ChangePlayerLayer), layerChangeDelay);
        
      }
      private void ChangePlayerLayer()
      {
        player.gameObject.layer = LayerMask.NameToLayer("Player");
      }

      public void GameOver()
      {
         gameOverPanel.gameObject.SetActive(true);
         gameOver = true;
      }
}
