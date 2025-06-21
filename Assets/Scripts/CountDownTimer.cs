using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro; // Ensure you have TextMeshPro package installed for this

public class CountDownTimer : MonoBehaviour
{
    public float timeRemaining = 60f;
    public TMP_Text countdownText;

    private bool isGameOver = false;

    void Update()
    {
        if (isGameOver) return;

        timeRemaining -= Time.deltaTime;
        countdownText.text = "Time: " + Mathf.CeilToInt(timeRemaining).ToString();

        if (timeRemaining <= 0f)
        {
            isGameOver = true;
            countdownText.text = "Time: 0";
            SceneManager.LoadScene("Game Over"); // Your actual scene name
        }
    }
}
