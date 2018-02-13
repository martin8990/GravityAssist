Shader "GenerationShader/TerrainShader2" {
	Properties{
		mainTex("mainTex", 2D) = "Red" {}
	testTexture("testTexture", 2D) = "Red" {}
	testScale("testScale", float) = 1 
	pos("pos", Vector) = (1,1,0,0)

	}
		SubShader{
		Tags{ "RenderType" = "Opaque" }
		CGPROGRAM

#pragma surface surf Lambert vertex:vert


		struct Input {
		float2 uvmainTex;
		float3 worldPos;
		float3 worldNormal;
		float gradient;
	};

	sampler2D mainTex;
	sampler2D testTexture;

	float heightMult;
	float maxHeight;
	float gradientMult;
	float testScale;
	float4 pos;

	void vert(inout appdata_full v, out Input o) {
		float4 tex = tex2Dlod(mainTex,float4(v.texcoord.xy * pos.xy + pos.wz,0,0));
		UNITY_INITIALIZE_OUTPUT(Input, o);
		o.gradient = tex.r;//grad/9.0;

	}

	void surf(Input IN, inout SurfaceOutput o) {
		//IN.gradient * gradientMult;// IN.worldPos.y / maxHeight / heightMult; //
		// 
		float3 scaledWorldPos = IN.worldPos / testScale;
		float3 blendAxes = abs(IN.worldNormal);
		float3 xProjection = tex2D(testTexture, scaledWorldPos.yz) * blendAxes.x;
		float3 yProjection = tex2D(testTexture, scaledWorldPos.xz) * blendAxes.y;
		float3 zProjection = tex2D(testTexture, scaledWorldPos.xy) * blendAxes.z;


		o.Albedo = blendAxes;
		// use gradient texture to change color 

	}
	ENDCG
	}
		Fallback "Diffuse"
}