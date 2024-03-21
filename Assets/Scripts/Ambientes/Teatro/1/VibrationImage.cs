using UnityEngine;

public class VibrationImage : MonoBehaviour
{
    public float intensidad = 5f; // Intensidad de la vibración
    public float velocidad = 10f;   // Velocidad de la vibración
    private RectTransform rectTransform;
    private Vector3 posicionInicial;
    private bool vibrando = false;

    private void Start()
    {
        // Obtener el RectTransform de la imagen y guardar la posición inicial
        rectTransform = GetComponent<RectTransform>();
        posicionInicial = rectTransform.position;
    }

    private void Update()
    {
        // Verificar si se ha presionado una tecla o botón
        if (Input.anyKeyDown && !vibrando)
        {
            // Iniciar la vibración
            StartCoroutine(Vibrar());
        }
    }

    private System.Collections.IEnumerator Vibrar()
    {
        vibrando = true;
        float tiempoInicio = Time.time;

        while (Time.time - tiempoInicio < 3f)
        {
            // Calcular el desplazamiento en función del tiempo
            float desplazamiento = Mathf.Sin(Time.time * velocidad) * intensidad;

            // Aplicar el desplazamiento a la posición vertical de la imagen
            rectTransform.position = posicionInicial + new Vector3(0f, desplazamiento, 0f);

            yield return null;
        }

        // Restaurar la posición inicial al finalizar la vibración
        rectTransform.position = posicionInicial;
        vibrando = false;
    }
}

