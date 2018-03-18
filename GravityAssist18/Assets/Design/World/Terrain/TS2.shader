Shader "GenerationShader/TerrainShader2" {
	Properties{
	testTexture("testTexture", 2D) = "Red" {}
	testNormal("testNormal", 2D) = "Red" {}
	
	testScale("testScale", float) = 1 
	pos("pos", Vector) = (1,1,0,0)

	}
		SubShader{
		Tags{ "RenderType" = "Opaque" }
		CGPROGRAM

#pragma surface surf Lambert


		struct Input {
		float3 worldPos;
		float3 worldNormal;
		INTERNAL_DATA
	};


	sampler2D testTexture;
	sampler2D testNormal;


	float heightMult;
	float maxHeight;
	float gradientMult;
	float testScale;
	
	void surf(Input IN, inout SurfaceOutput o) {
		//IN.gradient * gradientMult;// IN.worldPos.y / maxHeight / heightMult; //
		// 
		float3 scaledWorldPos = IN.worldPos / testScale;
		float3 blendAxes = abs(IN.worldNormal);//WorldNormalVector(IN, float3(0, 0, 1)));
		blendAxes /= blendAxes.x + blendAxes.y + blendAxes.z;

		float3 xProjection = tex2D(testTexture, scaledWorldPos.yz) * blendAxes.x;
		float3 yProjection = tex2D(testTexture, scaledWorldPos.xz) * blendAxes.y;
		float3 zProjection = tex2D(testTexture, scaledWorldPos.xy) * blendAxes.z;

		float4 xN = tex2D(testNormal, scaledWorldPos.yz) * blendAxes.x;
		float4 yN = tex2D(testNormal, scaledWorldPos.xz) * blendAxes.y;
		float4 zN = tex2D(testNormal, scaledWorldPos.xy) * blendAxes.z;

		//o.Normal = UnpackNormal(xN + yN + zN);
		o.Albedo = xProjection + yProjection + zProjection;
		 //
		// use gradient texture to change color 

	}
	ENDCG
	}
		Fallback "Diffuse"
}