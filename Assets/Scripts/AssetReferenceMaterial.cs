using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

[System.Serializable]
public class AssetReferenceMaterial : AssetReferenceT<Material>
{
    public AssetReferenceMaterial(string guid) : base(guid)
    {
        
    }
}
