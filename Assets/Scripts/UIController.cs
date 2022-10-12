using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private GameController _gameController;
    [SerializeField] private TextMeshProUGUI levelCounter;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject gamePanel;

    private void Start()
    {
        _gameController = FindObjectOfType<GameController>();
    }

    private void Update()
    {
        levelCounter.text = _gameController.currentLevel.ToString();
    }
    
    public void Pause()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        mainMenuPanel.SetActive(false);
        gamePanel.SetActive(true);
    }
}
