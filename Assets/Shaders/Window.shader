Shader "Window"
{
	Properties{}

	SubShader{

		Tags {
		}
    Stencil{
            Ref 1
            Comp Always
            Pass Replace
        }
		Pass {
			ZWrite Off
		}
	}
	Fallback "Diffuse"
}