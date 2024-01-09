using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ShipCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name== "Asteroides(Clone)")
        {
            Destroy(gameObject);


            List<GameObject> bigmacsToRemove = new List<GameObject>();
            foreach (GameObject bigmac in GameObject.FindGameObjectsWithTag("Asteroides"))
            {
                bigmacsToRemove.Add(bigmac);
                Destroy(bigmac);
            }
            // foreach (GameObject bigmac in bigmacsToRemove)
            // {
            //     bigmacsToRemove.Remove(bigmac);
            // }
            Debug.Log(bigmacsToRemove.Count);
            SceneManager.LoadScene(1);
        }

    }
}
