using System;
using UnityEngine;

public class LightSource : MonoBehaviour
{
    [SerializeField] Renderer[] effectedObject;
    private Vector3 lightNormal;
    [SerializeField] private float magnitude;
    [SerializeField] private float lightIntensity;
    
    private void Update()
    {
        Light();
    }
    [ContextMenu("Create Light")]
    private void Light()
    {
        lightNormal = (transform.position - effectedObject[0].transform.position);
        magnitude = lightNormal.magnitude;
        for (int i = 0; i < effectedObject.Length; i++)
        {
            effectedObject[i].sharedMaterial.SetVector("_LightDirection", lightNormal.normalized * lightIntensity/magnitude);
        }
    }
}
