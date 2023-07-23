using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject sphereUnitPrefab;

    public void CreateSphereUnit()
    {
        // Créer une unité sphérique à la position du portail
        Instantiate(sphereUnitPrefab, transform.position, Quaternion.identity);
    }
}
