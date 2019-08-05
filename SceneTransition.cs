using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    private Animator TransitionAnim;
    // Start is called before the first frame update
    void Start()
    {
        TransitionAnim = GetComponent<Animator>();
    }
    public void LoadScene(string SceneName)
    {
        StartCoroutine(Transition(SceneName));
    }

    IEnumerator Transition(string SceneName)
    {
        TransitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
