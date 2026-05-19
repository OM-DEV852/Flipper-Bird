using UnityEngine;

public class Pillars : MonoBehaviour
{
    public float speed = 5f;
    private float leftEdge;

    private void Start()
    {
        // Vamos a establecer el margen izquierdo de la pantalla, si le digo -1 me salgo
        // fuera de los margenes de la pantalla
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    private void Update()
    {
        PillarsMovement();
        DestroyPillars();
    }

    private void PillarsMovement() 
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    private void DestroyPillars() 
    {
        // Si la posición de la que hemospeusto es menor se desstruye.
        if(transform.position.x < leftEdge) 
        {
            Destroy(gameObject);
        }
    }
}
