using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    private void LoadSpecificScene(int _sceneIndex)
    {
        SceneManager.LoadScene(_sceneIndex);
    }
}
