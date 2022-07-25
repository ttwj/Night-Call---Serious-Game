using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  
public class IntroductionSceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnClickTransitionButton() {
        SceneManager.LoadScene("TransitionScene");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
