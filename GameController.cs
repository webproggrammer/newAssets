using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject playerShip;
    public GameObject asteroidPrefab;
    public GameObject starPrefab;
    public Text scoreText;
    public Text livesText;
    public int asteroidSpawnRate = 3;
    public int starScore = 10;
    public int maxLives = 3;

    private int score = 0;
    private int lives;

    void Start()
    {
        lives = maxLives;
        UpdateLivesUI();
        UpdateScoreUI();
        InvokeRepeating("SpawnAsteroid", 2f, asteroidSpawnRate);
        InvokeRepeating("SpawnStar", 5f, 10f);
    }

    void Update()
    {
        if (lives <= 0)
        {
            GameOver();
        }
    }

    void SpawnAsteroid()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-8f, 8f), 6f, 0f);
        Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
    }

    void SpawnStar()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-8f, 8f), 6f, 0f);
        Instantiate(starPrefab, spawnPosition, Quaternion.identity);
    }

    public void IncrementScore()
    {
        score += starScore;
        UpdateScoreUI();
    }

    public void DecrementLives()
    {
        lives--;
        UpdateLivesUI();
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }

    void UpdateLivesUI()
    {
        livesText.text = "Lives: " + lives;
    }

    void GameOver()
    {
        // Add your game over logic here, like showing a game over screen or resetting the game.
        Debug.Log("Game Over!");
    }
}
