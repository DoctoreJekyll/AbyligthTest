Shader "Custom/TestShader"
{
    Properties
    {
        _DiffuseTex ("Diffuse Texture", 2D) = "white" {}
        _MaskTex ("Mask Texture", 2D) = "white" {}
    }
     SubShader
    {
       Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _DiffuseTex;
            sampler2D _MaskTex;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            half4 frag (v2f i) : SV_Target
            {
                // Obtiene el color de la textura Diffuse y la máscara Mask
                half4 colDiffuse = tex2D(_DiffuseTex, i.uv);
                half4 colMask = tex2D(_MaskTex, i.uv);

                // Aplica el efecto deseado: invertir el color de Diffuse donde la máscara es negra
                half4 finalColor = lerp(colDiffuse, 1 - colDiffuse, colMask.r);

                return finalColor;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
