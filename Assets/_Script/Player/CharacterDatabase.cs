using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterDatabase : ScriptableObject
{
    public Character[] charactor;

    public int CharacterCount
    {
        get
        {
            return charactor.Length;
        }
    }

    public Character GetCharactor(int index)
    {
        return charactor[index];
    }
}
