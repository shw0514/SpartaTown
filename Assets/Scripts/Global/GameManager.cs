using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public enum CharacterType
{
    Penguin,
    Wizard
}
[System.Serializable]
public class Character
{
    public CharacterType CharacterType;
    public Sprite CharacterSprite;
    public RuntimeAnimatorController AnimatorController;
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Text PlayerName;
    public Animator PlayerAnimator;

    public List<Character> CharacterList = new List<Character>();
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void SetCharacter(CharacterType characterType, string name)
    {
        var character = GameManager.Instance.CharacterList.Find(item => item.CharacterType == characterType);

        PlayerAnimator.runtimeAnimatorController = character.AnimatorController;
        PlayerName.text = name;
        
    }

}
