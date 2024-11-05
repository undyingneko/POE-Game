using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnManager : MonoBehaviour
{
    public static ItemSpawnManager instance;
    [SerializeField] LayerMask terrainLayerMast;
    [SerializeField] GameObject itemPrefab;

    private void Awake()
    {
        instance = this;
    }

    public void SpawnItem(Vector3 position, ItemData itemToSpawn)
    {
        position += Vector3.up * 20;

        Ray findSurfaceRay = new Ray(position, Vector3.down);

        RaycastHit hit;

        if (Physics.Raycast(findSurfaceRay, out hit, Mathf.Infinity, terrainLayerMast))
        {
            GameObject.Instantiate(itemPrefab, hit.point, Quaternion.identity);
        }
    }



}
