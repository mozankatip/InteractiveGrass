using System.Collections.Generic;
using UnityEngine;

public class GrassPainter : MonoBehaviour
{
    public LayerMask paintTargetLayer;
    public List<GameObject> grassPrefabs;
    [Range(1, 5)]
    public float paintRadius = 1f;
    [Range(0, 1)]
    public float density = 0.1f;

    private bool isPainting;

    public void StartPainting(Vector3 position, Vector3 normal)
    {
        isPainting = true;
        PaintGrass(position, normal);
    }

    public void StopPainting()
    {
        isPainting = false;
    }

    private void PaintGrass(Vector3 position, Vector3 normal)
    {
        for (int i = 0; i < density; i++)
        {
            float x = Random.Range(-paintRadius, paintRadius);
            float z = Random.Range(-paintRadius, paintRadius);

            Vector3 offset = new Vector3(x, 0f, z);
            Vector3 paintPosition = position + offset;

            int prefabIndex = Random.Range(0, grassPrefabs.Count);
            GameObject selectedPrefab = grassPrefabs[prefabIndex];

            Quaternion rotation = Quaternion.FromToRotation(Vector3.up, normal);
            GameObject newGrass = Instantiate(selectedPrefab, paintPosition, rotation, transform);

            // Set the "Grass" tag to the new grass instance
            newGrass.tag = "Grass";
        }
    }

    public void EraseAllGrass()
    {
        GameObject[] grassInstances = GameObject.FindGameObjectsWithTag("Grass");

        foreach (GameObject instance in grassInstances)
        {
            if (instance.transform.IsChildOf(transform))
            {
                DestroyImmediate(instance);
            }
        }
    }
}
