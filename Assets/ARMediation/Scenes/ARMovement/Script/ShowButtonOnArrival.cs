using UnityEngine;

public class ShowButtonOnArrival : MonoBehaviour
{
    public GameObject canvasUI; // R�f�rence au Canvas
    public Camera camera;

    private void Start()
    {
        if (canvasUI != null)
        {
            canvasUI.SetActive(false); // Cache le Canvas au d�but
        }
    }

    public void Update()
    {
        if((camera.transform.position - transform.position).magnitude < 2f)
        {
            canvasUI.SetActive(true); // Affiche le Canvas si la cam�ra est proche de l'objet
        }
    }
}
