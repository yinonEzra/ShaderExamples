using UnityEngine;
using TMPro;
public class TextToColor : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI[] text;
    [SerializeField] private Color[] colors;
    [SerializeField] private Renderer rend;

    void Update()
    {
        for(int i = 0; i < text.Length; i++)
        {
            text[i].text = "("+colors[i].r.ToString("N1") + ", " + colors[i].g.ToString("N1") + ", " + colors[i].b.ToString("N1") + ", " + colors[i].a.ToString("N1")+")";
            //colors[i] = ParseVector4(text[i].text);
            int index = i + 1;
            rend.material.SetColor("_Color"+index, colors[i]);
        }
    }
    Vector4 ParseVector4(string input)
    {
        // Remove surrounding parentheses
        input = input.Trim(new char[] { '(', ')' });
        // Split the string by commas
        string[] parts = input.Split(',');

        if (parts.Length != 4)
            throw new System.FormatException("Input must contain four comma-separated values.");

        // Parse each part to a float and create a Vector4
        float x = float.Parse(parts[0]);
        float y = float.Parse(parts[1]);
        float z = float.Parse(parts[2]);
        float w = float.Parse(parts[3]);

        return new Vector4(x, y, z, w);
    }

}
