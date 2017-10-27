using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AttributeUsage(AttributeTargets.Class)]
public class Worker : Attribute
{
    private string v;

    public Worker(string v)
    {
        this.v = v;
    }

    public string Name { get; set; }
}