using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIBox : MonoBehaviour
{
    public GameObject button;
    public GameObject buttonClick;

    public Text percent;
    public Text loading;

    private bool isStartclick;

    private void Awake()
    {
        buttonClick.SetActive(false);
        loading.gameObject.SetActive(false);
        percent.gameObject.SetActive(false);
        isStartclick = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        buttonClick.SetActive(true);
        button.SetActive(false);

    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if(other.GetComponent<UISelect>().IsSelect)
            {
                other.GetComponent<UISelect>().OKSelect();
                Click();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        buttonClick.SetActive(false);
        button.SetActive(true);
    }

    public void Click()
    {
        if(!isStartclick)
        {
            isStartclick = true;
            StartCoroutine(LoadAsynchronously(1));
        }
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {

        loading.gameObject.SetActive(true);
        percent.gameObject.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        operation.allowSceneActivation = false;

        while(!operation.isDone)
        {
            if (operation.progress >= 0.9f)
            {               
                operation.allowSceneActivation = true;
            }
            else
            {
                int i = (int)(operation.progress * 100);
                percent.text = i.ToString() + "%";
                Debug.Log(operation.progress);
            }
            yield return null;
        }
        Debug.Log("is done");


    }

}
