﻿Shader "Custom/LowLowPoly" {
	Properties {
		_ColorFirst("Color First", Color) = (1, 1, 1, 1)
		_ColorSecond("Color Second", Color) = (1, 1, 1, 1)
		_ColorThird("Color Third", Color) = (1, 1, 1, 1)
		_Middle("Middle", Range(0.001, 0.999)) = 1

		//_MainTex("Albedo", 2D) = "white" {}
		_Shinyness("Shininess", Float) = 10
	}
	
	SubShader {
		Tags {"RenderType" = "Opaque" "Queue" = "Background" "IgnoreProjector" = "True"}
		Blend SrcAlpha OneMinusSrcAlpha

		Pass {
			Tags{"LightMode" = "ForwardBase"}

			CGPROGRAM

			#pragma target 5.0
			#pragma vertex VertexShaderFunc
			#pragma geometry GeometryShaderFunc
			#pragma fragment FragmentShaderFunc
			#pragma multi_compile_fwdbase
			#pragma multi_compile_fog

			#include "Lighting.cginc"
			#include "UnityCG.cginc"
			#include "AutoLight.cginc"

			uniform float4 _ColorFirst;
			uniform float4 _ColorSecond;
			uniform float4 _ColorThird;
			float _Middle;

			//uniform sampler2D _MainTex;
			uniform float _Shinyness;

			//Define the output properties
			struct VS_OUTPUT {
				float4 pos : SV_POSITION;
				float3 norm : NORMAL;
				float2 uv : TEXCOORD0;
				float3 vertex : TEXCOORD1;
				float3 vertexLighting : TEXCOORD2;
				half fogDepth: TEXCOORD3;
			};

			//Gemetry shader input/output properties
			struct GEO_INPUT {
				float4 pos : SV_POSITION;
				float3 norm : NORMAL;
				float2 uv : TEXCOORD0;
				float4 posWorld : TEXCOORD1;
				float3 vertexLighting : TEXCOORD2;
				LIGHTING_COORDS(3, 4)
					half fogDepth: TEXCOORD5;
			};

			VS_OUTPUT VertexShaderFunc(appdata_full v) {
				VS_OUTPUT OUT;
				OUT.pos = UnityObjectToClipPos(v.vertex);
				OUT.norm = v.normal;
				OUT.uv = v.texcoord;
				OUT.vertex = v.vertex;

				float3 vertexLighting = float3(0, 0, 0);
			
				#ifdef VERTEXLIGHT_ON
					for(int index = 0; index < 4; index++) {
						float3 normalDir = normalize(mul(float4(v.normal, 0.0), unity_WorldToObject).xyz);
						float3 lightPosition = float3(unity_4LightPosX0[index], unity_4LightPosY0[index], unity_4LightPosZ0[index]);
						float3 vertexToLightSource = lightPosition - mul(unity_ObjectToWorld, v.vertex);
						float3 lightDir = normalize(vertexToLightSource);
						float distanceSquared = dot(vertexToLightSource, vertexToLightSource);
						float attenuation = 1.0 / (1.0 + unity_4LightAtten0[index] * distanceSquared);

						vertexLighting += attenuation * unity_LightColor[index].rgb * _Color.rgb * saturate(dot(normalDir, lightDir));
					}
				#endif
				OUT.vertexLighting = vertexLighting;

				OUT.fogDepth = length(UnityObjectToClipPos(v.vertex));
	
				#if defined(FOG_LINEAR)
					OUT.fogDepth = clamp(OUT.fogDepth * unity_FogParams.z + unity_FogParams.w, 0.0, 1.0);
				#elif defined(FOG_EXP)
					OUT.fogDepth = exp2(-(OUT.fogDepth * unity_FogParams.y));
				#elif defined(FOG_EXP2)
					OUT.fogDepth = exp2(-(OUT.fogDepth * unity_FogParams.y)*(OUT.fogDepth * unity_FogParams.y));
				#else
					OUT.fogDepth = 1.0;
				#endif

				return OUT;
			}
	
			[maxvertexcount(3)]
			void GeometryShaderFunc(triangle VS_OUTPUT IN[3], inout TriangleStream<GEO_INPUT> triStream) {
				float3 v0 = IN[0].pos.xyz;
				float3 v1 = IN[1].pos.xyz;
				float3 v2 = IN[2].pos.xyz;

				GEO_INPUT OUT;
				OUT.norm = normalize(IN[0].norm + IN[1].norm + IN[2].norm);
				OUT.uv = (IN[0].uv + IN[1].uv + IN[2].uv) / 3;
				OUT.vertexLighting = (IN[0].vertexLighting + IN[1].vertexLighting + IN[2].vertexLighting) / 3;
				OUT.posWorld = mul(unity_ObjectToWorld, (IN[0].vertex + IN[1].vertex + IN[2].vertex) / 3);

				OUT.pos = IN[0].pos;
				OUT.fogDepth = IN[0].fogDepth;
				TRANSFER_VERTEX_TO_FRAGMENT(OUT);
				triStream.Append(OUT);

				OUT.pos = IN[1].pos;
				OUT.fogDepth = IN[1].fogDepth;
				TRANSFER_VERTEX_TO_FRAGMENT(OUT);
				triStream.Append(OUT);

				OUT.pos = IN[2].pos;
				OUT.fogDepth = IN[2].fogDepth;
				TRANSFER_VERTEX_TO_FRAGMENT(OUT);
				triStream.Append(OUT);
			}

			half4 FragmentShaderFunc(GEO_INPUT IN) : COLOR {
				/*float3 viewDir = normalize(_WorldSpaceCameraPos.xyz - IN.posWorld.xyz);
				float3 normalDir = normalize(mul(float4(IN.norm, 0.0), unity_WorldToObject).xyz);
				float3 vertexToLight = _WorldSpaceLightPos0.w == 0 ? _WorldSpaceLightPos0.xyz : _WorldSpaceLightPos0.xyz - IN.posWorld.xyz;
				float3 lightDir = normalize(vertexToLight);

				float3 ambientLight = UNITY_LIGHTMODEL_AMBIENT.rgb * _Color.rgb;
				UNITY_LIGHT_ATTENUATION(atten, IN, IN.posWorld);
				float3 diffuseReflection = atten * _LightColor0.rgb * _Color.rgb * saturate(dot(normalDir, lightDir));

				float3 specularReflection = float3(0.0, 0.0, 0.0);
				if(dot(normalDir, lightDir) >= 0.0) {
					specularReflection = atten * _LightColor0.rgb * pow(max(0.0, dot(reflect(-lightDir, normalDir), viewDir)), _Shinyness);
				}

				float4 colorTex = float4((IN.vertexLighting + ambientLight + diffuseReflection + specularReflection) * tex2D(_MainTex, IN.uv), 1);
				return lerp(unity_FogColor, colorTex, IN.fogDepth);*/

				fixed4 colour = lerp(_ColorThird, _ColorSecond, IN.uv.y / _Middle) * step(IN.uv.y, _Middle);
				colour += lerp(_ColorSecond, _ColorFirst, (IN.uv.y - _Middle) / (1 - _Middle)) * step(_Middle, IN.uv.y);
				colour.a = 1;

				return colour;
			}

			ENDCG
		}
	}

	Fallback "Standard"
}