using UnityEngine;
using System.Collections;

public class GenerateWorld : LpObject
{
    public Camera cam;
    public GameObject[] pref_obj;
    public int seed_amount = 24;

    void Start()
    {
        radius = GetComponent<SphereCollider>().radius * transform.localScale.x;
        GenerateRandomWorld(seed_amount);
    }

    public override void Touched(RaycastHit hit)
    {
        base.Touched(hit);
        this.SpawnFragment(hit);
    }

    private void SpawnFragment(RaycastHit hit)
    {
        GameObject tmp = Instantiate(pref_obj [Random.Range(0,pref_obj.Length)]) as GameObject;
        tmp.transform.position = hit.point;
        tmp.transform.parent = hit.transform;
        tmp.transform.up = hit.normal;
    }

    private float Rand()
    {
        return Random.Range(-radius, radius);
    }

    private void GenerateRandomWorld(int size)
    {
        for (int i = 0; i < size; i++)
        {
            GameObject tmp = Instantiate(pref_obj [Random.Range(0,pref_obj.Length)]) as GameObject;

            Vector3 pos = new Vector3(Rand(), Rand(), Rand());
            pos = pos.normalized;
            pos *= radius;//+ 0.5f;

            tmp.transform.position = pos;
            tmp.transform.parent = transform;
            tmp.transform.up = pos;
           
        }
    }

    private float radius;
    private float x, y, z;

    void OnGUI(){
        GUI.Label(new Rect(0,22,100,22),"Tree : "+this.transform.childCount);
    }
    // x^2 + y^2 + z^2 = r^2
    // (x-h)^2 + (y-j)^2 + (z-k)^2 = r^2
}
