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
        PlayerController.player.atacando = false;
    }

    public void EnableWhipCollider()
    {
        // Ativa o whipCollider no início da animação
        whipCollider.enabled = true;
        PlayerController.player.atacando = true;
        Sound.Instace.PLayerchicoteEffect();
    }
}
