using System;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class VertexPositionsToText : MonoBehaviour
{
    [SerializeField] MeshFilter rend;
    [SerializeField] private string[] verticesStrings;
    [SerializeField] Vector3[] vertices;
    [SerializeField] Transform[] vertexTransforms;
    [SerializeField] TMP_Text[] vertexTexts;
    Canvas canvas;
    Camera camera;
    private Vector3 vertexPos;
    private Vector3 dirToCamera;
    [SerializeField]private bool worldPos = false;
    
    private void Awake()
    {
        canvas = transform.parent.root.GetComponent<Canvas>();
        camera = Camera.main;
        vertices = rend.mesh.vertices;
        int vertexCount = rend.mesh.vertexCount;
        verticesStrings = new string[vertexCount];
        for(int i = 0; i < verticesStrings.Length; i++)
        {
            vertexPos = rend.mesh.vertices[i];
            verticesStrings[i] = vertexPos.ToString("N1");
            vertexTransforms[i].localPosition = vertexPos;
            vertexTexts[i].text = verticesStrings[i];
            vertexTexts[i].transform.position = WorldToCanvasPosition(canvas, camera, vertexTransforms[i].position);
        }
    }

    void Update()
    {
        for(int i = 0; i < verticesStrings.Length; i++)
        {
            vertexPos = vertexTransforms[i].localPosition;
            vertices[i] = vertexPos;
            verticesStrings[i] = SetAxis(vertexPos).ToString("N1");
            if (worldPos)
            {
                verticesStrings[i] = vertexTransforms[i].position.ToString("N1");
            }
            vertexTexts[i].text = verticesStrings[i];
            vertexTransforms[i].localPosition += vertexTransforms[i].localPosition.normalized;
            Vector3 posToText = WorldToCanvasPosition(canvas, camera, vertexTransforms[i].position);
            vertexTexts[i].transform.position = posToText;
            vertexTransforms[i].localPosition = vertexPos;
        }
        rend.mesh.vertices = vertices;
    }

    public static Vector3 WorldToCanvasPosition(Canvas canvas, Camera camera, Vector3 worldPosition)
    {
        Vector3 currentScreenPos = camera.WorldToScreenPoint(worldPosition);
        currentScreenPos.z = canvas.planeDistance;
        Vector3 pos = canvas.worldCamera.ScreenToWorldPoint(currentScreenPos);
        return pos;
    }
    public Vector3 SetAxis(Vector3 vector)
    {
        Vector3 vec = new Vector3(vector.x, vector.z, vector.y);
        return vec;
    }
}
