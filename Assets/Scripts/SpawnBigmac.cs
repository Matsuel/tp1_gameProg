using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBigmac : MonoBehaviour
{
    public GameObject spawnBigMac;
    private float nextActionTime = 0.0f;
    public float period = 0.5f;
    private List<GameObject> bigmacs = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            GameObject newBigmac = Instantiate(spawnBigMac);
            newBigmac.AddComponent<Rigidbody>();
            newBigmac.transform.position = new Vector2(Random.Range(-10.2f, 10.2f), 6.0f);
            float randomScale = Random.Range(0.7f, 2.0f);
            newBigmac.transform.localScale = new Vector2(randomScale, randomScale);
            newBigmac.GetComponent<Rigidbody>().mass = randomScale;
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
