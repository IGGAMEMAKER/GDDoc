using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleTextsController : MonoBehaviour {
    List<string> items;

    public GameObject InputPrefab;

	// Use this for initialization
	void Start () {
        items = new List<string>();
	}

    public void AddItem()
    {
        GameObject obj = Instantiate(InputPrefab, transform, false);
        items.Add("");

        
    }
}
