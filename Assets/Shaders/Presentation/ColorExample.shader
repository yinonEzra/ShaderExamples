Shader "Unlit/ColorExample"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color1 ("Color", Color) = (1,1,1,1)
        _Color2 ("Color", Color) = (1,1,1,1)
        _Color3 ("Color", Color) = (1,1,1,1)
        _Color4 ("Color", Color) = (1,1,1,1)
        _Divided ("Float", Float) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" }
        LOD 100
        Cull Back
        Blend SrcAlpha OneMinusSrcAlpha
   

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"
            
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _Color1;
            float4 _Color2;
            float4 _Color3;
            float4 _Color4;
            float _Divided;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float2 uvScaled = i.uv * _Divided;
                float2 cell = floor(uvScaled);
                float modX = fmod(cell.x, 2);
                float modY = fmod(cell.y, 2);
                fixed4 color;
                
                if (modX < 1.0 && modY < 1.0)
                    color = _Color1;
                else if (modX >= 1.0 && modY < 1.0)
                    color = _Color2;
                else if (modX < 1.0 && modY >= 1.0)
                    color = _Color3;
                else
                    color = _Color4;
                
                return color;
            }
            ENDCG
        }
    }
}
