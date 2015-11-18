/*SF_DATA;ver:0.34;sub:START;pass:START;ps:flbk:,lico:0,lgpr:1,nrmq:1,limd:0,uamb:True,mssp:True,lmpd:False,lprd:False,enco:False,frtr:True,vitr:True,dbil:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,blpr:1,bsrc:3,bdst:7,culm:0,dpts:2,wrdp:False,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:1,x:31324,y:33026|diff-956-OUT,emission-1076-OUT,lwrap-998-OUT,alpha-1293-OUT,disp-13-OUT,tess-8-OUT;n:type:ShaderForge.SFN_TexCoord,id:5,x:33600,y:32873,uv:0;n:type:ShaderForge.SFN_Multiply,id:6,x:33401,y:32940|A-5-UVOUT,B-7-OUT;n:type:ShaderForge.SFN_Vector1,id:7,x:33600,y:33022,v1:1;n:type:ShaderForge.SFN_Vector1,id:8,x:32138,y:33455,v1:1;n:type:ShaderForge.SFN_Multiply,id:13,x:32266,y:33324|A-14-OUT,B-26-OUT,C-152-RGB,D-1065-OUT;n:type:ShaderForge.SFN_NormalVector,id:14,x:33058,y:33298,pt:False;n:type:ShaderForge.SFN_Vector1,id:15,x:33058,y:33179,v1:1;n:type:ShaderForge.SFN_Slider,id:16,x:33363,y:33576,ptlb:Depth,ptin:_Depth,min:0,cur:0.25,max:0.25;n:type:ShaderForge.SFN_Multiply,id:26,x:33173,y:33541|A-27-OUT,B-16-OUT;n:type:ShaderForge.SFN_Vector1,id:27,x:33363,y:33485,v1:-1;n:type:ShaderForge.SFN_Tex2d,id:152,x:32945,y:33128,ptlb:Displacement (R),ptin:_DisplacementR,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-161-UVOUT,MIP-15-OUT;n:type:ShaderForge.SFN_Panner,id:161,x:33214,y:33135,spu:0.01,spv:-0.01|UVIN-6-OUT;n:type:ShaderForge.SFN_Vector3,id:956,x:32772,y:32782,v1:0.5294118,v2:0,v3:0.4929007;n:type:ShaderForge.SFN_Posterize,id:998,x:32406,y:33114|IN-152-RGB,STPS-1000-OUT;n:type:ShaderForge.SFN_Vector1,id:1000,x:32635,y:33179,v1:2;n:type:ShaderForge.SFN_Time,id:1064,x:32880,y:33495;n:type:ShaderForge.SFN_Sin,id:1065,x:32685,y:33485|IN-1064-T;n:type:ShaderForge.SFN_ConstantClamp,id:1076,x:32126,y:33121,min:0,max:0.7|IN-1089-OUT;n:type:ShaderForge.SFN_Lerp,id:1089,x:32243,y:32948|A-956-OUT,B-1090-OUT,T-998-OUT;n:type:ShaderForge.SFN_Vector3,id:1090,x:32772,y:32888,v1:0.4690671,v2:0,v3:0.5441177;n:type:ShaderForge.SFN_TexCoord,id:1224,x:32443,y:32730,uv:0;n:type:ShaderForge.SFN_ComponentMask,id:1225,x:32189,y:32730,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-1224-V;n:type:ShaderForge.SFN_Add,id:1291,x:31952,y:32756|A-1225-OUT,B-1292-OUT;n:type:ShaderForge.SFN_Vector1,id:1292,x:32040,y:32898,v1:0.5;n:type:ShaderForge.SFN_Power,id:1293,x:31751,y:32737|VAL-1291-OUT,EXP-1294-OUT;n:type:ShaderForge.SFN_Vector1,id:1294,x:31890,y:32864,v1:15;proporder:152-16;pass:END;sub:END;*/

Shader "Custom/Gaz" {
    Properties {
        _DisplacementR ("Displacement (R)", 2D) = "white" {}
        _Depth ("Depth", Range(0, 0.25)) = 0.25
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "ForwardBase"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma hull hull
            #pragma domain domain
            #pragma vertex tessvert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers opengl gles xbox360 ps3 flash 
            #pragma target 5.0
            #pragma glsl
            uniform float4 _TimeEditor;
            uniform float _Depth;
            uniform sampler2D _DisplacementR; uniform float4 _DisplacementR_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(float4(v.normal,0), _World2Object).xyz;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                return o;
            }
            #ifdef UNITY_CAN_COMPILE_TESSELLATION
                struct TessVertex {
                    float4 vertex : INTERNALTESSPOS;
                    float3 normal : NORMAL;
                    float4 tangent : TANGENT;
                    float2 texcoord0 : TEXCOORD0;
                };
                struct OutputPatchConstant {
                    float edge[3]         : SV_TessFactor;
                    float inside          : SV_InsideTessFactor;
                    float3 vTangent[4]    : TANGENT;
                    float2 vUV[4]         : TEXCOORD;
                    float3 vTanUCorner[4] : TANUCORNER;
                    float3 vTanVCorner[4] : TANVCORNER;
                    float4 vCWts          : TANWEIGHTS;
                };
                TessVertex tessvert (VertexInput v) {
                    TessVertex o;
                    o.vertex = v.vertex;
                    o.normal = v.normal;
                    o.tangent = v.tangent;
                    o.texcoord0 = v.texcoord0;
                    return o;
                }
                void displacement (inout VertexInput v){
                    float4 node_1304 = _Time + _TimeEditor;
                    float2 node_161 = ((v.texcoord0.rg*1.0)+node_1304.g*float2(0.01,-0.01));
                    float4 node_152 = tex2Dlod(_DisplacementR,float4(TRANSFORM_TEX(node_161, _DisplacementR),0.0,1.0));
                    float4 node_1064 = _Time + _TimeEditor;
                    v.vertex.xyz +=  (v.normal*((-1.0)*_Depth)*node_152.rgb*sin(node_1064.g));
                }
                float Tessellation(TessVertex v){
                    return 1.0;
                }
                OutputPatchConstant hullconst (InputPatch<TessVertex,3> v) {
                    OutputPatchConstant o;
                    float ts = Tessellation( v[0] );
                    o.edge[0] = ts;
                    o.edge[1] = ts;
                    o.edge[2] = ts;
                    o.inside = ts;
                    return o;
                }
                [domain("tri")]
                [partitioning("fractional_odd")]
                [outputtopology("triangle_cw")]
                [patchconstantfunc("hullconst")]
                [outputcontrolpoints(3)]
                TessVertex hull (InputPatch<TessVertex,3> v, uint id : SV_OutputControlPointID) {
                    return v[id];
                }
                [domain("tri")]
                VertexOutput domain (OutputPatchConstant tessFactors, const OutputPatch<TessVertex,3> vi, float3 bary : SV_DomainLocation) {
                    VertexInput v;
                    v.vertex = vi[0].vertex*bary.x + vi[1].vertex*bary.y + vi[2].vertex*bary.z;
                    v.normal = vi[0].normal*bary.x + vi[1].normal*bary.y + vi[2].normal*bary.z;
                    v.tangent = vi[0].tangent*bary.x + vi[1].tangent*bary.y + vi[2].tangent*bary.z;
                    v.texcoord0 = vi[0].texcoord0*bary.x + vi[1].texcoord0*bary.y + vi[2].texcoord0*bary.z;
                    displacement(v);
                    VertexOutput o = vert(v);
                    return o;
                }
            #endif
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
/////// Normals:
                float3 normalDirection =  i.normalDir;
////// Lighting:
////// Emissive:
                float3 node_956 = float3(0.5294118,0,0.4929007);
                float4 node_1304 = _Time + _TimeEditor;
                float2 node_161 = ((i.uv0.rg*1.0)+node_1304.g*float2(0.01,-0.01));
                float4 node_152 = tex2Dlod(_DisplacementR,float4(TRANSFORM_TEX(node_161, _DisplacementR),0.0,1.0));
                float node_1000 = 2.0;
                float3 node_998 = floor(node_152.rgb * node_1000) / (node_1000 - 1);
                float3 emissive = clamp(lerp(node_956,float3(0.4690671,0,0.5441177),node_998),0,0.7);
                float3 finalColor = emissive;
/// Final Color:
                return fixed4(finalColor,pow((i.uv0.g.r+0.5),15.0));
            }
            ENDCG
        }
        Pass {
            Name "ShadowCollector"
            Tags {
                "LightMode"="ShadowCollector"
            }
            
            Fog {Mode Off}
            CGPROGRAM
            #pragma hull hull
            #pragma domain domain
            #pragma vertex tessvert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCOLLECTOR
            #define SHADOW_COLLECTOR_PASS
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcollector
            #pragma exclude_renderers opengl gles xbox360 ps3 flash 
            #pragma target 5.0
            #pragma glsl
            uniform float4 _TimeEditor;
            uniform float _Depth;
            uniform sampler2D _DisplacementR; uniform float4 _DisplacementR_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_COLLECTOR;
                float2 uv0 : TEXCOORD5;
                float3 normalDir : TEXCOORD6;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(float4(v.normal,0), _World2Object).xyz;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_SHADOW_COLLECTOR(o)
                return o;
            }
            #ifdef UNITY_CAN_COMPILE_TESSELLATION
                struct TessVertex {
                    float4 vertex : INTERNALTESSPOS;
                    float3 normal : NORMAL;
                    float4 tangent : TANGENT;
                    float2 texcoord0 : TEXCOORD0;
                };
                struct OutputPatchConstant {
                    float edge[3]         : SV_TessFactor;
                    float inside          : SV_InsideTessFactor;
                    float3 vTangent[4]    : TANGENT;
                    float2 vUV[4]         : TEXCOORD;
                    float3 vTanUCorner[4] : TANUCORNER;
                    float3 vTanVCorner[4] : TANVCORNER;
                    float4 vCWts          : TANWEIGHTS;
                };
                TessVertex tessvert (VertexInput v) {
                    TessVertex o;
                    o.vertex = v.vertex;
                    o.normal = v.normal;
                    o.tangent = v.tangent;
                    o.texcoord0 = v.texcoord0;
                    return o;
                }
                void displacement (inout VertexInput v){
                    float4 node_1305 = _Time + _TimeEditor;
                    float2 node_161 = ((v.texcoord0.rg*1.0)+node_1305.g*float2(0.01,-0.01));
                    float4 node_152 = tex2Dlod(_DisplacementR,float4(TRANSFORM_TEX(node_161, _DisplacementR),0.0,1.0));
                    float4 node_1064 = _Time + _TimeEditor;
                    v.vertex.xyz +=  (v.normal*((-1.0)*_Depth)*node_152.rgb*sin(node_1064.g));
                }
                float Tessellation(TessVertex v){
                    return 1.0;
                }
                OutputPatchConstant hullconst (InputPatch<TessVertex,3> v) {
                    OutputPatchConstant o;
                    float ts = Tessellation( v[0] );
                    o.edge[0] = ts;
                    o.edge[1] = ts;
                    o.edge[2] = ts;
                    o.inside = ts;
                    return o;
                }
                [domain("tri")]
                [partitioning("fractional_odd")]
                [outputtopology("triangle_cw")]
                [patchconstantfunc("hullconst")]
                [outputcontrolpoints(3)]
                TessVertex hull (InputPatch<TessVertex,3> v, uint id : SV_OutputControlPointID) {
                    return v[id];
                }
                [domain("tri")]
                VertexOutput domain (OutputPatchConstant tessFactors, const OutputPatch<TessVertex,3> vi, float3 bary : SV_DomainLocation) {
                    VertexInput v;
                    v.vertex = vi[0].vertex*bary.x + vi[1].vertex*bary.y + vi[2].vertex*bary.z;
                    v.normal = vi[0].normal*bary.x + vi[1].normal*bary.y + vi[2].normal*bary.z;
                    v.tangent = vi[0].tangent*bary.x + vi[1].tangent*bary.y + vi[2].tangent*bary.z;
                    v.texcoord0 = vi[0].texcoord0*bary.x + vi[1].texcoord0*bary.y + vi[2].texcoord0*bary.z;
                    displacement(v);
                    VertexOutput o = vert(v);
                    return o;
                }
            #endif
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                SHADOW_COLLECTOR_FRAGMENT(i)
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Cull Off
            Offset 1, 1
            
            Fog {Mode Off}
            CGPROGRAM
            #pragma hull hull
            #pragma domain domain
            #pragma vertex tessvert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma exclude_renderers opengl gles xbox360 ps3 flash 
            #pragma target 5.0
            #pragma glsl
            uniform float4 _TimeEditor;
            uniform float _Depth;
            uniform sampler2D _DisplacementR; uniform float4 _DisplacementR_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(float4(v.normal,0), _World2Object).xyz;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            #ifdef UNITY_CAN_COMPILE_TESSELLATION
                struct TessVertex {
                    float4 vertex : INTERNALTESSPOS;
                    float3 normal : NORMAL;
                    float4 tangent : TANGENT;
                    float2 texcoord0 : TEXCOORD0;
                };
                struct OutputPatchConstant {
                    float edge[3]         : SV_TessFactor;
                    float inside          : SV_InsideTessFactor;
                    float3 vTangent[4]    : TANGENT;
                    float2 vUV[4]         : TEXCOORD;
                    float3 vTanUCorner[4] : TANUCORNER;
                    float3 vTanVCorner[4] : TANVCORNER;
                    float4 vCWts          : TANWEIGHTS;
                };
                TessVertex tessvert (VertexInput v) {
                    TessVertex o;
                    o.vertex = v.vertex;
                    o.normal = v.normal;
                    o.tangent = v.tangent;
                    o.texcoord0 = v.texcoord0;
                    return o;
                }
                void displacement (inout VertexInput v){
                    float4 node_1306 = _Time + _TimeEditor;
                    float2 node_161 = ((v.texcoord0.rg*1.0)+node_1306.g*float2(0.01,-0.01));
                    float4 node_152 = tex2Dlod(_DisplacementR,float4(TRANSFORM_TEX(node_161, _DisplacementR),0.0,1.0));
                    float4 node_1064 = _Time + _TimeEditor;
                    v.vertex.xyz +=  (v.normal*((-1.0)*_Depth)*node_152.rgb*sin(node_1064.g));
                }
                float Tessellation(TessVertex v){
                    return 1.0;
                }
                OutputPatchConstant hullconst (InputPatch<TessVertex,3> v) {
                    OutputPatchConstant o;
                    float ts = Tessellation( v[0] );
                    o.edge[0] = ts;
                    o.edge[1] = ts;
                    o.edge[2] = ts;
                    o.inside = ts;
                    return o;
                }
                [domain("tri")]
                [partitioning("fractional_odd")]
                [outputtopology("triangle_cw")]
                [patchconstantfunc("hullconst")]
                [outputcontrolpoints(3)]
                TessVertex hull (InputPatch<TessVertex,3> v, uint id : SV_OutputControlPointID) {
                    return v[id];
                }
                [domain("tri")]
                VertexOutput domain (OutputPatchConstant tessFactors, const OutputPatch<TessVertex,3> vi, float3 bary : SV_DomainLocation) {
                    VertexInput v;
                    v.vertex = vi[0].vertex*bary.x + vi[1].vertex*bary.y + vi[2].vertex*bary.z;
                    v.normal = vi[0].normal*bary.x + vi[1].normal*bary.y + vi[2].normal*bary.z;
                    v.tangent = vi[0].tangent*bary.x + vi[1].tangent*bary.y + vi[2].tangent*bary.z;
                    v.texcoord0 = vi[0].texcoord0*bary.x + vi[1].texcoord0*bary.y + vi[2].texcoord0*bary.z;
                    displacement(v);
                    VertexOutput o = vert(v);
                    return o;
                }
            #endif
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
