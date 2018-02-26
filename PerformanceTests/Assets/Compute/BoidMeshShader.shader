Shader "Custom/BoidMeshShader" {
	Properties {
	}
	SubShader {
      Pass
    {
      Blend SrcAlpha OneMinusSrcAlpha
      Cull Off

        CGPROGRAM 
        #pragma target 5.0

        #pragma vertex vert
        #pragma fragment frag

        #include "UnityCG.cginc"

        struct Boid {
          float2 pos;
          float2 dir;
          float4 col;
        };

        // The buffer containing the points we want to draw.
        StructuredBuffer<Boid> BoidBuffer;
        float4 InvBounds;
        float4 Bounds;
        float4x4 My_Object2World;

        // A simple input struct for our pixel shader step containing a
        // position.
        struct ps_input {
          float4 pos : SV_POSITION;
          float4 col : COLOR0;
        };

        // Our vertex function simply fetches a point from the buffer
        // corresponding to the vertex index
        // which we transform with the view-projection matrix before passing to
        // the pixel program.
        ps_input vert(uint id : SV_VertexID, uint inst : SV_InstanceID) {
          ps_input o;

         

		  float3 worldPos = float3(0, 0, 0);
            

          //float3 worldDir = normalize(float3(b.dir.x, b.dir.y, 0)) * 0.01f;
        
          [branch] switch (id) {
          case 0: worldPos = float3(0 ,0,0); break;
          case 1: worldPos = float3(1 , 0, 0); break;
          case 2: worldPos = float3(0 , 1, 0); break;
		  case 3: worldPos = float3(1, 1, 0); break;
		  case 4: worldPos = float3(1, 0, 0); break;
		  case 5: worldPos = float3(0, 1, 0); break;

		  };
		  worldPos = worldPos + float3(1, 0, 0)* inst;
          o.pos = mul(UNITY_MATRIX_VP, mul(My_Object2World, float4(worldPos, 1.0f)));
          o.col = float4(1,0,0,1);
          return o;
        }

        // Pixel function returns a solid color for each point.
        float4 frag(ps_input i) : COLOR{ return i.col; }

        ENDCG
      }
        }

        FallBack Off
}
