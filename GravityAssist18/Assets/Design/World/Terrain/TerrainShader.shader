Shader "GenerationShader/TerrainShader" {
	Properties{
		mainTex("mainTex", 2D) = "Red" {}
	BumpMap("Bumpmap", 2D) = "bump" {}
	pos("pos", Vector) = (1,1,0,0)
	
	}
		SubShader{
		Tags{ "RenderType" = "Opaque" }
		CGPROGRAM
#pragma surface surf Lambert vertex:vert

		struct Input {
		float2 uvmainTex;
		float2 uvBumpMap;
	};
	sampler2D mainTex;
	sampler2D BumpMap;
	float heightMult;
	float4 pos;
	void vert(inout appdata_full v) {
		float4 tex = tex2Dlod(mainTex,float4(v.texcoord.xy * pos.xy + pos.wz,0,0));
		v.vertex.y = tex.w /100.0;

	}

	void surf(Input IN, inout SurfaceOutput o) {
		o.Albedo = tex2D(mainTex, IN.uvmainTex ).rgb;
		o.Normal = UnpackNormal(tex2D(BumpMap, IN.uvBumpMap));
	}
	ENDCG
	}
		Fallback "Diffuse"
}