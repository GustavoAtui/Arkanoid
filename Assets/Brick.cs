using UnityEngine;

public class Brick : MonoBehaviour
{
    public int vida = 1;
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            vida--;

            if (vida == 1)
            {
                sr.color = Color.yellow;
            }

            if (vida <= 0)
            {
                GameManager.Instance.AddPoints(10);
                Destroy(gameObject);
            }
        }
    }
}