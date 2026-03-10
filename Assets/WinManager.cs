using UnityEngine;
using TMPro;

public class VitoriaManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText.text = "Score: " + GameManager.PlayerScore;
    }
}