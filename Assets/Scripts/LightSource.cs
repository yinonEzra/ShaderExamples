using System;
using UnityEngine;

public class LightSource : MonoBehaviour
{
    [SerializeField] Renderer[] effectedObject;
    private Vector3 lightNormal;
    private float magnitude;
    [SerializeField] private float lightIntensity;
    
    private void Update()
    {
        Light();
    }
    [ContextMenu("Create Light")]
    private void Light()
    {
        if (Application.isPlaying)
        {            
            for (int i = 0; i < effectedObject.Length; i++)
            {
                lightNormal = (transform.position - effectedObject[i].transform.position);
                magnitude = lightNormal.magnitude;
                effectedObject[i].material.SetVector("_LightDir", lightNormal.normalized * lightIntensity/magnitude);
            }
        }
        else
        {
            for (int i = 0; i < effectedObject.Length; i++)
            {
                lightNormal = (transform.position - effectedObject[i].transform.position);
                magnitude = lightNormal.magnitude;
                effectedObject[i].sharedMaterial.SetVector("_LightDir", lightNormal.normalized * lightIntensity/magnitude);
            }
        }
    }
}
