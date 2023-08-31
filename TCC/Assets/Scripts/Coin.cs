using UnityEngine;

public class Coin : MonoBehaviour
{
    public static Coin coin;

    void Awake()
    {
        coin = this;
    }
    
    public void EliminateEnemy()
    {
        Destroy(gameObject);
    }
}
