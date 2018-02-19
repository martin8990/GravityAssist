Shader "GenerationShader/SplineSurface" {
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
	
	};

	sampler2D mainTex;
	sampler2D testTexture;

	float heightMult;
	float maxHeight;
	float4 pos;


	void vert(inout appdata_full v) {
		float4 tex = tex2Dlod(mainTex,float4(v.texcoord.xy,0,0));
		v.vertex.y = tex.y;

	}

	void surf(Input IN, inout SurfaceOutput o) {
		//IN.gradient * gradientMult;// IN.worldPos.y / maxHeight / heightMult; //
	

		o.Albedo = float3(1,1,1);
		// use gradient texture to change color 

	}
	ENDCG
	}
		Fallback "Diffuse"
}