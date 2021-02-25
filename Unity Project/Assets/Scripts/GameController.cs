using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject clickMan;
    public FallingSquare fallingSquare;
    public FallingTriangle fallingTriangle;
    public FallingHexagon fallingHexagon;
    public Vector2 starSpawnLocation;
    public Tower leftTower;
    public Tower rightTower;
    public Gear gear;
    public Powerup pwrup;
    public GameObject marker;
    public IncreaseThreatText increaseThreatText;
    public PowerupDisplay powerupDisp;
    public GameObject mainMenuButton;
    public Fragment frag;

    private int lives;
    private int score;
    private int speedThreshold;
    private int speedIncrement;
    private int speedLevel;
    private int powerupChance;
    private float powerupSpawn;

    private int EasyHighScore;
    private int NormalHighScore;
    private int HardHighScore;

    public Text livesText;
    public Text gameOverText;
    public Text scoreText;
    public Text threatText;
    public Text newHighScoreText;
    public Text EasyHighScoreText;
    public Text NormalHighScoreText;
    public Text HardHighScoreText;

    private static int difficulty;

    private float minSpeed;
    private float maxSpeed;

    private float shapeWait;
    private int spawnSelector;

    public AudioSource increaseThreatSound;
    public AudioSource addScoreSound;
    public AudioSource loseLifeSound;
    public AudioSource powerUpSound;

    public ToggleSound soundSettings;

    void Start()
    {
        DisplayHighScores();
    }

    IEnumerator Spawnwaves()
    {
        yield return new WaitForSeconds(2.0f);
        while (true)
        {
            Vector2 spawnPosition = new Vector2(Random.Range(-starSpawnLocation.x, starSpawnLocation.x), starSpawnLocation.y);
            spawnSelector = Random.Range(0, 9);
            if (spawnSelector < 6)
            {
                FallingSquare square = Instantiate(fallingSquare, spawnPosition, Quaternion.identity);
                square.Drop(Random.Range(minSpeed, maxSpeed));
            }
            else if (spawnSelector < 8)
            {
                FallingTriangle triangle = Instantiate(fallingTriangle, spawnPosition, Quaternion.identity);
                triangle.SetTarget(Random.Range(-starSpawnLocation.x, starSpawnLocation.x), Random.Range(minSpeed, maxSpeed));
            }
            else
            {
                FallingHexagon hexagon = Instantiate(fallingHexagon, spawnPosition, Quaternion.identity);
                hexagon.SetTarget(Random.Range(-starSpawnLocation.x, starSpawnLocation.x), Random.Range(minSpeed, maxSpeed));
            }

            if (Random.Range(0,100) <= powerupChance)
            {
                Vector2 powerupPosition = new Vector2(Random.Range(-powerupSpawn, powerupSpawn), 11.0f);
                Vector2 markerPosition = new Vector2(powerupPosition.x, powerupPosition.y - 6.5f);
                Powerup pwrupObject = Instantiate(pwrup, powerupPosition, Quaternion.identity);
                Instantiate(marker, markerPosition, Quaternion.identity);
                pwrupObject.Drop();
                powerupChance = -20;

                if (soundSettings.SoundActive())
                {
                    powerUpSound.Play();
                }            
            }
            else
            {
                powerupChance += 5;
            }

            yield return new WaitForSeconds(shapeWait);
        }
    }

    public static int Difficulty()
    {
        return difficulty;
    }

    public void SetDifficulty(int setDiff)
    {
        difficulty = setDiff;
    }

    public void AddScore()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
        if (score >= speedThreshold)
        {
            IncreaseSpeed();
            speedIncrement = Mathf.RoundToInt(speedIncrement * 1.3f);
            speedThreshold += speedIncrement;
        }

        if (soundSettings.SoundActive())
        {
            addScoreSound.Play();
        }

    }

    void IncreaseSpeed()
    {
        speedLevel++;
        increaseThreatText.MoveText();
        threatText.text = "Threat: " + speedLevel.ToString();
        if (speedLevel%2 == 0)
        {
            minSpeed += 0.3f;
        }
        else
        {
            maxSpeed += 0.4f;
        }

        if (soundSettings.SoundActive())
        {
            increaseThreatSound.Play();
        }
    }

    public void LoseLife()
    {
        lives--;
        TrackLives();

        if (soundSettings.SoundActive())
        {
            loseLifeSound.Play();
        }      
    }

    public void BonusLife()
    {
        powerupDisp.DisplayText(5);
        lives++;
        TrackLives();
    }

    void TrackLives()
    {
        
        livesText.text = "Lives Remaining: " + lives.ToString();
        if (lives == 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        switch (difficulty)
        {
            case 0:
                {
                    if (score > EasyHighScore)
                    {
                        EasyHighScore = score;
                        newHighScoreText.text = "NEW HIGH SCORE!";

                    }
                    break;
                }
            case 1:
                {
                    if (score > NormalHighScore)
                    {
                        NormalHighScore = score;
                        newHighScoreText.text = "NEW HIGH SCORE!";
                    }
                    break;
                }
            case 2:
                {
                    if (score > HardHighScore)
                    {
                        HardHighScore = score;
                        newHighScoreText.text = "NEW HIGH SCORE!";
                    }
                    break;
                }
        }

        gameOverText.text = "GAME OVER";
        mainMenuButton.SetActive(true);

        PlayerPrefs.SetInt("EasyHighScore", EasyHighScore);
        PlayerPrefs.SetInt("NormalHighScore", NormalHighScore);
        PlayerPrefs.SetInt("HardHighScore", HardHighScore);

        Time.timeScale = 0;
    }

    public void DisplayHighScores()
    {
        EasyHighScore = PlayerPrefs.GetInt("EasyHighScore", 0);
        EasyHighScoreText.text = "Easy: " + EasyHighScore.ToString();
        NormalHighScore = PlayerPrefs.GetInt("NormalHighScore", 0);
        NormalHighScoreText.text = "Normal: " + NormalHighScore.ToString();
        HardHighScore = PlayerPrefs.GetInt("HardHighScore", 0);
        HardHighScoreText.text = "Hard: " + HardHighScore.ToString();
    }

    public void DeleteAllScores()
    {
        PlayerPrefs.DeleteKey("EasyHighScore");
        PlayerPrefs.DeleteKey("NormalHighScore");
        PlayerPrefs.DeleteKey("HardHighScore");
        DisplayHighScores();
    }

    public void DestroyAll()
    {
        powerupDisp.DisplayText(3);
        GameObject[] destroyEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in destroyEnemies)
        {
            Destroy(enemy);
            for (int i = 0; i < 3; i++)
            {
                Instantiate(frag, enemy.transform.position, enemy.transform.rotation);
            }
            AddScore();
        }
    }

    public void InstantReload()
    {
        powerupDisp.DisplayText(4);
        leftTower.InstantReload();
        rightTower.InstantReload();
    }

    public void BonusScore()
    {
        powerupDisp.DisplayText(1);
        score = score + (speedLevel * 5);
        AddScore();
    }

    public void FireLasers()
    {
        powerupDisp.DisplayText(2);
        gear.FireLasers();
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        minSpeed = 1.0f;
        maxSpeed = 1.4f;
        shapeWait = 1.5f;
        lives = 3;
        score = 0;
        speedThreshold = 30;
        speedIncrement = 30;
        speedLevel = 1;
        powerupChance = -20;
        powerupSpawn = 6.5f;
        StartCoroutine(Spawnwaves());
        livesText.text = "Lives Remaining: " + lives.ToString();
        scoreText.text = "Score: " + score.ToString();
        threatText.text = "Threat: " + speedLevel.ToString();
        mainMenuButton.SetActive(false);
        clickMan.SetActive(true);
        if (difficulty == 2)
        {
            leftTower.CanReload(false);
            rightTower.CanReload(false);
        }
    }
}