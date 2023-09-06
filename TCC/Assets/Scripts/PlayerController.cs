using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    public static PlayerController player;
    public int score;
    public int heart;
    public int level;
    public bool died;
    public float moveSpeed = 4f;
    public float jumpForce = 6f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public int timerEffect;

    public bool atacking;

    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded = false;
    public PolygonCollider2D room;


    void Awake()
    {
        player = this;
        heart = PlayerPrefs.GetInt("Lives");
        score = PlayerPrefs.GetInt("Score");
        level = PlayerPrefs.GetInt("Levels");
    }

    void Start()
    {
        PlayerPrefs.SetInt("Lives", 3);
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("Levels", 2);

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        if (isGrounded && horizontalInput != 0)
        {
            timerEffect++;
            if (timerEffect >= 200)
            {
                Sound.Instace.PLayerCorrerEffect();
                timerEffect = 0;
            }
        }

        // Virar o jogador para o lado esquerdo (escala x negativa) quando ele se move para a esquerda
        if (horizontalInput < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        // Virar o jogador para o lado direito (escala x positiva) quando ele se move para a direita
        else if (horizontalInput > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        animator.SetBool("isPressed", Mathf.Abs(horizontalInput) > 0);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetBool("isPressedJump", true);

            Sound.Instace.PLayerpularEffect();

        }
        else
        {
            animator.SetBool("isPressedJump", false);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("isHiting");
        }

        if (PlayerPrefs.GetInt("Lives") <= 0)
        {
            LevelManager.levelManager.GameOverAnimation();
        }

        if (!room.bounds.Contains(transform.position))
        {
            LevelManager.levelManager.GameOver();
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // colisão com a cobra
        if (collision.gameObject.CompareTag("EnemySnake"))
        {
            float playerY = transform.position.y;
            float enemyY = collision.gameObject.transform.position.y;

            if (playerY > enemyY)
            {
                collision.gameObject.GetComponent<EnemySnake>().EliminateEnemy();
            }
            else
            {
                GetHited(collision);
            }
        }

        // colisão com o pato
        if (collision.gameObject.CompareTag("EnemyDucky"))
        {
            float playerY = transform.position.y;
            float enemyY = collision.gameObject.transform.position.y;

            if (playerY > enemyY)
            {
                collision.gameObject.GetComponent<EnemyDucky>().EliminateEnemy();
            }
            else
            {
                GetHited(collision);
            }
        }

        // colisão com obstaculos
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GetHited(collision);
        }

        // colisão com espinhos
        if (collision.gameObject.CompareTag("Thorns"))
        {
            LevelManager.levelManager.GameOver();
        }

        // colisão com as moedas
        if (collision.gameObject.CompareTag("Coin"))
        {

            Sound.Instace.ScenarioCoin();

            score++;

            collision.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            Destroy(collision.gameObject);

            PlayerPrefs.SetInt("Score", score);
            ScoreManager.scoreManager.UpdateScore(score);
        }

        // colisão com checkpoint
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            if (PlayerPrefs.GetInt("Levels") > 2)
            {
                level++;
            }
            else
            {
                PlayerPrefs.SetInt("Levels", 4);
            }
            LevelManager.levelManager.ChangeNextScene();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Box") && atacking)
        {
            Sound.Instace.ScenarioBox();

            collision.GetComponent<Animator>().Play("BoxDying");

            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Destroy(collision.gameObject, 0.5f);
        }

        if (collision.gameObject.CompareTag("EnemySnake") && atacking)
        {
            collision.gameObject.GetComponent<EnemySnake>().EliminateEnemy();
        }

        if (collision.gameObject.CompareTag("EnemyDucky") && atacking)
        {
            collision.gameObject.GetComponent<EnemyDucky>().EliminateEnemy();
        }

        atacking = false;
    }

    private void GetHited(Collision2D collision)
    {
        if (!Physics2D.GetIgnoreCollision(GetComponent<Collider2D>(), collision.collider))
        {
            heart--;

            animator.SetBool("isHit", true);
            if (!collision.gameObject.CompareTag("Obstacle"))
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider, true);

            PlayerPrefs.SetInt("Lives", heart);
            HeartManager.heartManager.UpdateHeart(heart);

            Sound.Instace.PLayerdanoEffect();

            StartCoroutine(ReturnToNormalState());
            StartCoroutine(ReturnToVunelrable(collision));
        }
    }

    private IEnumerator ReturnToNormalState()
    {
        yield return new WaitForSeconds(3f);

        animator.SetBool("isHit", false);
    }

    private IEnumerator ReturnToVunelrable(Collision2D collision)
    {
        yield return new WaitForSeconds(3f);

        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider, false);
    }
}
