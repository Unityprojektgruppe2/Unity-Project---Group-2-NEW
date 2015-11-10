using UnityEngine;
using System.Collections.Generic;
/// <summary>
/// http://grrava.blogspot.fi/2014/08/combine-meshes-in-unity.html
/// 
/// License: http://grrava.blogspot.com/2014/08/combine-meshes-in-unity.html?showComment=1415131489383#c3933942129906383316 
/// Alex Vanden Abeele said...
/// Copy paste away, all code on my blog may be used at will :)
/// November 4, 2014 at 9:04 PM
/// </summary>
[AddComponentMenu("Mesh/Combine Children")]
public class CombineChildren : MonoBehaviour
{

    void Start()
    {
        Matrix4x4 myTransform = transform.worldToLocalMatrix;
        Dictionary<Material, List<CombineInstance>> combines = new Dictionary<Material, List<CombineInstance>>();
        MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>();
        foreach (var meshRenderer in meshRenderers)
        {
            foreach (var material in meshRenderer.sharedMaterials)
                if (material != null && !combines.ContainsKey(material))
                    combines.Add(material, new List<CombineInstance>());
        }

        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        foreach (var filter in meshFilters)
        {
            if (filter.sharedMesh == null)
                continue;
            var filterRenderer = filter.GetComponent<Renderer>();
            if (filterRenderer.sharedMaterial == null)
                continue;
            if (filterRenderer.sharedMaterials.Length > 1)
                continue;
            CombineInstance ci = new CombineInstance
            {
                mesh = filter.sharedMesh,
                transform = myTransform * filter.transform.localToWorldMatrix
            };
            combines[filterRenderer.sharedMaterial].Add(ci);

            Destroy(filterRenderer);
        }

        foreach (Material m in combines.Keys)
        {
            var go = new GameObject("Combined mesh");
            go.transform.parent = transform;
            go.transform.localPosition = Vector3.zero;
            go.transform.localRotation = Quaternion.identity;
            go.transform.localScale = Vector3.one;

            var filter = go.AddComponent<MeshFilter>();
            filter.mesh.CombineMeshes(combines[m].ToArray(), true, true);

            var arenderer = go.AddComponent<MeshRenderer>();
            arenderer.material = m;
        }
    }
}