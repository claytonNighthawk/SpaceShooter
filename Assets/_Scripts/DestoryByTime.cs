using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DestoryByTime : MonoBehaviour {

    public float lifeTime;

	
	void Start() {

        Destroy(gameObject, lifeTime);
    }

    //IEnumerator WaitToRestart() {
    //    yield return new WaitForSeconds(1.75f);
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //}
}
