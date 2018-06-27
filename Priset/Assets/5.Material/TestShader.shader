Shader "Custom/NewSurfaceShader" 
{
	Properties 
	{
		_MainTex ("Base (RGB) Trans. (Alpha)", 2D) = "white" {}
	}

	SubShader
	{
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			struct v2f
			{
				float2 uv: TEXCOORD0;
				float4 pos: SV_POSITION;
			};

			float4x4 _TextureMatarial;

			v2f vert(float4 pos : POSITION, float2 uv : TEXCOORD0)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(pos);
				//uv.x = 1.0 - uv.x;
				//uv.y = 1.0 - uv.y;
				o.uv = mul(_TextureMatarial,float4(uv,0 ,1)).xy;

				return o;
			}

			sampler2D _MainTex;
			fixed4 frag (v2f i) : SV_Target
			{
				i.uv.x =1-(i.uv.x/2);
				i.uv.y =1-(i.uv.y/2);
				return tex2D(_MainTex, i.uv);
			}
			ENDCG
		}
	}
	FallBack "Diffuse"
}
