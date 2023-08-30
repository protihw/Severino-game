using UnityEngine;

public class EnemySnake : MonoBehaviour
{
    public static EnemySnake enemy;
    public float moveSpeed = 3f;
    private Transform player;
    private Rigidbody2D rb;
    
    void Awake()
    {
        enemy = this;
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 direction = new Vector2(player.position.x - transform.position.x, 0).normalized;
        rb.velocity = direction * moveSpeed;

        // Calcula a rotação para olhar na direção do jogador (apenas horizontal)
        float angle = Mathf.Atan2(0, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, angle, 0);
    }

    public void EliminateEnemy()
    {
        Debug.Log("Player killed enemy!");
        Destroy(gameObject);
    }
}
