using UnityEngine;
using System.Collections;

public class LpWorldFragment : MonoBehaviour {

	void Start () {
        this.transform.localScale = Vector3.zero;
        iTween.ScaleTo(this.gameObject, iTween.Hash("scale",Vector3.one*0.05f,"easetype",iTween.EaseType.easeOutElastic,"time",0.77f));
        //StartCoroutine(Cull());
	}

	IEnumerator Cull(){
        Renderer ren = this.renderer;
        Transform tran = this.transform;
        bool isCulled = false;
        while(true){

            if(tran.up.z < 0.4f){
                isCulled = true;
            }else{
                isCulled = false;
            }

            if(!isCulled && ren.enabled){
                ren.enabled = false;
            }else if(isCulled && !ren.enabled){
                ren.enabled = true;
            }

            yield return new WaitForSeconds(0.3f);
        }
    }
	
}
