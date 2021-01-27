using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject panelKnives;
    [SerializeField] private GameObject iconKnife;
    [SerializeField] private GameObject log;
    [SerializeField] private Color usedKnifeIconColor;
    [SerializeField] private TMP_Text winstreakText;
    [SerializeField] private TMP_Text recordText;

    private int knifeIconIndexToChange = 0;

    private void Start()
    {
        SetWinStreakText("WinStreak - " + PlayerPrefs.GetInt("WinStreak"));
        SetRecordText(PlayerPrefs.GetInt("Record"));
    }

    public void ShowRestartButton()
    {
        gameOverUI.SetActive(true);
        log.SetActive(false);
    }

    public void SetInitialDisplayedKnifeCount(int count)
    {
        for (int i = 0; i < count; i++)
            Instantiate(iconKnife, panelKnives.transform);
    }

    public void DecrementDisplayedKnifeCount()
    {
        panelKnives.transform.GetChild(knifeIconIndexToChange++).GetComponent<Image>().color = usedKnifeIconColor;
    }

    public void SetWinStreakText(string text)
    {
        winstreakText.text = text;
    }

    public void SetRecordText(int number)
    {
        PlayerPrefs.SetInt("Record", number);
        recordText.text = "Record - " + PlayerPrefs.GetInt("Record");
    }
}