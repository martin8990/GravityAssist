public class Numerics
{
    public static Operation Find(string token,int prioBoost)
    {
        float n;
        bool isNumeric = float.TryParse(token, out n);
        if (isNumeric)
        {
            
            var Operation = new Operation(0,(op) => new FLOAT32(n));
            return Operation;
        }
        else
        {
            return Operators.Find(token, prioBoost);
        }

    }
}





