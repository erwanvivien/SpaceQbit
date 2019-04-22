using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBindArray : MonoBehaviour
{
    public KeyCode[] _keyBindings = new KeyCode[60];

    // Start is called before the first frame update
    void Start()
    {
        _keyBindings[00] = KeyCode.RightArrow;
        _keyBindings[01] = KeyCode.UpArrow;
        _keyBindings[02] = KeyCode.LeftArrow;
        _keyBindings[03] = KeyCode.DownArrow;
        _keyBindings[04] = KeyCode.A;
        _keyBindings[05] = KeyCode.B;
        _keyBindings[06] = KeyCode.C;
        _keyBindings[07] = KeyCode.D;
        _keyBindings[08] = KeyCode.E;
        _keyBindings[09] = KeyCode.F;

        _keyBindings[10] = KeyCode.G;
        _keyBindings[11] = KeyCode.H;
        _keyBindings[12] = KeyCode.I;
        _keyBindings[13] = KeyCode.J;
        _keyBindings[14] = KeyCode.K;
        _keyBindings[15] = KeyCode.L;
        _keyBindings[16] = KeyCode.M;
        _keyBindings[17] = KeyCode.O;
        _keyBindings[18] = KeyCode.P;
        _keyBindings[19] = KeyCode.Q;

        _keyBindings[20] = KeyCode.R;
        _keyBindings[21] = KeyCode.S;
        _keyBindings[22] = KeyCode.T;
        _keyBindings[23] = KeyCode.U;
        _keyBindings[24] = KeyCode.V;
        _keyBindings[25] = KeyCode.W;
        _keyBindings[26] = KeyCode.X;
        _keyBindings[27] = KeyCode.Y;
        _keyBindings[28] = KeyCode.Z;
        _keyBindings[29] = KeyCode.Space;

        _keyBindings[30] = KeyCode.LeftShift;
        _keyBindings[31] = KeyCode.RightShift;
        _keyBindings[32] = KeyCode.Tab;
        _keyBindings[33] = KeyCode.LeftAlt;
        _keyBindings[34] = KeyCode.Alpha1;
        _keyBindings[35] = KeyCode.Alpha2;
        _keyBindings[36] = KeyCode.Alpha3;
        _keyBindings[37] = KeyCode.Alpha4;
        _keyBindings[38] = KeyCode.Alpha5;
        _keyBindings[39] = KeyCode.Alpha6;

        _keyBindings[40] = KeyCode.Alpha7;
        _keyBindings[41] = KeyCode.Alpha8;
        _keyBindings[42] = KeyCode.Alpha9;
        _keyBindings[43] = KeyCode.Alpha0;
        _keyBindings[44] = KeyCode.RightBracket;
        _keyBindings[45] = KeyCode.Plus;
        _keyBindings[46] = KeyCode.None; // MANQUE UNE TOUCHE
        _keyBindings[47] = KeyCode.Return;
        _keyBindings[48] = KeyCode.Backspace;
        _keyBindings[49] = KeyCode.Asterisk;

        _keyBindings[50] = KeyCode.Keypad0;
        _keyBindings[51] = KeyCode.Keypad1;
        _keyBindings[52] = KeyCode.Keypad2;
        _keyBindings[53] = KeyCode.Keypad3;
        _keyBindings[54] = KeyCode.Keypad4;
        _keyBindings[55] = KeyCode.Keypad5;
        _keyBindings[56] = KeyCode.Keypad6;
        _keyBindings[57] = KeyCode.Keypad7;
        _keyBindings[58] = KeyCode.Keypad8;
        _keyBindings[59] = KeyCode.Keypad9;
    }
}