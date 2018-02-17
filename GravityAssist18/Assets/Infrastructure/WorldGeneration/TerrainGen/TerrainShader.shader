Shader "GenerationShader/TerrainColor" {
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

		const static int nLayers = 5;
		const static float epsilon = 1e-14;

	float4 colours[nLayers * 4];
	float heights[nLayers ];
	float mingrad;
	float gblend;
	float hblends[nLayers];
	float freqs[nLayers];

	float seeds[nLayers];

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

		void surf(Input IN, inout SurfaceOutput o) {
			float3 blendAxes = abs(IN.worldNormal);
			blendAxes /= blendAxes.x + blendAxes.y + blendAxes.z;
			//float grad = sqrt(blendAxes.x * blendAxes.x + blendAxes.z * blendAxes.z);
			float grad = 1.0 - blendAxes.y;
			float height_t = inverseLerp(0, maxHeight, IN.worldPos.y);
			float grad_t = inverseLerp(0, maxGrad, grad);
			float gradDS = GetSmoothStep(grad_t, 0.4, 0.6);//inverseLerp(-gblend / 2 - 1e-14, gblend / 2, grad_t - mingrad);
			for (int i = 0; i < nLayers; i++)
			{
				float noiseDS = (snoise(IN.worldPos* freqs[i] + seeds[i])+0.5)/4.0;
				
				float heightDS = inverseLerp(-hblends[i] / 2 - 1e-14, hblends[i]/ 2, height_t - heights[i]);
				
				
				float DS1 =(1.0 - gradDS) * noiseDS;
				float DS2 =(1.0 - gradDS) * (1-noiseDS);
				float DS3 =(gradDS) * noiseDS;
				float DS4 =(gradDS) * (1 - noiseDS);
				
				float4 myCol = DS1 * colours[i * 4]
						+ DS2 * colours[i * 4 + 1]
						+ DS3 * colours[i * 4 + 2]
						+ DS4 * colours[i * 4 + 3];

				o.Albedo = o.Albedo * (1.0 - heightDS) + (myCol) * heightDS;
	
		
			}
			
			
		
			
		}
		ENDCG
	}
		Fallback "Diffuse"
}