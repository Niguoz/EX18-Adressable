using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class PlayerController : MonoBehaviour
{
    // [AssetReferenceUILabelRestriction("baseship")]
    // public AssetReference asset;
    public string label;
    public string path;
    AssetReference r;
    public AssetReferenceSprite sp;

    public AssetReferenceMaterial m;
    void Start()
    {
        r = new AssetReference(path);
        r.LoadAssetAsync<Sprite>().Completed += OnAssetComplete;
    }

    private void OnAssetComplete(AsyncOperationHandle<Sprite> obj)
    {
        Debug.Log(obj.Result);
        GetComponent<SpriteRenderer>().sprite = obj.Result;
    }

    void OnDestroy()
    {
        r.ReleaseAsset();
    }
}
