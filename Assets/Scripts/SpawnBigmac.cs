using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBigmac : MonoBehaviour
{
    public GameObject spawnBigMac;
    private float nextActionTime = 0.0f;
    public float period = 1.0f;
    private List<GameObject> bigmacs = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            GameObject newBigmac = Instantiate(spawnBigMac);
            newBigmac.AddComponent<Rigidbody>();
            bigmacs.Add(newBigmac);

            foreach (GameObject bigmac in bigmacs)
            {
                if (bigmac.transform.position.y < -4.5)
                {
                    bigmacs.Remove(bigmac);
                    Destroy(bigmac);
                }
            }
        }
    }
}
