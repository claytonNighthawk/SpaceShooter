using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public GUIText scoreText;
    public GUIText restartText;
    public GUIText gameOverText;

    private bool gameOver;
    private bool restart;
    private int score;

    void Start() {
        gameOver = false;
        restart = false;
        gameOverText.text = "";
        restartText.text = "";

        score = 0;
        UpdateScore();
        StartCoroutine(Spawn_Waves());
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    IEnumerator Spawn_Waves() {
        while (true) {
            for (int i = 0; i < hazardCount; i++) {
                yield return new WaitForSeconds(startWait);
                Vector3 spawnPositon = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPositon, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            if (gameOver) {
                restart = true;
                break;
            }
        }
    }

    void UpdateScore() {
        scoreText.text = "Score: " + score;
    }

    public void AddScore(int newScore) {
        score += newScore;
        UpdateScore();
    }

    public void GameOver() {
        gameOverText.text = "Game Over";
        restartText.text = "Press R for restart";
        gameOver = true;
    }
}
