using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider slider;
    public Transform playerTransform;
    public float maxZPosition;
    public Gradient gradient;

    void Update()
    {
        // Calcula la proporción de la posición actual del jugador en relación a la posición máxima.
        float progress = playerTransform.position.z / maxZPosition;

        // Asegúrate de que el progreso esté en el rango [0, 1].
        progress = Mathf.Clamp01(progress);

        // Actualiza la barra de progreso.
        slider.value = progress;
        
        // Cambia el color de la barra de progreso.
        var fill = slider.fillRect.GetComponent<UnityEngine.UI.Image>();
        fill.color = gradient.Evaluate(progress);
    }
}