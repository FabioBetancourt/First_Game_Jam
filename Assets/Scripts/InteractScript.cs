using UnityEngine;
using UnityEngine.SceneManagement;  // Necesario para cambiar de escena

public class InteractScript : MonoBehaviour
{
    // Este método se llama cuando el Collider del objeto recibe una colisión
    void OnCollisionEnter(Collision collision)
    {
        // Comprueba si fue el jugador quien chocó con el objeto
        if (collision.gameObject.tag == "Player")
        {
            // Cambia a la escena de UI
            SceneManager.LoadScene("UiDesign");
        }
    }
}