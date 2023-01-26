using System;

[Serializable]
public class FloatReference 
{
    public bool useConstant;
    public float constantValue;
    public FloatVariable variable;

    public float Value
    {
        get 
        {
            if(useConstant)
            {
                return constantValue;
            }
            else
            {
                return variable.Value;
            }
        }
    }
}
