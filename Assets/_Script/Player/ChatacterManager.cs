using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.Animations;

public class ChatacterManager : MonoBehaviour
{
    bool isFly = true;
    public CharacterDatabase characterDB;
    public SpriteRenderer playlerSprite;
    public Animator playerAnimator;

    private int selectedOption = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }
        else
        {
            Load();
        }

        UpdateCharacter(selectedOption);
        
    }
    private void Update()
    {
        PlayAnim();
    }

    public void NexOption()
    {
        selectedOption++;

        if (selectedOption >= characterDB.CharacterCount)
        {
            selectedOption = 0;
        }

        UpdateCharacter(selectedOption);
        Save();
    }

    public void BackOption()
    {
        selectedOption--;
        if (selectedOption < 0)
        {
            selectedOption = characterDB.CharacterCount - 1;
        }
        UpdateCharacter(selectedOption);
        Save();
    }
    private void UpdateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharactor(selectedOption);
        playlerSprite.sprite = character.characterSprite;
        playerAnimator.runtimeAnimatorController = character.controllerRunTime;
        
    }
    
    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("selectedOption", selectedOption);
    }

    public void gameScence(int Scenceid) 
    {
        SceneManager.LoadScene(Scenceid);
    }

    private void PlayAnim()
    {
        playerAnimator.SetBool("isFly", isFly);
    }
}
