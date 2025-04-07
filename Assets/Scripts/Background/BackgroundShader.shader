Shader "Unlit/Ba"
{
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _WaveSpeed ("Wave Speed", Float) = 0.2
        _WaveStrength ("Wave Strength", Float) = 0.005  // Reduce this even more for subtle effect
        _WaveFrequency ("Wave Frequency", Float) = 0.5  // Increase frequency for more tight waves
        _DarknessFactor ("Darkness Factor", Float) = 0.75  // Darkness multiplier (0.0 to 1.0)
       
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            // Texture sampler
            sampler2D _MainTex;
            float _WaveSpeed;
            float _WaveStrength;
            float _WaveFrequency;
            float _DarknessFactor; // Add a darkness factor for control

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;

                // Apply wave distortion to the UV coordinates in the vertical direction (y-axis)
                // Adjust the wave calculation for more subtlety
                float wave = sin(o.uv.y * _WaveFrequency + _Time.y * _WaveSpeed) * 0.35f; // Modify the y-coordinate
                o.uv.x += (wave * _WaveStrength) * 0.25f;
                o.uv.y += (wave * _WaveStrength) * 0.25f;

                return o;
            }

            half4 frag(v2f i) : SV_Target
            {
                // Sample the texture at the distorted UV
                half4 col = tex2D(_MainTex, i.uv);

                // Darken the color by multiplying with a darkness factor
                col.rgb *= _DarknessFactor; // Multiply the color by the darkness factor
                return col;
            }

            ENDCG
        }
    }
    FallBack "Diffuse"
}
