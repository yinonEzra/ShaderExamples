using System;
using UnityEngine;
[ExecuteAlways]
public class SmokeFXController : MonoBehaviour
{
    [SerializeField] Renderer[] rend;
    [SerializeField] float _speed = 0.5f;
    [SerializeField] AnimationCurve _curve;
    private float _updatedMask;
    [SerializeField] float _t;
    private void Update()
    {
        AnimationLoop();
    }
    
    private void AnimationLoop()
    {
        if (_t < 1)
        {
            _t += Time.deltaTime * _speed;
            _updatedMask = Mathf.Lerp(0,0.55f,_curve.Evaluate(_t));
            for (int i = 0; i < rend.Length; i++)
            {
                rend[i].material.SetFloat("_Mask", _updatedMask);
                rend[i].material.SetFloat("_Seed", i*1.0f);
            }
        }
    }
}
