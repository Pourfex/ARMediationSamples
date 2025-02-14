using UnityEngine;

public class ShowButtonOnArrival : MonoBehaviour
{
    public GameObject canvasUI; // Référence au Canvas
    public Camera camera;

    private void Start()
    {
        if (canvasUI != null)
        {
            canvasUI.SetActive(false); // Cache le Canvas au début
        }
    }

    public void Update()
    {
        if((camera.transform.position - transform.position).magnitude < 2f)
        {
            canvasUI.SetActive(true); // Affiche le Canvas si la caméra est proche de l'objet
        }
    }
}
