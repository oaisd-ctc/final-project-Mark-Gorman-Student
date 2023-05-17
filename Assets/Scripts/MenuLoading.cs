using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLoading : MonoBehaviour
{
    public static bool LoadDataOnStart = false;

    [SerializeField] GameObject image;
    public void Next()
    {
        image.SetActive(true);
    }

    public void Back()
    {
        image.SetActive(false);
    }

    public void Load()
    {
        LoadDataOnStart = true;
        StartCoroutine(Wait(.1f));
    }

    public void New()
    {
        LoadDataOnStart = false;
        StartCoroutine(Wait(.1f));
    }

    IEnumerator Wait(float i)
    {
        yield return new WaitForSecondsRealtime(i);
        SceneManager.LoadScene(1);
    }
}
