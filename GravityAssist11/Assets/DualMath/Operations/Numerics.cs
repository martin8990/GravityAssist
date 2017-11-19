public class Numerics
{
    public static Operation Find(string token)
    {
        float n;
        bool isNumeric = float.TryParse(token, out n);
        if (isNumeric)
        {
            
            var Operation = new Operation(0,(op) => n);
            return Operation;
        }
        else
        {
            return Operators.Find(token);
        }

    }
}





