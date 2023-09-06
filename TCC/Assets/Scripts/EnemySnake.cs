using System.Collections;
using UnityEngine;

public class EnemySnake : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Transform player;
    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded = false;
    private bool isDying = false;

    public float timer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        if (!isDying && isGrounded)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            if (distanceToPlayer <= 5)
            {
                Vector2 direction = new Vector2(player.position.x - transform.position.x, 0).normalized;
                rb.velocity = direction * moveSpeed;

                float angle = Mathf.Atan2(0, direction.x) * Mathf.Rad2Deg;

                transform.rotation = Quaternion.Euler(0, angle, 0);

                timer++;

                if (timer > 200)
                {
                    Sound.Instace.InimigoCobrar();

                    timer = 0;
                }
            }
            else
            {
                if (isGrounded)
                {
                    rb.velocity = Vector2.zero;
                }
                    
            }
        }
        else
        {
            if (isGrounded)
            {
                rb.velocity = Vector2.zero;
            }
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            // Ignorar colisão com objetos que têm a tag "coin".
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);
        }

        if (collision.gameObject.CompareTag("Thorns"))
        {
            EliminateEnemy();
        }
    }

    public void EliminateEnemy()
    {
        animator.SetBool("isDie", true);
        isDying = true;
        GetComponent<BoxCollider2D>().enabled = false;
        Destroy(gameObject, 0.3f);
    }   
}