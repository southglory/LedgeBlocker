using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Time")]
    public static float maxTime = 100f;
    public static float playTime;
    public static float maxComboTime = 3f;
    public static float playComboTime;
    public static bool isGameOver = false;
    public static bool isGameStart;


    [Header("Player")]
    public static float score;
    public static int hit;
    public static int combo;
    public static int maxComboCount = 0;

    [Header("UI")]
    public GameObject uiInfo;
    public GameObject uiSelect;
    public GameObject uiGameOver;
    public GameObject uiGameStart;
    public GameObject uiNewRecord;

    static GameManager instance;

    void Start()
    {
        Application.targetFrameRate = 60;
        Init();
    }

    void Init()
    {
        instance = this;
        playTime = 0;
        playComboTime = 0;
        isGameOver = true;
        score = 0;
        hit = 0;
        combo = 0;
        maxComboCount = 0;

        if (!PlayerPrefs.HasKey("Score"))
        {
            PlayerPrefs.SetFloat("Score", 0f);
        }
    }

    public static void Success()
    {
        hit++;
        combo++;
        score += 1 + (combo * 0.1f);
        playComboTime = 0;
        maxCombo();
    }

    public static void Fail()
    {
        playTime += 10f;
        combo = 0;
    }

    public static void maxCombo()
    {
        if (combo > maxComboCount)
        {
            maxComboCount = combo;
        }
    }

    IEnumerator ComboTime()
    {
        while (!isGameOver)
        {
            yield return null;
            playComboTime += Time.deltaTime;

            if (playComboTime > maxComboTime)
            {
                combo = 0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
            return;
        
        GameTimer();
    }

    void GameTimer()
    {
        playTime += Time.deltaTime;

        if (playTime > maxTime)
        {
            GameOver();
        }
    }

    public void GameStart()
    {
        isGameOver = false;
        uiInfo.SetActive(true);
        uiSelect.SetActive(true);
        uiGameStart.SetActive(false);
        instance.StartCoroutine(instance.ComboTime());

    }

    void GameOver()
    {
        isGameOver = true;
        uiInfo.SetActive(false);
        uiSelect.SetActive(false);
        uiGameOver.SetActive(true);

        float maxScore = PlayerPrefs.GetFloat("Score");
        if (score > maxScore)
        {
            PlayerPrefs.SetFloat("Score", score);
            uiNewRecord.SetActive(true);
        }
        else
        {
            uiNewRecord.SetActive(false);
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene("Main");
    }
}
