Shader "Unlit/SoftParticle"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color("Color", Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags 
        { 
            "RenderType"="Transparent" 
            "Queue" = "Transparent"
        }
        LOD 100

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha   
            Cull Off 
            Lighting Off 
            ZWrite On
            ZTest On
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            // #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float4 color : COLOR;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
                float4 texcoord : TEXCOORD1;
                float4 colors : TEXCOORD2;
                UNITY_FOG_COORDS(1)
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            sampler2D _CameraDepthTexture;
            float4 _Color;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.texcoord = v.vertex;
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.colors = v.color;
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv) ;
                float4 ClipPos = UnityObjectToClipPos( i.texcoord.xyz );
                float4 ScreenPosParam = ComputeScreenPos( ClipPos );
            #if UNITY_REVERSED_Z
                ScreenPosParam.z = UNITY_Z_0_FAR_FROM_CLIPSPACE( ScreenPosParam.z );
            #endif
                float EyeDepth = LinearEyeDepth( UNITY_SAMPLE_DEPTH( tex2Dproj( _CameraDepthTexture, UNITY_PROJ_COORD( ScreenPosParam ) ) ) );
                
               float a = saturate(EyeDepth - ScreenPosParam.z);
                // apply fog
                // UNITY_APPLY_FOG(i.fogCoord, col);
                return a;
                //return float4(col.rgb * _Color.rgb,col.a * a);
            }
            ENDCG
        }
    }
}
