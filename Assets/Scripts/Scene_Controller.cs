using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Controller : MonoBehaviour {
	public void goToScene(string sceneName) {
		SceneManager.LoadScene (sceneName);
	}
}
