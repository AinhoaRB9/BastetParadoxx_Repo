using UnityEngine;

public class FloatingPickup : MonoBehaviour
{
    public float floatSpeed = 1f;    // Velocidad del movimiento de flotación
    public float floatHeight = 0.5f; // Altura de la flotación
    public float rotationSpeed = 50f; // Velocidad de rotación

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position; // Guarda la posición inicial del objeto
    }

    void Update()
    {
        // Movimiento oscilante arriba y abajo
        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(startPos.x, newY, startPos.z);

        // Rotación suave
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
