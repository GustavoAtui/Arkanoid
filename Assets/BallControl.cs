using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rb2d;

    

    void GoBall()
    {
        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            rb2d.AddForce(new Vector2(20, -15));
        }
        else
        {
            rb2d.AddForce(new Vector2(-20, -15));
        }
    }


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); // Inicializa o objeto bola
        Invoke("GoBall", 1);

    }

    void Update()
    {
        if (transform.position.x > 7f || transform.position.x < -7f || transform.position.y > 9f || transform.position.y < -9f)
        {
            ResetBall();
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            Vector2 vel;
            vel.x = rb2d.linearVelocity.x;
            vel.y = (rb2d.linearVelocity.y / 2) + (coll.collider.attachedRigidbody.linearVelocity.y / 3);
            rb2d.linearVelocity = vel;
        }

        if (coll.gameObject.CompareTag("Brick"))
        {
            Destroy(coll.gameObject);
            GameManager.Instance.AddPoints(10);
        }
    }

    void ResetBall()
    {
        rb2d.linearVelocity = Vector2.zero;
        transform.position = new Vector3(0f, -3.7f, 0f);
    }

    void RestartGame()
    {
        ResetBall();
        Invoke("GoBall", 1);
    }



}
