Shader "Sprites/Default-Paper"
{
	Properties
	{
		[PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
		_Color ("Tint", Color) = (1,1,1,1)
		[MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
	}

	SubShader
	{
		Tags
		{
			"Queue"="Transparent"
			"IgnoreProjector"="True"
			"RenderType"="TransparentCutout"
			"PreviewType"="Plane"
			"CanUseSpriteAtlas"="True"
		}

		Cull Off
		//Lighting Off
		ZWrite On
		Fog { Mode Off }
		//Blend SrcAlpha OneMinusSrcAlpha

		Pass
		{
		CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			//#pragma multi_compile DUMMY PIXELSNAP_ON
			#pragma multi_compile_fog
			#include "UnityCG.cginc"

			struct appdata_t
			{
				float4 vertex   : POSITION;
				float4 color    : COLOR;
				float2 texcoord : TEXCOORD0;
			};

			struct Vertex2Fragment
			{
				float4 vertex   : SV_POSITION;
				fixed4 color    : COLOR;
				half2 texcoord  : TEXCOORD0;
				half fog : NUMBER;
				//float2 depth : TEXCOORD1;

				//Used to pass fog amount around number should be a free texcoord.
				UNITY_FOG_COORDS(1)
			};

			fixed4 _Color;

			Vertex2Fragment vert(appdata_t IN)
			{
				Vertex2Fragment OUT;
				OUT.vertex = mul(UNITY_MATRIX_MVP, IN.vertex);
				OUT.texcoord = IN.texcoord;
				OUT.color = IN.color * _Color;
				#ifdef PIXELSNAP_ON
				OUT.vertex = UnityPixelSnap (OUT.vertex);
				#endif

				float4 hpos = UnityObjectToClipPos(IN.vertex);
				hpos.xy /= hpos.w;
				OUT.fog = min(1, dot(hpos.xy, hpos.xy)*0.5);
				//UNITY_TRANSFER_DEPTH(OUT.depth);
				UNITY_TRANSFER_FOG(OUT, OUT.vertex);
				return OUT;
			}

			sampler2D _MainTex;

			fixed4 frag(Vertex2Fragment IN) : COLOR
			{
				//UNITY_OUTPUT_DEPTH(IN.depth * 2);
				fixed4 col = tex2D(_MainTex, IN.texcoord) * IN.color;
				float alpha = col.a;
				clip(alpha - 0.5);
				UNITY_APPLY_FOG(IN.fogCoord, col);
				return col; // *IN.depth.x;
			}
		ENDCG
		}
	}
}
