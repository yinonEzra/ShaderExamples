using UnityEngine;

public class VertexPositionToColor : MonoBehaviour
{
    [SerializeField] Renderer[] rend;
    [SerializeField] bool heightOrDepth;
    [SerializeField]

    void Update()
    {
        int heightOrDepthInt = heightOrDepth ? 1 : 0;
        for(int i =0; i < rend.Length; i++) rend[i].sharedMaterial.SetFloat("_HeightOrDepth", heightOrDepthInt);
    }
}
