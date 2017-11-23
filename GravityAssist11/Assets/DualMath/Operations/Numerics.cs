public static class NumericsFinder
{
    public static token Find(string token, int prioBoost)
    {
        int l;
        bool isInt = int.TryParse(token, out l);

        float n;
        bool isFloat = float.TryParse(token, out n);

        if (isInt)
        {
            var Operation = new IntOp(l);
            return Operation;
        }
        else if (isFloat)
        {
            var Operation = new FloatOp(n);
            return Operation;
        }
        else
        {
            return Operators.Find(token, prioBoost);
        }
    }

}

public class FloatOp : token
{
    float val;

    public FloatOp(float val)
    {
        this.val = val;
        this.type = dType.FLOAT32;
    }

    public override float ECalcFloat()
    {
        return val;
    }

    public override float[] CalcFloatArr()
    {
        return new float[] { val };
    }

    public override int CalcInt()
    {
        
        return 0;
    }

    public override int[] CalcIntArr()
    {
       return null;
    }
}
public class IntOp : token
{
    int val;

    public IntOp(int val)
    {
        this.val = val;
        this.type = dType.INT32;
    }


    public override float CalcFloat()
    {
        return val;
    }

    public override float[] CalcFloatArr()
    {
        return new float[] {val };
    }

    public override int CalcInt()
    {
        return val;
    }

    public override int[] CalcIntArr()
    {
        return new int[] { val };
    }
}





