Shader "Unlit/Floor"
{
    Properties
    {
        _TopTex ("TopTex", 2D) = "white" {}
        _BottomTex("BottomTex", 2D) = "black" {}
        _Color("Color", Color) = (1,1,1,1)
        _Percent("Percent", Range(0,1)) = 0.5
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

            sampler2D _TopTex;
            float4 _TopTex_ST;
            sampler2D _BottomTex;
            float4 _BottomTex_ST;
            float _Percent;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _TopTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 top = tex2D(_TopTex, i.uv);
                fixed4 bottom = tex2D(_BottomTex, i.uv);
                fixed4 col = lerp(bottom, top, _Percent);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
