using UnityEngine;
using System.Collections;

public class BasicMapper : UnityMVC.Mapper
{
    protected override void StartMapping()
    {
        Map<BasicModel, BasicView, BasicController>();
    }
}
