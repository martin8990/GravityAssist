//Shader "GenerationShader/TerrainShader" {
//	Properties{
//
//	}
//		SubShader{
//		Tags{ "RenderType" = "Opaque" }
//		CGPROGRAM
//
//	#pragma surface surf Lambert 
//
//
//	struct Input {
//		float2 uvmainTex;
//		float3 worldPos;
//		float gradient;
//	};
//
//		const static int nLayers = 6;
//		const static float epsilon = 1e-14;
//
//	sampler2D mainTex;
//
//	sampler2D t11;
//	sampler2D t12;
//	sampler2D t21;
//	sampler2D t22;
//	sampler2D t31;
//	sampler2D t32;
//	sampler2D t41;
//	sampler2D t42;
//	sampler2D t51;
//	sampler2D t52;
//	sampler2D t61;
//	sampler2D t62;
//
//	float4 colours[nLayers];
//	float colourStrenghts[nLayers];
//	float heights[nLayers];
//	float blends[nLayers];
// 
//	float scale;
//	float heightMult;
//	float maxHeight;
//
//	float4 pos;
//	float minGradientThreshold;
//
//
//
//	float inverseLerp(float a, float b, float value) {
//		return saturate((value - a) / (b - a));
//	}
//
//	float3 drawLayer(float3 worldPos, float3 blendAxes, float3 Albedo,int i,float heightPercent, sampler2D ttexture) {
//		
//		float drawStrength = inverseLerp(-blends[i] / 2 - epsilon, blends[i] / 2, heightPercent - heights[i]);
//		float3 baseColour = colours[i] * colourStrenghts[i];
//		float3 scaledWorldPos = worldPos / scale;
//		float3 xProjection = tex2D(ttexture, scaledWorldPos.yz) * blendAxes.x;
//		float3 yProjection = tex2D(ttexture, scaledWorldPos.xz) * blendAxes.y;
//		float3 zProjection = tex2D(ttexture, scaledWorldPos.xy) * blendAxes.z;
//		float3 textureColour = xProjection + yProjection + zProjection;
//		return Albedo * (1 - drawStrength) + (baseColour + textureColour) * drawStrength;
//	}
//
//
//
//		void surf(Input IN, inout SurfaceOutput o) {
//			//IN.gradient * gradientMult;// IN.worldPos.y / maxHeight / heightMult; //
//			float3 normal = tex2D(mainTex, IN.uvmainTex).rgb;
//	     	float3 blendAxes = abs(normal);
//			blendAxes /= blendAxes.x + blendAxes.y + blendAxes.z;
//			float heightPercent = inverseLerp(0, maxHeight, IN.worldPos.y);
//
//			float grad = sqrt(blendAxes.x * blendAxes.x + blendAxes.z * blendAxes.z);
//
//			float3 flatCol = float3(0, 0, 0);
//			float3 gradCol = float3(0, 0, 0);
//
//			
//				
//				flatCol = drawLayer(IN.worldPos,  blendAxes, flatCol, 0, heightPercent, t11);
//				flatCol = drawLayer(IN.worldPos,  blendAxes, flatCol, 1, heightPercent, t21);
//				flatCol = drawLayer(IN.worldPos,  blendAxes, flatCol, 2, heightPercent, t31);
//				flatCol = drawLayer(IN.worldPos,  blendAxes, flatCol, 3, heightPercent, t41);
//				flatCol = drawLayer(IN.worldPos, blendAxes, flatCol, 4, heightPercent, t51);
//
//				flatCol = drawLayer(IN.worldPos, blendAxes, flatCol, 5, heightPercent, t61);
//
//			
//				gradCol = drawLayer(IN.worldPos,  blendAxes, gradCol, 0, heightPercent, t12);
//				gradCol = drawLayer(IN.worldPos,  blendAxes, gradCol, 1, heightPercent, t22);
//				gradCol = drawLayer(IN.worldPos,  blendAxes, gradCol, 2, heightPercent, t32);
//				gradCol = drawLayer(IN.worldPos,  blendAxes, gradCol, 3, heightPercent, t42);
//				gradCol = drawLayer(IN.worldPos, blendAxes, gradCol, 4, heightPercent, t52);
//				gradCol = drawLayer(IN.worldPos, blendAxes, gradCol, 5, heightPercent, t62);
//
//				float gradt = inverseLerp(minGradientThreshold, maxGradientThreshold, grad);
//				o.Albedo = lerp(flatCol, gradCol, gradt);
//			
//		}
//		ENDCG
//	}
//		Fallback "Diffuse"
//}