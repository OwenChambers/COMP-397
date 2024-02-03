using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    TMP_Dropdown sceneSelector;
    

    // Start is called before the first frame update
    void Start()
    {
        sceneSelector = GetComponentInChildren<TMP_Dropdown>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneSelector.value);
    }
}
