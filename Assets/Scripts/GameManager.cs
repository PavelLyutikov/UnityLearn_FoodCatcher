using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> foods;
    [SerializeField] Button restartButton;
    [SerializeField] GameObject titleScreen;

    private float spawnRate = 2.0f;
    public bool isGameActive;

    [SerializeField] Text gameOverText;
    [SerializeField] Text scoreText;
    public int score = 0;

    public void StartGame()
    {
        isGameActive = true;
        score = 0;
        scoreText.gameObject.SetActive(true);
        StartCoroutine(SpawnFoods());

        titleScreen.gameObject.SetActive(false);
    }

    IEnumerator SpawnFoods()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, foods.Count);
            Instantiate(foods[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
