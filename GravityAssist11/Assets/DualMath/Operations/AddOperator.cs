public class AddOperator : token
{
    public AddOperator(int bonus)
    {
        prio = 1 + bonus;
    }
    public override float CalcFloat()
    {
        float result = 0;
        foreach (var child in kids)
        {
            result += child.CalcFloat();
        }
        return result;
    }

    public override float[] CalcFloatArr()
    {
        var r1 = kids[0].CalcFloatArr();
        var r2 = kids[1].CalcFloatArr();
        if (r1 != null && r2 != null)
        {
            if (r1.Length == 1)
            {
                for (int i = 0; i < r2.Length; i++)
                {
                    r2[i] = r2[i] + r1[0];
                    
                }
                return r2;
            }
            else if (r2.Length == 1)
            {
                for (int i = 0; i < r1.Length; i++)
                {
                    r1[i] = r1[i] + r2[0];
                    
                }
                return r1;
            }
            else if (r1.Length == r2.Length)
            {
                for (int i = 0; i < r1.Length; i++)
                {
                    r1[i] = r1[i] + r2[i];
                    
                }
                return r1;
            }
            else
            {
                return null;
            }

        }
        else
        {
            return null;
        }
    }

    public override int CalcInt()
    {
        int result = 0;
        foreach (var child in kids)
        {
            result += child.CalcInt();
        }
        return result;
    }

    public override int[] CalcIntArr()
    {
        var r1 = kids[0].CalcIntArr();
        var r2 = kids[1].CalcIntArr();
        if (r1 != null && r2 != null)
        {
            if (r1.Length == 1)
            {
                for (int i = 0; i < r2.Length; i++)
                {
                    r2[i] = r2[i] + r1[0];

                }
                return r2;
            }
            else if (r2.Length == 1)
            {
                for (int i = 0; i < r1.Length; i++)
                {
                    r1[i] = r1[i] + r2[0];

                }
                return r1;
            }
            else if (r1.Length == r2.Length)
            {
                for (int i = 0; i < r1.Length; i++)
                {
                    r1[i] = r1[i] + r2[i];

                }
                return r1;
            }
            else
            {
                return null;
            }

        }
        else
        {
            return null;
        }
    }
}







