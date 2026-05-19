using UnityEngine;

public class Parallax : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    public float AnimationSpeed;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    
    void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(AnimationSpeed * Time.deltaTime, 0);
    }
}