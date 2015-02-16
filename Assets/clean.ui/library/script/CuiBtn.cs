using UnityEngine;
using System.Collections;

public class CuiBtn : TairObject
{

    //public CuiManager manager;

    public GameObject btn_up;
    public GameObject btn_down;
    public TextMesh btn_text;
    public int layer = 0;
        

    #region /:: Override ::/
    public virtual void Init()
    {

    }

    public virtual void Down()
    {
        //downTime = 0.1f;
    }

    public virtual void Up()
    {
        //downTime = 0;
    }

    public virtual void Activate(bool shake = true)
    {
        //downTime = 0;
        Debug.Log("Pushed");
    }
    #endregion
    void Start()
    {
        Init();

    }

    void Update()
    {
        //bg.renderer.material.color = manager.ui_color [col_index];
    }
    /*
        void OnDrawGizmos ()
        {
                Gizmos.color = Color.red;
                Gizmos.DrawWireCube (collider2D.bounds.center, collider2D.bounds.size);
        }
*/
}
