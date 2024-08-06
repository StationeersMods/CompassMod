using System;
using compassmod;
using HarmonyLib;
using StationeersMods.Interface;

public class CompassMod : ModBehaviour
{
    public override void OnLoaded(ContentHandler contentHandler)
    {
        UnityEngine.Debug.Log("Hello World!");
        Harmony harmony = new Harmony("CompassMod");
        PrefabPatch.prefabs = contentHandler.prefabs;
        harmony.PatchAll();
        UnityEngine.Debug.Log("CompassMod Loaded with " + contentHandler.prefabs.Count + " prefab(s)");
    }
}