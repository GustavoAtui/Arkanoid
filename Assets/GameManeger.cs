using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static int PlayerScore = 0; // Pontuação do player 
    public int score = 0;
    public static GameManager Instance;

    public GUISkin layout;              // Fonte do placar
    GameObject theBall;                 // Referência ao objeto bola
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("Ball"); // Busca a referência da bola


    }

    // Update is called once per frame
    void Update()
    {

    }

    
    private void Awake()
    {
        // Garante que só exista um GameManager
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void AddPoints(int pontos)
    {
        score += pontos;
        PlayerScore++;
    }
    // incrementa a potuação
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Brick"))
        {
            PlayerScore++;
        }
    }
    // Gerência da pontuação e fluxo do jogo
    void OnGUI()
    {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 200, 30, 150, 100), "" + PlayerScore);


        if (GUI.Button(new Rect(Screen.width / -140, 20, 120, 53), "RESTART"))
        {
            PlayerScore = 0;

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (PlayerScore == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER ONE WINS");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
        
    }


}
