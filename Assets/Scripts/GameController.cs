using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(GameUI))]
public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    [SerializeField] private int knifeCount;

    [Header("Knife Spawning")]
    [SerializeField] private Vector2 knifeSpawnPosition;
    [SerializeField] private GameObject knifeObject;
    [SerializeField] private GameObject logObject;
    [SerializeField] private GameObject shatteredLogObject;

    public GameUI GameUI { get; private set; }

    private void Awake()
    {
        Instance = this;
        GameUI = GetComponent<GameUI>();
        Vibration.Init();
    }

    private void Start()
    {
        GameUI.SetInitialDisplayedKnifeCount(knifeCount);
        SpawnKnife();
    }

    public void OnSuccessfulKnifeHit()
    {
        if (knifeCount > 0)
        {
            SpawnKnife();
        }
        else
        {
            StartGameOverSequence(true);
        }
    }

    private void SpawnKnife()
    {
        knifeCount--;
        Instantiate(knifeObject, knifeSpawnPosition, Quaternion.identity);
    }

    public void StartGameOverSequence(bool win)
    {
        StartCoroutine("GameOverSequenceCoroutine", win);
    }

    private IEnumerator GameOverSequenceCoroutine(bool win)
    {
        if (win)
        {
            logObject.SetActive(false);
            shatteredLogObject.SetActive(true);
            Vibration.Vibrate();
            int tempStreak = PlayerPrefs.GetInt("WinStreak") + 1;
            PlayerPrefs.SetInt("WinStreak", tempStreak);
            GameUI.SetWinStreakText("WinStreak - " + tempStreak);
            if (PlayerPrefs.GetInt("WinStreak") > PlayerPrefs.GetInt("Record"))
            {
                GameUI.SetRecordText(tempStreak);
            }
            yield return new WaitForSecondsRealtime(1f);
            RestartGame();

        }
        else
        {
            GameUI.ShowRestartButton();
            PlayerPrefs.SetInt("WinStreak", 0);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

    public void GoHome()
    {
        SceneManager.LoadScene(0);
    }
}