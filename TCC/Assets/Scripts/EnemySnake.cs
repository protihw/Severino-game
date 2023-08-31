using System.Collections;
using UnityEngine;

public class EnemySnake : MonoBehaviour
{
    public static EnemySnake enemy;
    public float moveSpeed = 3f;
    private Transform player;
    private Rigidbody2D rb;
    public Animator animator;
    
    private bool isDying = false;

    void Awake()
    {
        enemy = this;
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isDying)
        {
            Vector2 direction = new Vector2(player.position.x - transform.position.x, 0).normalized;
            rb.velocity = direction * moveSpeed;

            float angle = Mathf.Atan2(0, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
        
    }

    public void EliminateEnemy()
    {
        if (!isDying)
        {
            Debug.Log("Player killed enemy!");
            animator.SetBool("isDie", true);
            isDying = true;

            StartCoroutine(DestroyAfterDelay());
        }
    }

    private IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(1.25f);
        Destroy(gameObject);
    }
}
