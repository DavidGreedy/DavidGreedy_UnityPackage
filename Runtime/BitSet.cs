using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitSet
{
    private int bits;

    public BitSet()
    {
        bits = 0;
    }

    public BitSet(int value)
    {
        bits = value;
    }

    public void Set(int bit)
    {
        bits |= 1 << bit;
    }

    public void Clear(int bit)
    {
        bits &= ~(1 << bit);
    }

    public void Toggle(int bit)
    {
        bits ^= 1 << bit;
    }

    public bool this[int bit]
    {
        get
        {
            return ((bits >> bit) & 1) == 1;
        }

        set
        {
            if (value)
            {
                Set(bit);
            }
            else
            {
                Clear(bit);
            }
        }
    }

    public static implicit operator int(BitSet bitSet)
    {
        return bitSet.bits;
    }

    public static implicit operator BitSet(int value)
    {
        return new BitSet(value);
    }

    public bool[] ToArray()
    {
        bool[] bools = new bool[sizeof(int) * 8];

        for (int i = 0; i < bools.Length; i++)
        {
            bools[i] = this[i];
        }

        return bools;
    }

    public override string ToString()
    {
        string s = "";
        for (int i = 0; i < sizeof(int) * 8; i++)
        {
            s += this[i] ? 1 : 0;
        }
        return s;
    }
}