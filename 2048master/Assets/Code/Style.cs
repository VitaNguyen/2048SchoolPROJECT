using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

public class StyleData 
{ 
    public Text number;
    public Color32 BGColor;
    public Color32 TextColor;
}
public class Style : MonoBehaviour
{

    

    public StyleData[] StyleData;
}
