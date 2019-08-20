using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAnyKey : MonoBehaviour
{
    private bool isAnyKeyDown = false;
    private GameObject buttonContainer;
    // Start is called before the first frame update
    void Start()
    {
        buttonContainer = this.transform.parent.Find("Container").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(isAnyKeyDown == false)
        {
            if (Input.anyKey)
            {
                ShowButton();
            }
        }
    }
    void ShowButton()
    {
        buttonContainer.SetActive(true);
        this.gameObject.SetActive(false);
        isAnyKeyDown = true;
    }
}
