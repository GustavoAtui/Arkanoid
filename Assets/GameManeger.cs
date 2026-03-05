using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int PlayerScore = 0;
    public static GameManager Instance;


    public void PlayerDied(){
        PlayerScore = 0;
        SceneManager.LoadScene("MenuInicial");
    }

    
    public GUISkin layout;
    GameObject theBall;

    bool mudandoFase = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    

    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("Ball");
    }

    void Update()
    {
        if (!mudandoFase && FindObjectsOfType<Brick>().Length == 0)
        {
            mudandoFase = true;
            Invoke("ProximaFase", 2f);
        }
    }

    public void AddPoints(int pontos)
    {
        PlayerScore += pontos;
    }

    void ProximaFase()
    {
        int indexAtual = SceneManager.GetActiveScene().buildIndex;


        if (indexAtual + 1 < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(indexAtual + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    void OnGUI()
    {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 200, 30, 150, 100), "" + PlayerScore);

        if (GUI.Button(new Rect(Screen.width / -140, 20, 120, 53), "RESTART"))
        {
            PlayerScore = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}