Shader "Unlit/KirakiraParticle"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _EmissionRate("EmissionRate",Float) = 0.5
    }
    SubShader
    {
        Tags {"Queue"="AlphaTest" "RenderType"="TransparentCutout"}
		LOD 100
		Cull Off

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
                float3 normal : NORMAL;
                float4 color : COLOR;
                float4 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float3 normal : NORMAL;
                float4 color : COLOR;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _EmissionRate;
            
            float random (fixed2 p) { 
                return frac(sin(dot(p, fixed2(12.9898,78.233))) * 43758.5453);
            }
            
            float2x2 genRot(float t){
                return float2x2(cos(t),-sin(t),sin(t),cos(t));
            }
            
            fixed2 random2(fixed2 st){
                st = fixed2( dot(st,fixed2(127.1,311.7)),
                           dot(st,fixed2(269.5,183.3)) );
                return -1.0 + 2.0*frac(sin(st)*43758.5453123);
            }
            
            float perlinNoise(fixed2 st) {
                fixed2 p = floor(st);
                fixed2 f = frac(st);
                fixed2 u = f*f*(3.0-2.0*f);

                float v00 = random2(p+fixed2(0,0));
                float v10 = random2(p+fixed2(1,0));
                float v01 = random2(p+fixed2(0,1));
                float v11 = random2(p+fixed2(1,1));

                return lerp( lerp( dot( v00, f - fixed2(0,0) ), dot( v10, f - fixed2(1,0) ), u.x ),
                         lerp( dot( v01, f - fixed2(0,1) ), dot( v11, f - fixed2(1,1) ), u.x ), 
                         u.y)+0.5f;
            }

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv.xy = TRANSFORM_TEX(v.uv.xy, _MainTex);
                o.uv.zw = v.uv.zw;
                o.normal = v.normal;
                o.color = v.color;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
            
                float2 uv = i.uv.xy - 0.5;
                float rnd = perlinNoise(uv * 5.0);
                uv = mul(uv,genRot((i.uv.w - 0.5) * 3.1415 * 0.1));
                
                float t = saturate(frac(_Time.y + i.uv.z) * 2.0);
                float r = (1. - (1.- t) * (1. - t)) * 0.5;
                float2 st = uv + (float2(perlinNoise(float2(uv.x,uv.x) * 3.0),perlinNoise(float2(uv.y,uv.y) * 3.0)) - 0.5) * 0.1;
                r += rnd * 0.05;
                float a = 0.1 + 0.875 * (t * 2.0) * (t * 2.0);
                float b = 0.1 * max(0.,1. - t * 1.5) * max(0.,1. - t * 1.5);
                float c = abs(st.y) + (b/a) * abs(st.x) - b;
                float d = abs(st.x) + (b/a) * abs(st.y) - b;
                // sample the texture
                float rwidth = 1.6 * max(0.0,(0.5 - t)) * max(0.0,(0.5 - t)) * max(0.0,(0.5 - t));
                fixed4 col = (r - rwidth) * (r - rwidth) < dot(uv,uv) && dot(uv,uv) < r * r ? fixed4(1.0,1.0,1.0,1.0) : fixed4(0.0,0.0,0.0,0.0);
                col = min(c,d) < 0.0 ? 1.0 : col;
                clip(col.a - 0.1);
                
                return col * i.color * (1. + _EmissionRate);
            }
            ENDCG
        }
    }
}
