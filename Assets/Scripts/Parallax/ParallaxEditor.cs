using UnityEngine;

public class ParallaxEditor : MonoBehaviour
{
    Material mat;
    float distance;

    [Range(0f, 0.5f)]
    public float parallaxSpeed = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        distance += Time.deltaTime * parallaxSpeed;
        mat.SetTextureOffset("_MainTex", Vector2.right * distance);
    }
}
