using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Item 
{
    public int Id;
    public string Name;
    public string Description;
    public Sprite Visual;
    public Action ItemEffect;


    public Item(int _id, string _name, string _description, Sprite _sprite, Action _act)
    {
        Id = _id;
        Name = _name;
        Description = _description;
        Visual = _sprite;
        ItemEffect = _act;
    }


}


