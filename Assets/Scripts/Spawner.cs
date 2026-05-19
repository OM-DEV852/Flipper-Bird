using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabs;
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 1f;

    // Se invoca automaticamente cuendo habilitas un GameObjects
    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }
    private void Spawn() 
    {
        // El Quaternion.identity es para que no se le aplique rotación a los pilares
        GameObject pipesPrefabs = Instantiate(prefabs, transform.position, Quaternion.identity);

        // Esto permite colocar los pilares de forma aleatoria en el escenario
        pipesPrefabs.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}