using UnityEngine;
using System.Collections;  

public class PlayerController : MonoBehaviour
{
    public static PlayerController player;
    public int score;
    public int heart;
    public int level;
    public bool died;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded = false;

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
        PlayerPrefs.SetInt("Levels", 2);
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

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
        }
        else
        {
            animator.SetBool("isPressedJump", false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // colis�o com a cobra
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
                Debug.Log("Player collided with enemy snake!");

                if (Physics2D.GetIgnoreCollision(GetComponent<Collider2D>(), collision.collider) == false)
                {
                    heart--;
                }

                animator.SetBool("isHit", true);
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);

                PlayerPrefs.SetInt("Lives", heart);
                HeartManager.heartManager.UpdateHeart(heart);

                StartCoroutine(ReturnToNormalState());
                StartCoroutine(ReturnToVunelrable(collision));
            }
        }

        // colis�o com o pato
        if (collision.gameObject.CompareTag("EnemyDucky"))
        {
            float playerY = transform.position.y;
            float enemyY = collision.gameObject.transform.position.y;

            Debug.Log(playerY);
            Debug.Log(enemyY);

            if (playerY > enemyY)
            {
                collision.gameObject.GetComponent<EnemyDucky>().EliminateEnemy();
            }
            else
            {
                Debug.Log("Player collided with enemy ducky!");

                if (Physics2D.GetIgnoreCollision(GetComponent<Collider2D>(), collision.collider) == false)
                {
                    heart--;
                }

                animator.SetBool("isHit", true);
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);

                PlayerPrefs.SetInt("Lives", heart);
                HeartManager.heartManager.UpdateHeart(heart);

                StartCoroutine(ReturnToNormalState());
                StartCoroutine(ReturnToVunelrable(collision));
            }
        }

        if (collision.gameObject.CompareTag("Coin"))
        {
            Debug.Log("Player collided with coin!");
            score++;
            collision.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            Destroy(collision.gameObject,0.2f);
            ScoreManager.scoreManager.UpdateScore(score);
        }

        // colis�o com obstaculos
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Player collided with obstacle!");

            if (Physics2D.GetIgnoreCollision(GetComponent<Collider2D>(), collision.collider) == false)
            {
                heart--;
            }

            animator.SetBool("isHit", true);
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);

            PlayerPrefs.SetInt("Lives", heart);
            HeartManager.heartManager.UpdateHeart(heart);

            StartCoroutine(ReturnToNormalState());
            StartCoroutine(ReturnToVunelrable(collision));
        }

        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            Debug.Log("Player collided with checkpoint!");
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

    private IEnumerator ReturnToNormalState()
    {
        yield return new WaitForSeconds(2.0f);

        animator.SetBool("isHit", false);
    }

    private IEnumerator ReturnToVunelrable(Collision2D collision)
    {
        yield return new WaitForSeconds(2.0f);

        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider, false);
    }
}
