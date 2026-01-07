Shader "Unlit/ImageColor"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _RampTex ("RampTex", 2D) = "white" {}
        _HueShift ("Hue Shift", Range(0, 1)) = 0.0
        _Saturation ("Saturation", Range(0, 2)) = 1.0
        _Value ("Value", Range(0, 2)) = 1.0
        // _lineWidth("lineWidth",Range(0,3)) = 1
        // _lineColor("lineColor",Color)=(1,1,1,1)
    }
    SubShader
    {
        Tags { "Queue" = "Transparent"}
        Blend SrcAlpha OneMinusSrcAlpha
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag   

            #include "UnityCG.cginc"

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

            sampler2D _MainTex;
            sampler2D _RampTex;
            float4 _MainTex_ST;
            float4 _RampTex_ST;
            float _HueShift;
            float _Saturation;
            float _Value;

            float _Intensity;
            // RGB 转 HSV
            float3 rgb_to_hsv(float3 c)
            {
                float4 K = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
                float4 p = lerp(float4(c.bg, K.wz), float4(c.gb, K.xy), step(c.b, c.g));
                float4 q = lerp(float4(p.xyw, c.r), float4(c.r, p.yzx), step(p.x, c.r));
                
                float d = q.x - min(q.w, q.y);
                float e = 1.0e-10;
                return float3(abs(q.z + (q.w - q.y) / (6.0 * d + e)), d / (q.x + e), q.x);
            }
            
            // HSV 转 RGB
            float3 hsv_to_rgb(float3 c)
            {
                float4 K = float4(1.0, 2.0 / 3.0, 1.0 / 3.0, 3.0);
                float3 p = abs(frac(c.xxx + K.xyz) * 6.0 - K.www);
                return c.z * lerp(K.xxx, saturate(p - K.xxx), c.y);
            }

            v2f vert (appdata v)
            {
                v2f o;
                //v.vertex.xyz *= _lineWidth;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);

                // 转换为 HSV
                float3 hsv = rgb_to_hsv(col.rgb);
                
                // 应用色相偏移
                hsv.x = frac(hsv.x + _HueShift);
                
                // 调整饱和度和明度
                hsv.y *= _Saturation;
                hsv.z *= _Value;
                
                // 转换回 RGB
                float3 shiftedColor = hsv_to_rgb(hsv);

                
                return fixed4(shiftedColor,col.a);
            }
            ENDCG
        }
    }
}
