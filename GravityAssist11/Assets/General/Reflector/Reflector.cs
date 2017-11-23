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
                   // CurBoi.typeBois = Reflector.GetTypes(assembly);
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
        foreach (var type in types)
        {
            var typeBoi = new TypeBoi();
            typeBoi.name = type.FullName;
            GetMethods(type, typeBoi);
            typeBois.Add(typeBoi);
        }
        Debug.Log("Found " + typeBois.Count + " types in " + assembly.GetName().Name);
        return typeBois;
    }
    public static void GetMethods(Type type,TypeBoi typeBoi)
    {
        var methods = type.GetMethods();
        foreach (var method in methods)
        {
            if (method.IsStatic)
            {
                var methodBoi = new MethodBoi();
                methodBoi.name = method.Name;
                methodBoi.parameters = GetParametersForMehtod(method);
                if (method.ReturnType == typeof(void))
                {
                    typeBoi.ActionMethods.Add(methodBoi);
                }
                else
                {
                    
                    methodBoi.returnType = OutputTypeExtracter.GetOutputType(method.ReturnType, 3);
                    typeBoi.FuncMethods.Add(methodBoi);
                }
            }
        }

    }

    public static List<Parameter> GetParametersForMehtod(MethodInfo info)
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
