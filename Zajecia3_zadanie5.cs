using UnityEngine;
using System.Collections.Generic;
public class Zajecia3_zadanie5 : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject myPrefab;
    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        List<int> ListRandomX = new List<int>();
        List<int> ListRandomZ = new List<int>();
        // Instantiate at position (0, 0, 0) and zero rotation.
        while (ListRandomX.Count != 10 && ListRandomZ.Count != 10)
        {
            List<int> Lista = ListaXZ(0, 10, ListRandomX, ListRandomZ);
            ListRandomX.Add(Lista[0]);
            ListRandomZ.Add(Lista[1]);
            Instantiate(myPrefab, new Vector3(Lista[0], 0, Lista[1]), Quaternion.identity);
        }
    }
    public static List<int> ListaXZ(int min, int max, List<int> ListRandomX, List<int> ListRandomZ)
    {
        List<int> Lista = new List<int>();
        int X = Random.Range(min, max);
        int Z = Random.Range(min, max);
        while (ListRandomX.Contains(X))
        {
            X = Random.Range(min, max);
        }
        while (ListRandomZ.Contains(Z))
        {
            Z = Random.Range(min, max);
        }
        Lista.Add(X);
        Lista.Add(Z);
        return Lista;
    }
}