using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomActive : MonoBehaviour {
	public GameObject[] obj;
	public List<GameObject> child;
	void Start () {

		foreach(Transform a in transform){
			a.gameObject.SetActive(false);
			child.Add(a.gameObject);
		}
		child[Random.Range(0,transform.childCount)].SetActive(true);
		//transform[Random.Range(0,transform.childCount)] .SetActive(true);
	}

}
