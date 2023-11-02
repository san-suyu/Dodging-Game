using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int score;
    [SerializeField] TMP_Text scoreText;

    [SerializeField] GameObject[] obstacles;

    [SerializeField] GameObject loseScreen;

    [SerializeField] float repeatRate;

    [SerializeField] Transform spawn;

    [SerializeField] float yVariance;
    [SerializeField] float xVariance;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), 4f, repeatRate);

        InvokeRepeating(nameof(IncreaseScore), 8f, repeatRate);
    }

    public void LoseGame()
    {
        CancelInvoke();
        loseScreen.SetActive(true);
    }

    void SpawnObstacle()
    {
        Vector3 ranPosition = new Vector3(spawn.position.x + Random.Range(-xVariance, xVariance),
            spawn.position.y + Random.Range(-yVariance, yVariance), spawn.position.z);

        GameObject obstacle = Instantiate(obstacles[Random.Range(0, obstacles.Length - 1)], ranPosition, Quaternion.identity);

        Destroy(obstacle, 10);
    }

    void IncreaseScore()
    {
        score++;

        scoreText.text = "Score: " + score.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
