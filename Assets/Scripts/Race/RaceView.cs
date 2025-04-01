using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RaceView : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Button buttonRestart;
    [SerializeField] private Text finishedText;

    public void Initialize()
    {
        gameOverPanel.SetActive(false);
        buttonRestart.onClick.AddListener(RestartGame);
    }
    
    public void SetTextWin()
    {
        gameOverPanel.SetActive(true);
        finishedText.text = "WIN";
    }

    public void SetTextLose(int positionFinished)
    {
        gameOverPanel.SetActive(true);
        finishedText.text = $"Your horse finished {positionFinished} in the race";
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
