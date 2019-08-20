using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterReaction : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    private GameObject[] characterGameObjects;
    private int selectedIndex = 0;
    private int length;
    public UIInput nameInput;
    // Start is called before the first frame update
    void Start()
    {
        length = characterPrefabs.Length;
        characterGameObjects = new GameObject[length];
        for(int i = 0; i < length; i++)
        {
            characterGameObjects[i] = GameObject.Instantiate(characterPrefabs[i], transform.position, transform.rotation) as GameObject;
            characterGameObjects[i].GetComponent<Transform>().rotation = Quaternion.Euler(0, 180f, 0);
        }
        characterGameObjects[1].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void UpdateCharacterShow()
    {
        characterGameObjects[selectedIndex].SetActive(true);
        for (int i = 0; i < length; i++) {
            if(i != selectedIndex)
            {
                characterGameObjects[i].SetActive(false);
            }
        }
    }
    public void OnNextButtonsClick()
    {
        selectedIndex++;
        selectedIndex %= length;
        UpdateCharacterShow();
    }

    public void OnPreButtonClick()
    {
        selectedIndex--;
        if (selectedIndex == -1)
        {
            selectedIndex = length - 1;
        }
        UpdateCharacterShow();
    }

    public void OnOkButtonClick()
    {
        PlayerPrefs.SetInt("SelectedCharacterIndex", selectedIndex);
        PlayerPrefs.SetString("name", nameInput.value);
        Debug.Log(nameInput.value);
    }

}
