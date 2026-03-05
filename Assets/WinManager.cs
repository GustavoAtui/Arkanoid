using TMPro;
using UnityEngine;

public class WinManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;

    void Start()
    {
        ScoreText.text = "Score: " + GameManager.PlayerScore;
    }
}