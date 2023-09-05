using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;
using UnityEngine.SocialPlatforms.Impl;

public class WhipController : MonoBehaviour
{
    public static WhipController whipController;
    public BoxCollider2D whipCollider;

    public void Awake()
    {
        whipController = this;
    }

    private void Start()
    {
        // Desativa o whipCollider inicialmente
        whipCollider.enabled = false;
    }

    public void DisableWhipCollider()
    {
        // Desativa o whipCollider ao final da animação
        whipCollider.enabled = false;
    }

    public void EnableWhipCollider()
    {
        // Ativa o whipCollider no início da animação
        whipCollider.enabled = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // colisão com o pato
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);
        }

        if (collision.gameObject.CompareTag("Box"))
        {
            Debug.Log("Player collided with obstacle!");
        }

        if (collision.gameObject.CompareTag("EnemySnake"))
        {
            collision.gameObject.GetComponent<EnemySnake>().EliminateEnemy();
        }

        // colisão com o pato
        if (collision.gameObject.CompareTag("EnemyDucky"))
        {
            collision.gameObject.GetComponent<EnemyDucky>().EliminateEnemy();
        }

        // colisão com espinhos
        if (collision.gameObject.CompareTag("Thorns"))
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);
        }

        // colisão com as moedas
        if (collision.gameObject.CompareTag("Coin"))
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);
        }

        // colisão com checkpoint
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);
        }
    }
}
