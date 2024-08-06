using System;
using System.Collections.ObjectModel;
using System.Linq;
using Assets.Scripts;
using Assets.Scripts.Objects;
using Assets.Scripts.UI;
using HarmonyLib;
using StationeersMods.Interface;
using UnityEngine;
using UnityEngine.Rendering;

namespace compassmod
{
    [HarmonyPatch]
    public class PrefabPatch
    {
        public static ReadOnlyCollection<GameObject> prefabs { get; set; }
       

        [HarmonyPatch(typeof(PlayerStateWindow), "Awake")]
        [HarmonyPostfix]
        public static void PostfixAwake(PlayerStateWindow __instance)
        {
            GameObject compassGameObject =
                prefabs.First(prefab => prefab.name.Equals("Compass"));
            Debug.Log("prefab name:" + compassGameObject.name);
            Compass compass = compassGameObject.GetComponent<Compass>();
            Compass instantiate = UnityEngine.Object.Instantiate(compass);
            instantiate.transform.SetParent(__instance.transform.parent);
        }
    }
}