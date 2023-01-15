using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Scriptable/PlayableAsset")]

public class PlayableAsset : ScriptableObject
{
    
    public string[] properties;
    public AnimationCurve[] curve;

}
