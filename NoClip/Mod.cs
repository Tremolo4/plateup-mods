using Kitchen;
using KitchenMods;
using UnityEngine;
using Unity.Collections;
using Unity.Entities;

namespace NoClip
{
    public class NoClipSystem : GenericSystemBase, IModSystem {
        private const int LayerPlayers = 12;
        private const int LayerStatics = 9;
        private const int LayerDefault = 0;
        private bool _hasBeenNightTime = false;

        //protected override void Initialise()
        //{
        //    base.Initialise();

        //    // print layer names
        //    for (int i = 0; i < 16; i++)
        //    {
        //        Debug.Log($"NoClip Mod: Layer {i}: {LayerMask.LayerToName(i)}");
        //    }
        //}

        private void OnNightTimeSwitch(bool isNowNightTime)
        {
            // prep phase is called night time. ignore collision only in prep phase
            // turn collision (back) on if not night time
            Debug.Log($"NoClip Mod: NoClip is now {(isNowNightTime ? "on" : "off")}.");
            Physics.IgnoreLayerCollision(LayerPlayers, LayerDefault, isNowNightTime);
            Physics.IgnoreLayerCollision(LayerPlayers, LayerStatics, isNowNightTime);
        }

        protected override void OnUpdate() {
            if (this.HasSingleton<SIsNightTime>() != _hasBeenNightTime)
            {
                _hasBeenNightTime = !_hasBeenNightTime;
                OnNightTimeSwitch(_hasBeenNightTime);
            }
        }
    }
}
