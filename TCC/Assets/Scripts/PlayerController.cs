using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController player;
    public int score;
    public int heart;
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
        score = 0;
        heart = 3;
    }

    void Start()
    {
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
        if (collision.gameObject.CompareTag("EnemySnake"))
        {
            float playerY = transform.position.y;
            float enemyY = EnemySnake.enemySnake.transform.position.y;

            if (playerY > enemyY)
            {
                EnemySnake.enemySnake.EliminateEnemy();
            }
            else
            {
                Debug.Log("Player collided with enemy snake!");
                heart--;
                HeartManager.heartManager.UpdateHeart(heart);
                PlayerController.player.transform.position = new Vector3(-8.07f, PlayerController.player.transform.position.y, PlayerController.player.transform.position.z);
            }
        }

        if (collision.gameObject.CompareTag("EnemyDucky"))
        {
            float playerY = transform.position.y;
            float enemyY = EnemyDucky.enemyDucky.transform.position.y;

            Debug.Log(playerY);
            Debug.Log(enemyY);

            if (playerY > enemyY)
            {
                EnemyDucky.enemyDucky.EliminateEnemy();
            }
            else
            {
                Debug.Log("Player collided with enemy ducky!");
                heart--;
                HeartManager.heartManager.UpdateHeart(heart);
                PlayerController.player.transform.position = new Vector3(-8.07f, PlayerController.player.transform.position.y, PlayerController.player.transform.position.z);
            }
        }

        if (collision.gameObject.CompareTag("Coin"))
        {
            Debug.Log("Player collided with coin!");
            score++;
            Coin.coin.EliminateEnemy();
            ScoreManager.scoreManager.UpdateScore(score);
        }
        
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Player collided with obstacle!");
            heart--;
            HeartManager.heartManager.UpdateHeart(heart);
            PlayerController.player.transform.position = new Vector3(-8.07f, PlayerController.player.transform.position.y, PlayerController.player.transform.position.z);
        }
    }
}
