using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TxtLoader : MonoBehaviour
{
    public TextAsset textFile;

    public List<string> WordsList()
    {
        return textFile.text.Split("\n").ToList();
    }
}
