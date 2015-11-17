#warning Upgrade NOTE: unity_Scale shader variable was removed; replaced 'unity_Scale.w' with '1.0'

/*SF_DATA;ver:0.34;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:0,limd:0,uamb:True,mssp:True,lmpd:False,lprd:True,enco:False,frtr:True,vitr:True,dbil:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,blpr:0,bsrc:0,bdst:0,culm:0,dpts:2,wrdp:True,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:0,x:31865,y:31925|custl-412-OUT;n:type:ShaderForge.SFN_LightAttenuation,id:37,x:33127,y:31873;n:type:ShaderForge.SFN_Dot,id:40,x:34074,y:32257,dt:1|A-42-OUT,B-41-OUT;n:type:ShaderForge.SFN_NormalVector,id:41,x:34283,y:32351,pt:True;n:type:ShaderForge.SFN_LightVector,id:42,x:34283,y:32230;n:type:ShaderForge.SFN_LightColor,id:63,x:33127,y:32014;n:type:ShaderForge.SFN_Multiply,id:64,x:32831,y:32136|A-37-OUT,B-63-RGB,C-385-OUT;n:type:ShaderForge.SFN_Color,id:80,x:32709,y:31902,ptlb:Color,ptin:_Color,glob:False,c1:1,c2:0.007352948,c3:0.2332658,c4:1;n:type:ShaderForge.SFN_AmbientLight,id:187,x:33452,y:32312;n:type:ShaderForge.SFN_ValueProperty,id:216,x:33872,y:32430,ptlb:Bands,ptin:_Bands,glob:False,v1:6;n:type:ShaderForge.SFN_Posterize,id:264,x:33637,y:32351|IN-40-OUT,STPS-216-OUT;n:type:ShaderForge.SFN_Slider,id:296,x:33241,y:32439,ptlb:Eclaircir,ptin:_Eclaircir,min:0,cur:0.1,max:0.5;n:type:ShaderForge.SFN_Time,id:297,x:33828,y:32549;n:type:ShaderForge.SFN_Cos,id:309,x:33375,y:32548|IN-326-OUT;n:type:ShaderForge.SFN_Abs,id:312,x:33206,y:32548|IN-309-OUT;n:type:ShaderForge.SFN_Add,id:322,x:33006,y:32548|A-312-OUT,B-323-OUT;n:type:ShaderForge.SFN_Vector1,id:323,x:33206,y:32711,v1:4;n:type:ShaderForge.SFN_Divide,id:324,x:32748,y:32460|A-322-OUT,B-323-OUT;n:type:ShaderForge.SFN_Slider,id:325,x:33828,y:32723,ptlb:Time * x,ptin:_Timex,min:1,cur:1,max:10;n:type:ShaderForge.SFN_Multiply,id:326,x:33590,y:32549|A-297-T,B-325-OUT;n:type:ShaderForge.SFN_Multiply,id:382,x:33414,y:32140|A-418-OUT,B-264-OUT;n:type:ShaderForge.SFN_Add,id:385,x:33147,y:32226|A-382-OUT,B-187-RGB,C-296-OUT;n:type:ShaderForge.SFN_Lerp,id:386,x:32831,y:32284|A-385-OUT;n:type:ShaderForge.SFN_Tex2d,id:389,x:33937,y:31882,ptlb:texture,ptin:_texture,tex:ef9f9ac1b31872145906013718d8c2f7,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:412,x:32360,y:31963|A-80-RGB,B-64-OUT;n:type:ShaderForge.SFN_Power,id:418,x:33721,y:31882|VAL-389-RGB,EXP-419-OUT;n:type:ShaderForge.SFN_Slider,id:419,x:33919,y:32088,ptlb:texture_contrast,ptin:_texture_contrast,min:1,cur:3,max:10;proporder:80-216-296-325-389-419;pass:END;sub:END;*/

Shader "Custom/Custom Lighting" {
    Properties {
        _Color ("Color", Color) = (1,0.007352948,0.2332658,1)
        _Bands ("Bands", Float ) = 6
        _Eclaircir ("Eclaircir", Range(0, 0.5)) = 0.1
        _Timex ("Time * x", Range(1, 10)) = 1
        _texture ("texture", 2D) = "white" {}
        _texture_contrast ("texture_contrast", Range(1, 10)) = 3
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "ForwardBase"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            Fog {Mode Off}
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma exclude_renderers gles xbox360 ps3 flash 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _Color;
            uniform float _Bands;
            uniform float _Eclaircir;
            uniform sampler2D _texture; uniform float4 _texture_ST;
            uniform float _texture_contrast;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                float3 shLight : TEXCOORD5;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.shLight = ShadeSH9(float4(mul(_Object2World, float4(v.normal,0)).xyz * 1.0,1)) * 0.5;
                o.normalDir = mul(float4(v.normal,0), _World2Object).xyz;
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
/////// Normals:
                float3 normalDirection =  i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float2 node_425 = i.uv0;
                float3 node_385 = ((pow(tex2D(_texture,TRANSFORM_TEX(node_425.rg, _texture)).rgb,_texture_contrast)*floor(max(0,dot(lightDirection,normalDirection)) * _Bands) / (_Bands - 1))+UNITY_LIGHTMODEL_AMBIENT.rgb+_Eclaircir);
                float3 finalColor = (_Color.rgb*(attenuation*_LightColor0.rgb*node_385));
/// Final Color:
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "ForwardAdd"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            Fog { Color (0,0,0,0) }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma exclude_renderers gles xbox360 ps3 flash 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _Color;
            uniform float _Bands;
            uniform float _Eclaircir;
            uniform sampler2D _texture; uniform float4 _texture_ST;
            uniform float _texture_contrast;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(float4(v.normal,0), _World2Object).xyz;
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
/////// Normals:
                float3 normalDirection =  i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float2 node_426 = i.uv0;
                float3 node_385 = ((pow(tex2D(_texture,TRANSFORM_TEX(node_426.rg, _texture)).rgb,_texture_contrast)*floor(max(0,dot(lightDirection,normalDirection)) * _Bands) / (_Bands - 1))+UNITY_LIGHTMODEL_AMBIENT.rgb+_Eclaircir);
                float3 finalColor = (_Color.rgb*(attenuation*_LightColor0.rgb*node_385));
/// Final Color:
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
