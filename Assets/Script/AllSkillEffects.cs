using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllSkillEffects : MonoBehaviour
{
    //Hold It //
    private Stats stats;
    private Skill currentSkill;

    public void SkillEffect(int _id)
    {
        currentSkill.Id = _id;
        
        switch(_id)
        {
            case 0:
                // Star Skill 1           
                break;
            case 1:
                // Star Skill 2
                break;
            case 2:
                // Star Skill 3
                break;


        }
    }
}
