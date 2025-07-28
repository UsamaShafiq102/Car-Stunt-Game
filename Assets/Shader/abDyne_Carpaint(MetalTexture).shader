Shader "abDyne/Carpaint(MetalTexture)" {
	Properties {
		_Color ("Base Color (RGB)", Vector) = (1,1,1,1)
		_SpecColor ("Specular Color", Vector) = (0.5,0.5,0.5,1)
		_Shininess ("Shininess", Range(0.01, 5)) = 0.078125
		_ReflectColor ("Reflection Color", Vector) = (1,1,1,0.5)
		_MainTex ("Base (RGB) Texture", 2D) = "white" {}
		_FlakeAmt ("Flake Amount", Range(0, 1)) = 1
		_FlakeTex ("Flake Texture (A)", 2D) = "white" {}
		_Cube ("Reflection Cubemap", Cube) = "" {}
		_BumpMap ("Normalmap", 2D) = "bump" {}
		_RimColor ("Rim Color", Vector) = (0,0,0,1)
		_RimAmt ("Rim Amount", Range(10, 0)) = 5
		_RimPwr ("Rim Power", Range(0, 10)) = 2
		_FresAmt ("Fresnel Amount", Range(0, 3)) = 1
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType"="Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		sampler2D _MainTex;
		fixed4 _Color;
		struct Input
		{
			float2 uv_MainTex;
		};
		
		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
	Fallback "Reflective/Bumped Diffuse"
}