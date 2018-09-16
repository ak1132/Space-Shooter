using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public Text scoreText;
    public Text restartText;
    public Text gameOverText;

    private int score;
    private bool gameover, restart;

    private void Start()
    {
        score = 0;
        gameover = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        StartCoroutine(spawnWaves());
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("Main");
        }
    }

    IEnumerator spawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while(true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            if(gameover)
            {
                restart = true;
                restartText.text = "Press R to Restart";
                break;
            }
        } 
    }

    public void addScore(int scoreVal)
    {
        score += scoreVal;
        updateScore();
    }

    void updateScore()
    {
        scoreText.text = "Score : " + score;
    }

    public void gameOver()
    {
        gameOverText.text = "Game Over";
        gameover = true;
    }
}