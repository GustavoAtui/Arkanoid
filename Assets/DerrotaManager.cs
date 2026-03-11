using UnityEngine;
using TMPro;

public class DerrotaManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText.text = "Score: " + GameManager.PlayerScore;
    }
}