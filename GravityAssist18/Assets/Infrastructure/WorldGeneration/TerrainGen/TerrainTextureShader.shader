Shader "GenerationShader/TerrainTextured" {
	Properties{


	}
		SubShader{
		Tags{ "RenderType" = "Opaque" }
		CGPROGRAM

	#include "noiseSimplex.cginc"
	#pragma surface surf Lambert 


	struct Input {
		float3 worldPos;
		float3 worldNormal;
	};

		const static int nLayers = 6;
		const static float epsilon = 1e-14;

		sampler2D t11;
		sampler2D t12;
		sampler2D t21;
		sampler2D t22;
		sampler2D t31;
		sampler2D t32;
		sampler2D t41;
		sampler2D t42;
		sampler2D t51;
		sampler2D t52;
		sampler2D t61;
		sampler2D t62;

	float heights[nLayers];
	float mingrad;
	float gblend;
	float hblends[nLayers];
	float scale;

	float maxHeight;
	float maxGrad;
	
	float inverseLerp(float a, float b, float value) {
		return saturate((value - a) / (b - a));
	}
	float GetSmoothStep(float xt,float mint, float maxt)
	{
		float val = min(max(xt, mint), maxt);
		float t = (val - mint) / (maxt - mint);
		return (cos(t * 3.14159265359 + 3.14159265359) + 1)/2;

	}

	float3 drawLayer(float height_t,float gradDS, float3 blendAxes, float3 scaledPos,
		float3 Albedo, int i, sampler2D flatTex, sampler2D gradTex) {
		float heightDS = inverseLerp(-hblends[i] / 2 - 1e-14, hblends[i] / 2, height_t - heights[i]);

		float3 xFlat = tex2D(flatTex, scaledPos.yz) * blendAxes.x;
		float3 yFlat = tex2D(flatTex, scaledPos.xz) * blendAxes.y;
		float3 zFlat = tex2D(flatTex, scaledPos.xy) * blendAxes.z;

		float3 xGrad = tex2D(gradTex, scaledPos.yz) * blendAxes.x;
		float3 yGrad = tex2D(gradTex, scaledPos.xz) * blendAxes.y;
		float3 zGrad = tex2D(gradTex, scaledPos.xy) * blendAxes.z;

		float3 Flat = xFlat + yFlat + zFlat;
		float3 Grad = xGrad + yGrad + zGrad;

		float3 myCol = Flat * (1.0-gradDS) + Grad * gradDS;
		return Albedo = Albedo * (1.0 - heightDS) + (myCol)* heightDS;

	}

			void surf(Input IN, inout SurfaceOutput o) {
			float3 blendAxes = abs(IN.worldNormal);
			blendAxes /= blendAxes.x + blendAxes.y + blendAxes.z;
			//float grad = sqrt(blendAxes.x * blendAxes.x + blendAxes.z * blendAxes.z);
			float grad = 1.0 - blendAxes.y;
			float height_t = inverseLerp(0, maxHeight, IN.worldPos.y);
			float grad_t = inverseLerp(0, maxGrad, grad);
			float gradDS = GetSmoothStep(grad_t, 0.4, 0.6);//inverseLerp(-gblend / 2 - 1e-14, gblend / 2, grad_t - mingrad);
			
			o.Albedo = drawLayer(height_t, gradDS, blendAxes, IN.worldPos/scale,o.Albedo, 0, t11, t12);
			o.Albedo = drawLayer(height_t, gradDS, blendAxes, IN.worldPos / scale, o.Albedo, 1, t21, t22);
			o.Albedo = drawLayer(height_t, gradDS, blendAxes, IN.worldPos / scale, o.Albedo, 2, t31, t32);
			o.Albedo = drawLayer(height_t, gradDS, blendAxes, IN.worldPos / scale, o.Albedo, 3, t41, t42);
			o.Albedo = drawLayer(height_t, gradDS, blendAxes, IN.worldPos / scale, o.Albedo, 4, t51, t52);
			o.Albedo = drawLayer(height_t, gradDS, blendAxes, IN.worldPos / scale, o.Albedo, 5, t61, t62);
			
		}
		ENDCG
	}
		Fallback "Diffuse"
}