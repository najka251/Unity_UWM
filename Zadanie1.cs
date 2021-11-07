using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Listing1 : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;
    public int ile = 5;
    int objectCounter = 0;
    // obiekt do generowania
    public GameObject block;
    public Material[] kolory = new Material[5];

    void Start()
    {
        MeshRenderer plansza = GetComponent<MeshRenderer>();
        float minX = plansza.bounds.min.x;
        float maxX = plansza.bounds.max.x;
        float minZ = plansza.bounds.min.z;
        float maxZ = plansza.bounds.max.z;

        // w momecie uruchomienia generuje 10 kostek w losowych miejscach
        List<int> pozycje_x = new List<int>(Enumerable.Range((int)minX, (int)maxX).OrderBy(x => Guid.NewGuid()).Take(ile));
        List<int> pozycje_z = new List<int>(Enumerable.Range((int)minZ, (int)maxZ).OrderBy(x => Guid.NewGuid()).Take(ile));

        for (int i = 0; i < ile; i++)
        {
            this.positions.Add(new Vector3(pozycje_x[i], 0, pozycje_z[i]));
        }
        foreach (Vector3 elem in positions)
        {
            Debug.Log(elem);
        }
        // uruchamiamy coroutine
        StartCoroutine(GenerujObiekt());
    }

    void Update()
    {

    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("wywołano coroutine");
        foreach (Vector3 pos in positions)
        {
            GameObject obiekt = Instantiate(this.block, this.positions.ElementAt(this.objectCounter++), Quaternion.identity);
            obiekt.GetComponent<MeshRenderer>().material = this.kolory[Random.Range(0, this.kolory.Length)];
            yield return new WaitForSeconds(this.delay);
        }
        // zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
    }
}
