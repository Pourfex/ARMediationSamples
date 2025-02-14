using UnityEngine;
using UnityEngine.UI;

public class InitClick : MonoBehaviour
{
    public Button drawButton;
    public LineRenderer lineRenderer;
    public GameObject arrowR;
    public GameObject arrowL;

    public void Start()
    {
        drawButton.onClick.AddListener(DrawLine);
    }

    void DrawLine()
    {
        lineRenderer.gameObject.SetActive(true);
        arrowR.gameObject.SetActive(true);
        arrowL.gameObject.SetActive(true);
    }
}
