using UnityEngine;

public class VertexPositionToColor : MonoBehaviour
{
    [SerializeField] Renderer[] rend;
    [SerializeField] bool heightOrDepth;
    [SerializeField] private Color colorA;
    [SerializeField] private Color colorB;
    [Range(0,1)]
    [SerializeField] private float _texturePower;
    void Update()
    {
        int heightOrDepthInt = heightOrDepth ? 1 : 0;
        for(int i =0; i < rend.Length; i++) rend[i].sharedMaterial.SetFloat("_HeightOrDepth", heightOrDepthInt);
        for(int i =0; i < rend.Length; i++) rend[i].sharedMaterial.SetColor("_ColorA", colorA);
        for(int i =0; i < rend.Length; i++) rend[i].sharedMaterial.SetColor("_ColorB", colorB);
        for(int i =0; i < rend.Length; i++) rend[i].sharedMaterial.SetFloat("_TexturePower", _texturePower);
    }
}
