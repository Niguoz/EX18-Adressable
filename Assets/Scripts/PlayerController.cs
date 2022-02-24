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
    public string[] labels;
    public string path;
    AssetReference r;


    /*public AssetReferenceSprite sp;
public AssetReferenceMaterial m;*/

    [Obsolete]
    void Start()
    {
        //r = new AssetReference(path);
        //r.LoadAssetAsync<Sprite>().Completed += OnAssetComplete;
        Addressables.LoadAssetsAsync<Sprite>(
            labels,
            null,
            Addressables.MergeMode.Intersection).Completed += OnCompleteList;

        Addressables.InstantiateAsync(path).Completed += OnInstComplete;
    }

    private void OnInstComplete(AsyncOperationHandle<GameObject> obj)
    {
       
    }

    private void OnCompleteList(AsyncOperationHandle<IList<Sprite>> obj)
    {
        foreach(var i in obj.Result)
        {
            Debug.Log(i);
        }

    }

    private void OnAssetComplete(AsyncOperationHandle<Sprite> obj)
    {
        Debug.Log(obj.Result);
        GetComponent<SpriteRenderer>().sprite = obj.Result;
    }

    void OnDestroy()
    {
       // r.ReleaseAsset();
    }
}
