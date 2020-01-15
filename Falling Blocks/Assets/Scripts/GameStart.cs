using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour {

  public string nextScene;
  
  void Start() {
  }
  
  void Update() {
    if(Input.GetKeyDown(KeyCode.Space)){
      SceneManager.LoadScene(nextScene);
    }
  }
}