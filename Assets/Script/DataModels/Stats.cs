using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats
{
    public int Lv; // For Character Only
    public string Name;
    public int Atk;
    public float AtkSpd;
    public int Hp; // For Enemy only
    public int GoldDrop; // For Enemy only
    public int Cost; // For Deployment Tower
    public List<Skill> CharacterSkill; // What skill this charcter have
    // Attack Range ??? //



    // Character Stats //
    public Stats(string _name, int _atk, float _atkSpd)
    {
        Lv = 1;
        Name = _name;
        Atk = _atk;
        AtkSpd = _atkSpd;
        //CharacterSkill = _skillList;
        // Attack Range ???//
    }

    // Tower Stats //
    public Stats(string _name, int _atk, float _atkSpd, int _cost)
    {
        Name = _name;
        Atk = _atk;
        AtkSpd = _atkSpd;
        Cost = _cost;
    }


    // Enemy Stats //
    public Stats(string _name, int _hp , int _atk, float _atkSpd, int _goldDrop)
    {
        Name = _name;
        Hp = _hp;
        Atk = _atk;
        AtkSpd = _atkSpd;
        GoldDrop = _goldDrop;
    }



    public void TakeDamage(int x)
    {
        Hp -= x;

        if (Hp < 0)
        {
            Hp = 0;
        }
    }





}
