using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController1 : MonoBehaviour
{
    public GameObject hazard;
    public float spawnInterval = 2f;
    private float xValue = 6.5f;
    private float yValue = 0.0f;
    private float zValue = 16.0f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI restartText;
    private bool gameOver = false;
    public float score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnMeteors());
    }

    private void Update() {
        if (gameOver == true) {
            restartText.text = "Press 'R' to restart";
            if (Input.GetKeyDown(KeyCode.R)){
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //reload the scene for restart
                gameOver = false;
            }
        }
    }

    private IEnumerator SpawnMeteors()
    {
        while (true)
        {
            SpawnMeteor();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnMeteor()
    {
        float randomX = Random.Range(-xValue, xValue);
        Vector3 spawnPosition = new Vector3(randomX, yValue, zValue);

        Instantiate(hazard, spawnPosition, Quaternion.identity);
    }

    public void AddScore(int scoreValue)
    {
        score += scoreValue;
        UpdateScore();
    }
    private void UpdateScore() 
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver() {
        gameOverText.text = "Game Over";
        gameOver = true;
    }
}