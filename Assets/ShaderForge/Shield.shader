// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:32719,y:32712,varname:node_2865,prsc:2|normal-5964-RGB,emission-9933-OUT,alpha-2498-OUT;n:type:ShaderForge.SFN_Tex2d,id:5964,x:32303,y:33160,ptovrint:True,ptlb:Normal Map,ptin:_BumpMap,varname:_BumpMap,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Slider,id:2498,x:31982,y:33049,ptovrint:False,ptlb:Opacity,ptin:_Opacity,varname:_Opacity,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Tex2d,id:9156,x:32118,y:32224,ptovrint:False,ptlb:node_9156,ptin:_node_9156,varname:_node_9156,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:41971ed4452d7e44ba32faa6b630fde4,ntxv:2,isnm:False|UVIN-8321-UVOUT;n:type:ShaderForge.SFN_Color,id:7191,x:31941,y:32605,ptovrint:False,ptlb:Lines,ptin:_Lines,varname:_Lines,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Multiply,id:2473,x:32492,y:32532,varname:node_2473,prsc:2|A-9156-RGB,B-7191-RGB,C-8223-RGB,D-9156-A;n:type:ShaderForge.SFN_TexCoord,id:6405,x:31591,y:32227,varname:node_6405,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Fresnel,id:4918,x:32583,y:32194,varname:node_4918,prsc:2|EXP-7619-OUT;n:type:ShaderForge.SFN_OneMinus,id:2585,x:32739,y:32194,varname:node_2585,prsc:2|IN-4918-OUT;n:type:ShaderForge.SFN_Add,id:7621,x:33289,y:32482,varname:node_7621,prsc:2|A-7514-OUT,B-2473-OUT,C-1568-OUT;n:type:ShaderForge.SFN_Panner,id:8321,x:31892,y:32224,varname:node_8321,prsc:2,spu:1,spv:1|UVIN-6405-UVOUT,DIST-8847-OUT;n:type:ShaderForge.SFN_Vector1,id:5048,x:31226,y:32423,varname:node_5048,prsc:2,v1:0.1;n:type:ShaderForge.SFN_Time,id:8528,x:31226,y:32245,varname:node_8528,prsc:2;n:type:ShaderForge.SFN_Multiply,id:8847,x:31564,y:32404,varname:node_8847,prsc:2|A-8528-T,B-5048-OUT;n:type:ShaderForge.SFN_Multiply,id:5237,x:31964,y:31859,varname:node_5237,prsc:2|A-4115-OUT,B-8151-T;n:type:ShaderForge.SFN_Time,id:8151,x:31651,y:32011,varname:node_8151,prsc:2;n:type:ShaderForge.SFN_Vector1,id:4115,x:31525,y:31865,varname:node_4115,prsc:2,v1:0.3;n:type:ShaderForge.SFN_TexCoord,id:9182,x:31902,y:31559,varname:node_9182,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:4097,x:32343,y:31644,varname:node_4097,prsc:2,spu:3,spv:1|UVIN-9182-UVOUT,DIST-5237-OUT;n:type:ShaderForge.SFN_Tex2d,id:8223,x:32316,y:31883,ptovrint:False,ptlb:node_9156_copy,ptin:_node_9156_copy,varname:_node_9156_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:5d1fed21765acf24bad9757069b77f08,ntxv:2,isnm:False|UVIN-4097-UVOUT;n:type:ShaderForge.SFN_Color,id:7072,x:32583,y:32341,ptovrint:False,ptlb:fresnel 1,ptin:_fresnel1,varname:_fresnel1,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5588235,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Multiply,id:7514,x:32901,y:32194,varname:node_7514,prsc:2|A-2585-OUT,B-7072-RGB;n:type:ShaderForge.SFN_Fresnel,id:3306,x:31516,y:32827,varname:node_3306,prsc:2|EXP-7577-OUT;n:type:ShaderForge.SFN_Color,id:3720,x:31290,y:32811,ptovrint:False,ptlb:Fresnel2,ptin:_Fresnel2,varname:_Fresnel2,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:1568,x:31716,y:32868,varname:node_1568,prsc:2|A-3306-OUT,B-3720-RGB;n:type:ShaderForge.SFN_Vector1,id:7577,x:31290,y:33007,varname:node_7577,prsc:2,v1:0.8;n:type:ShaderForge.SFN_Multiply,id:4888,x:31604,y:33178,varname:node_4888,prsc:2|A-4118-OUT,B-2130-RGB;n:type:ShaderForge.SFN_Fresnel,id:4118,x:31404,y:33137,varname:node_4118,prsc:2|EXP-5393-OUT;n:type:ShaderForge.SFN_Color,id:2130,x:31178,y:33121,ptovrint:False,ptlb:Fresnel3,ptin:_Fresnel3,varname:_Fresnel3,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Vector1,id:5393,x:31178,y:33317,varname:node_5393,prsc:2,v1:0.6;n:type:ShaderForge.SFN_Add,id:9933,x:33010,y:32590,varname:node_9933,prsc:2|A-7621-OUT,B-4888-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7619,x:33102,y:32054,ptovrint:False,ptlb:node_7619,ptin:_node_7619,varname:_node_7619,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;proporder:5964-2498-9156-7191-8223-7072-3720-2130-7619;pass:END;sub:END;*/

Shader "Shader Forge/Shield" {
    Properties {
        _BumpMap ("Normal Map", 2D) = "bump" {}
        _Opacity ("Opacity", Range(0, 1)) = 1
        _node_9156 ("node_9156", 2D) = "black" {}
        _Lines ("Lines", Color) = (1,0,0,1)
        _node_9156_copy ("node_9156_copy", 2D) = "black" {}
        _fresnel1 ("fresnel 1", Color) = (0.5588235,0,0,1)
        _Fresnel2 ("Fresnel2", Color) = (0.5,0.5,0.5,1)
        _Fresnel3 ("Fresnel3", Color) = (0.5,0.5,0.5,1)
        _node_7619 ("node_7619", Float ) = 0.5
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _BumpMap; uniform float4 _BumpMap_ST;
            uniform float _Opacity;
            uniform sampler2D _node_9156; uniform float4 _node_9156_ST;
            uniform float4 _Lines;
            uniform sampler2D _node_9156_copy; uniform float4 _node_9156_copy_ST;
            uniform float4 _fresnel1;
            uniform float4 _Fresnel2;
            uniform float4 _Fresnel3;
            uniform float _node_7619;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _BumpMap_var = UnpackNormal(tex2D(_BumpMap,TRANSFORM_TEX(i.uv0, _BumpMap)));
                float3 normalLocal = _BumpMap_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
////// Lighting:
////// Emissive:
                float4 node_8528 = _Time;
                float2 node_8321 = (i.uv0+(node_8528.g*0.1)*float2(1,1));
                float4 _node_9156_var = tex2D(_node_9156,TRANSFORM_TEX(node_8321, _node_9156));
                float4 node_8151 = _Time;
                float2 node_4097 = (i.uv0+(0.3*node_8151.g)*float2(3,1));
                float4 _node_9156_copy_var = tex2D(_node_9156_copy,TRANSFORM_TEX(node_4097, _node_9156_copy));
                float3 emissive = ((((1.0 - pow(1.0-max(0,dot(normalDirection, viewDirection)),_node_7619))*_fresnel1.rgb)+(_node_9156_var.rgb*_Lines.rgb*_node_9156_copy_var.rgb*_node_9156_var.a)+(pow(1.0-max(0,dot(normalDirection, viewDirection)),0.8)*_Fresnel2.rgb))+(pow(1.0-max(0,dot(normalDirection, viewDirection)),0.6)*_Fresnel3.rgb));
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,_Opacity);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "Meta"
            Tags {
                "LightMode"="Meta"
            }
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_META 1
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _node_9156; uniform float4 _node_9156_ST;
            uniform float4 _Lines;
            uniform sampler2D _node_9156_copy; uniform float4 _node_9156_copy_ST;
            uniform float4 _fresnel1;
            uniform float4 _Fresnel2;
            uniform float4 _Fresnel3;
            uniform float _node_7619;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i) : SV_Target {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                float4 node_8528 = _Time;
                float2 node_8321 = (i.uv0+(node_8528.g*0.1)*float2(1,1));
                float4 _node_9156_var = tex2D(_node_9156,TRANSFORM_TEX(node_8321, _node_9156));
                float4 node_8151 = _Time;
                float2 node_4097 = (i.uv0+(0.3*node_8151.g)*float2(3,1));
                float4 _node_9156_copy_var = tex2D(_node_9156_copy,TRANSFORM_TEX(node_4097, _node_9156_copy));
                o.Emission = ((((1.0 - pow(1.0-max(0,dot(normalDirection, viewDirection)),_node_7619))*_fresnel1.rgb)+(_node_9156_var.rgb*_Lines.rgb*_node_9156_copy_var.rgb*_node_9156_var.a)+(pow(1.0-max(0,dot(normalDirection, viewDirection)),0.8)*_Fresnel2.rgb))+(pow(1.0-max(0,dot(normalDirection, viewDirection)),0.6)*_Fresnel3.rgb));
                
                float3 diffColor = float3(0,0,0);
                o.Albedo = diffColor;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
