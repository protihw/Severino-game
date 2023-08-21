using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverArrowButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image arrowImage; // Arraste a imagem da seta para esse campo no Inspector

    private void Start()
    {
        arrowImage.gameObject.SetActive(false); // Começa com a seta desativada
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        arrowImage.gameObject.SetActive(true); // Mostra a seta quando o mouse entra no botão
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        arrowImage.gameObject.SetActive(false); // Esconde a seta quando o mouse sai do botão
    }
}
