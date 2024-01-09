using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ShipCollider : MonoBehaviour
{
    public SpawnBigmac spawnBigmac;
    private void OnTriggerEnter(Collider other)
    {
            spawnBigmac.canSpawn = false;
            SceneManager.LoadScene(1);
        Destroy(gameObject);
    }
}
