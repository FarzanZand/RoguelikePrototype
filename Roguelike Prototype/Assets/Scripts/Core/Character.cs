using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    public enum CharacterTypes
    {
        Player,
        AI
    }

    [SerializeField] private CharacterTypes characterTypes;
    [SerializeField] private GameObject characterSprite;
    [SerializeField] private Animator characterAnimator;

    public CharacterTypes CharacterType => characterType; // Lambda, quick Get on character type
    public GameObject CharacterSprite => characterSprite;
    public Animator CharacterAnimator => characterAnimator; 


    [SerializeField] private CharacterTypes characterType; 
}
