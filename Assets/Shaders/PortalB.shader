Shader "Custom/PortalB"
{
    Properties{
        _MainTex("Texture", 2D) = "white" {}

    }
        SubShader{
          Tags { "RenderType" = "Opaque" }
          CGPROGRAM

          #pragma surface surf Unlit 

          //Unlit as no lighting occurs on the surface
          half4 LightingUnlit(SurfaceOutput s, half3 lightDir, half atten) {
              half4 c; //This is the return-object
              c.rgb = s.Albedo * 0.5f; //0.5f seemed a good value; without multiplication the surface was overly bright
              c.a = s.Alpha;
              return c;
         }

          struct Input {
              float4 screenPos;
          };
          sampler2D _MainTex;

          
          void surf(Input IN, inout SurfaceOutput o) {
              //This surface shader acts as if the surface was a mask on the texture to decide which parts are rendered on screen
              o.Albedo = tex2D(_MainTex, IN.screenPos.xy / IN.screenPos.w).rgb;
          }

          ENDCG
    }
        Fallback "Diffuse"
}