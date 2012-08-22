using System;

/// 
/// A four-character-code is a quasi-human-readable 32-bit-id.
/// 
/// 
public struct FourCC
{
    private string _value;

    public string Value
    {
        get { return _value; }
    }

    public static implicit operator int(FourCC d)
    {
        return ToFourCC(d.Value);
    }

    public static implicit operator string(FourCC d)
    {
        return d.Value;
    }

    public static implicit operator FourCC(string d)
    {
        return new FourCC { _value = d };
    }

    public static implicit operator FourCC(int d)
    {
        return FromFourCC(d);
    }

    public override string ToString()
    {
        return this.Value;
    }

    private static string FromFourCC(int FourCC)
    {
        char[] chars = new char[4];
        chars[0] = (char)(FourCC & 0xFF);
        chars[1] = (char)((FourCC >> 8) & 0xFF);
        chars[2] = (char)((FourCC >> 16) & 0xFF);
        chars[3] = (char)((FourCC >> 24) & 0xFF);

        return new string(chars);
    }

    private static int ToFourCC(string FourCC)
    {
        if (FourCC.Length != 4)
        {
            throw new Exception("FourCC strings must be 4 characters long " + FourCC);
        }

        int result = ((int)FourCC[3]) << 24
                    | ((int)FourCC[2]) << 16
                    | ((int)FourCC[1]) << 8
                    | ((int)FourCC[0]);

        return result;
    }

    private static int ToFourCC(char[] FourCC)
    {
        if (FourCC.Length != 4)
        {
            throw new Exception("FourCC char arrays must be 4 characters long " + new string(FourCC));
        }

        int result = ((int)FourCC[3]) << 24
                    | ((int)FourCC[2]) << 16
                    | ((int)FourCC[1]) << 8
                    | ((int)FourCC[0]);

        return result;
    }

    private static int ToFourCC(char c0, char c1, char c2, char c3)
    {
        int result = ((int)c3) << 24
                    | ((int)c2) << 16
                    | ((int)c1) << 8
                    | ((int)c0);

        return result;
    }
}
