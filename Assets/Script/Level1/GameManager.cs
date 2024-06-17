using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    [SerializeField]
    private TextMeshProUGUI scoretext = null;

    [SerializeField]
    private GameObject NextLevel = null;

    [SerializeField]
    private GameObject GameOver = null;

    [SerializeField]
    public  int maxscore;

    private int score ;

    [SerializeField]
    private int jumlahSampah;



    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        scoretext.SetText($"0/{maxscore}");
    }


    public void AddScore(int score)
    {
        this.score += score;
        scoretext.SetText($"{this.score}/{maxscore}");
        jumlahSampah--;

        if (this.score == maxscore)
        {
            ShowNextLevel();
        }
        else if (jumlahSampah == 0)
        {
            ShowGameOver();
        }

    }


    public void ShowNextLevel()
    {
        NextLevel.SetActive(true);
    }

    public void ShowGameOver()
    {
        GameOver.SetActive(true);
    }

    public void NextLevelLoad()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartLevelLoad()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenuLevelLoad()
    {
        SceneManager.LoadScene(0);
    }
}
