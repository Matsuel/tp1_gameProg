using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Asteroides = Asteroides;

public class SpawnBigmac : MonoBehaviour
{
    public GameObject bigMac;
    public float nextActionTime = 0.0f;
    public float period = 1.0f;
    public List<GameObject> bigmacs = new List<GameObject>();
    public List<GameObject> bigmacsToRemove = new List<GameObject>();
    public bool canSpawn = true;

    private float currentTime;

    void Start()
    {
        foreach (GameObject burger in GameObject.FindGameObjectsWithTag("Asteroides"))
        {
                Destroy(burger);
                bigmacs.Remove(burger);
        }
        currentTime = 0.0f;
        nextActionTime = 0.0f;
        bigmacsToRemove.Clear();
        period = 1.0f;
        bigmacs.Clear();
        canSpawn = true;
        StartCoroutine(SpawnAst());
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject bigmac in bigmacs)
        {
            if (bigmac.transform.position.y < -4.5)
            {
                bigmacsToRemove.Add(bigmac);
                Destroy(bigmac);
            }
        }

        foreach (GameObject bigmac in bigmacsToRemove)
        {
            bigmacs.Remove(bigmac);
        }
    }

    IEnumerator SpawnAst() {
        while (canSpawn)
        {
            yield return new WaitForSeconds(0.4f);
            GameObject newBigmac = Instantiate(bigMac);
            newBigmac.AddComponent<Rigidbody>();
            newBigmac.transform.position = new Vector2(Random.Range(-10.2f, 10.2f), 6.0f);
            float randomScale = Random.Range(0.7f, 2.0f);
            newBigmac.transform.localScale = new Vector2(randomScale, randomScale);
            newBigmac.GetComponent<Rigidbody>().mass = Random.Range(0.5f, 4.0f);
            newBigmac.GetComponent<Rigidbody>().velocity =new Vector2(Random.Range(-2.0f, 2.0f), Random.Range(-2.0f, -4.0f));
            BoxCollider boxCollider = newBigmac.AddComponent<BoxCollider>();
            boxCollider.size = new Vector2(1.0f, 1.0f);
            bigmacs.Add(newBigmac);
        }
    }
}
