using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public Stats Character;
    public List<Stats> ListOfCharacter; //this will pack Character in it
    
    public Stats Enemy;
    private List<Stats> Enemies; // this will pack multiple Enemy in it 

    public int Gold;

    public Card Card;
    private List<Card> ListOfAllCards; // this will pack multiple Cards in it



    void Start()
    {
        
    }

    void Update()
    {
        
    }
}


// Player Will Learn Skill and Use the Skill Effect
  // So skill learnig is refering "Skill" script ---> "AllSkillEffect"(to get the case of the effects) ---> "Stats"(Calculation for stats)