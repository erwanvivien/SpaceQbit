using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class HideWalls : MonoBehaviour
{
    private Renderer _renderer;

    private GameObject previous;

    private float _time;
    public float timeNeededToTransparent = 0.5f;
    private static readonly int ZWrite = Shader.PropertyToID("_ZWrite");
    private static readonly int SrcBlend = Shader.PropertyToID("_SrcBlend");
    private static readonly int DstBlend = Shader.PropertyToID("_DstBlend");


    public static class StandardShaderUtils
 {
     public enum BlendMode
     {
         Opaque,
         Cutout,
         Fade,
         Transparent
     }
 
     public static void ChangeRenderMode(Material standardShaderMaterial, BlendMode blendMode)
     {
         switch (blendMode)
         {
             case BlendMode.Opaque:
                 standardShaderMaterial.SetInt(SrcBlend, (int)UnityEngine.Rendering.BlendMode.One);
                 standardShaderMaterial.SetInt(DstBlend, (int)UnityEngine.Rendering.BlendMode.Zero);
                 standardShaderMaterial.SetInt(ZWrite, 1);
                 
                 standardShaderMaterial.DisableKeyword("_ALPHATEST_ON");
                 standardShaderMaterial.DisableKeyword("_ALPHABLEND_ON");
                 standardShaderMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                 standardShaderMaterial.renderQueue = -1;
                 break;
             case BlendMode.Cutout:
                 standardShaderMaterial.SetInt(SrcBlend, (int)UnityEngine.Rendering.BlendMode.One);
                 standardShaderMaterial.SetInt(DstBlend, (int)UnityEngine.Rendering.BlendMode.Zero);
                 standardShaderMaterial.SetInt(ZWrite, 1);
                 
                 standardShaderMaterial.EnableKeyword("_ALPHATEST_ON");
                 standardShaderMaterial.DisableKeyword("_ALPHABLEND_ON");
                 standardShaderMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                 standardShaderMaterial.renderQueue = 2450;
                 break;
             case BlendMode.Fade:
                 standardShaderMaterial.SetInt(SrcBlend, (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                 standardShaderMaterial.SetInt(DstBlend, (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                 standardShaderMaterial.SetInt(ZWrite, 0);
                 
                 standardShaderMaterial.DisableKeyword("_ALPHATEST_ON");
                 standardShaderMaterial.EnableKeyword("_ALPHABLEND_ON");
                 standardShaderMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                 standardShaderMaterial.renderQueue = 3000;
                 break;
             case BlendMode.Transparent:
                 standardShaderMaterial.SetInt(SrcBlend, (int)UnityEngine.Rendering.BlendMode.One);
                 standardShaderMaterial.SetInt(DstBlend, (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                 standardShaderMaterial.SetInt(ZWrite, 0);
                 
                 standardShaderMaterial.DisableKeyword("_ALPHATEST_ON");
                 standardShaderMaterial.DisableKeyword("_ALPHABLEND_ON");
                 standardShaderMaterial.EnableKeyword("_ALPHAPREMULTIPLY_ON");
                 standardShaderMaterial.renderQueue = 3000;
                 break;
         }
 
     }
 }
    
    
    
    
    
    
    
    
    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        previous = null;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag("Mur"))
            {
                if (previous == null)
                    _time = 0;
                else if (previous != hit.collider.gameObject)
                {
                    Material m = previous.GetComponent<Renderer>().material;
                    m.color = new Color(m.color.r, m.color.g, m.color.b, 1);
                    previous.GetComponent<Renderer>().material = m;
                }
                    
                previous = hit.collider.gameObject;
                
                if (_time > timeNeededToTransparent)
                {
                    Material m = previous.GetComponent<Renderer>().material;
                    m.color = new Color(m.color.r, m.color.g, m.color.b, 0.3f);
                    previous.GetComponent<Renderer>().material = m;
                }
            }
            else
            {
                if (previous != null)
                {
                    Material m = previous.GetComponent<Renderer>().material;
                    m.color = new Color(m.color.r, m.color.g, m.color.b, 1);
                    previous.GetComponent<Renderer>().material = m;
                    previous = null;
                }
            }
        }
        
        _time += Time.deltaTime;
    }
}
