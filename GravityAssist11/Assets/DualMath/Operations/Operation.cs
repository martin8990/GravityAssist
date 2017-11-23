using System;
using System.Collections.Generic;
public class token
{
    public List<token> kids = new List<token>();
    public dType type;
    public int priority;        
}

public enum dType {INT,FLOAT,PLUS,MIN,MULT,DIV,SIN,COS,TAN,J,EXP,POW}






