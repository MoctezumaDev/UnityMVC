using UnityEngine;
using System.Collections;

public class BasicModel : UnityMVC.Model
{
    public string Name;

    public BasicModel(string name)
    {
        Name = name;
    }
}
