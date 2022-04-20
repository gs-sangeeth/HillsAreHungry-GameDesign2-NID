using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [HideInInspector]
    public int snowBallCount = 0;

    [HideInInspector]
    public GameObject bottomSnowBall;

    public Text snowBallCountText;

    public SpriteRenderer bgRenderer;
    public SpriteRenderer mountainRenderer;

    public Sprite[] bgs;
    public Sprite[] mountains;

    [HideInInspector]
    public bool GameOver = false;

    float timer = 1f;
    public GameObject gameOverText;

    public int requiredSnowBallCount;
    public Slider slider;

    [HideInInspector]
    public int totalSnowBallsEaten = 0;

    public GameObject pauseMenu;
    public GameObject gameOverPopup;
    private bool go = false;

    public GameObject levelCompletePopup;

    void Start()
    {
        instance = this;
        Time.timeScale = 1;

        slider.maxValue = requiredSnowBallCount;
    }

    private void Update()
    {
        snowBallCountText.text = snowBallCount.ToString();

        slider.value = totalSnowBallsEaten;

        if (GameOver)
        {
            if (!go)
            {
                bgRenderer.sprite = bgs[1];
                mountainRenderer.sprite = mountains[1];
            }
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                bgRenderer.sprite = bgs[2];
                mountainRenderer.sprite = mountains[2];

                timer = 2f;

                if (go)
                {
                    Time.timeScale = 0;
                    //gameOverText.SetActive(true);
                    gameOverPopup.SetActive(true);
                }

                go = true;
            }
        }

        if (totalSnowBallsEaten >= requiredSnowBallCount)
        {

            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Time.timeScale = 0;
                levelCompletePopup.SetActive(true);
            }
        }
    }

    public void DestroySnowBalls(int count = 0)
    {
        if (bottomSnowBall != null)
        {
            bottomSnowBall.GetComponent<Snowball>().DestroySnowBalls();
        }
    }

    public void UpdateAllTimers()
    {
        GameObject[] dbs = GameObject.FindGameObjectsWithTag("DialogueBox");
        foreach (GameObject db in dbs)
        {
            db.GetComponent<DialogueBox>().GiveMoreTime();
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

}
