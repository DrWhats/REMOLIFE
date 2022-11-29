
using System;
using System.IO;
using UnityEngine;

public class player
{
    public string name;
    public int day;
    
    public player(string name, int day)
    {
        this.name = name;
        this.day = day;
    }
    public player(string name)
    {
        this.name = name;
        this.day = 0;
    }

}
