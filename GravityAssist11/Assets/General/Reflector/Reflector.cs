using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Reflection;
using System;

public static class Reflector
{
    public static void getAssemblies(List<AssemblyBoi> database)
    {
        database.Clear();
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        foreach (var assembly in assemblies)
        {
            var name = assembly.GetName().Name;
            var Addres = new List<string>();
            WordsToSymbols.ProcessAddres(name, Addres, new List<char> { '.' });

            List<AssemblyBoi> curList = database;
            Debug.Log(Addres);
            AssemblyBoi CurBoi;

            for (int i = 0; i < Addres.Count; i++)
            {
                CurBoi = curList.SingleOrDefault(bi => bi.name == Addres[i]);

                if (CurBoi == null)
                {
                    CurBoi = new AssemblyBoi();
                    CurBoi.name = Addres[i];
                    curList.Add(CurBoi);
                }
                if (i == Addres.Count - 1)
                {
                    CurBoi.typeBois = Reflector.GetTypes(assembly);
                }
                else
                {
                    curList = CurBoi.subAssemblies;
                }
            }

        }
    }

 

    public static List<TypeBoi> GetTypes(Assembly assembly)
    {
        var types = assembly.GetTypes();

        var typeBois = new List<TypeBoi>();
        foreach (var boi in types)
        {
            var typeBoi = new TypeBoi();
            typeBoi.name = boi.FullName;
            //typeBoi.Class = boi.DeclaringType.Name;
            //typeBoi.parameters = GetParametersFromMachine(boi);
            //typeBoi.returnType = OutputTypeExtracter.GetOutputType(boi.ReturnType, 3);
            typeBois.Add(typeBoi);
        }
        Debug.Log("Found " + typeBois.Count + " types in " + assembly.GetName().Name);
        return typeBois;
    }

    public static List<Parameter> GetParametersFromMachine(MethodInfo info)
    {
        var parameters = new List<Parameter>();
        foreach (var parameter in info.GetParameters())
        {
            var Tparameter = new Parameter();
            Tparameter.name = parameter.Name;
            Tparameter.type = parameter.GetType().ToString();
            parameters.Add(Tparameter);
        }
        return parameters;
    }
}
[System.Serializable]
public class Parameter
{
    public string name;
    public string type;
}
