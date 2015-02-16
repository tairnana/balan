using UnityEngine;
using System;
using System.Collections;
using PathologicalGames;

public class TairButton : TairObject {

    public int layer = 0;

    protected float _shakeTime;
    protected Vector3 _shakeAmt;

    protected Vector3 originalScale;
    protected Vector3 downScale;

    float downTime;
    public GameObject visual;

    void Awake() {
        originalScale = this.transform.localScale;
        downScale = originalScale;
        downTime = 0;
        PrimInit();
    }

    void Start() {
        Init();
    }

    #region /:: Override ::/
    public virtual void Init() {

    }
    public virtual void Down() {
        downTime = 0.1f;
    }
    public virtual void Up() {
        downTime = 0;
    }
    public virtual void Activate(bool shake = true) {
        downTime = 0;
        Debug.Log("Pushed");
    }
    #endregion



}