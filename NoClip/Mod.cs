using Kitchen;
using KitchenMods;
using UnityEngine;

namespace NoClip
{
    public class NoClipSystem : GenericSystemBase, IModSystem {
        private const int LayerPlayers = 12;
        private const int LayerStatics = 9;
        private const int LayerDefault = 0;
        private bool _hasBeenPrepTime = false;

        //protected override void Initialise()
        //{
        //    base.Initialise();

        //    // print layer names
        //    for (int i = 0; i < 16; i++)
        //    {
        //        Debug.Log($"NoClip Mod: Layer {i}: {LayerMask.LayerToName(i)}");
        //    }
        //}

        private void OnPrepTimeSwitch(bool isNowPrepTime)
        {
            // ignore collision only in prep phase
            // turn collision (back) on if not prep phase
            Debug.Log($"NoClip Mod: NoClip is now {(isNowPrepTime ? "on" : "off")}.");
            Physics.IgnoreLayerCollision(LayerPlayers, LayerDefault, isNowPrepTime);
            Physics.IgnoreLayerCollision(LayerPlayers, LayerStatics, isNowPrepTime);
        }

        protected override void OnUpdate() {
            if (GameInfo.IsPreparationTime != _hasBeenPrepTime)
            {
                _hasBeenPrepTime = !_hasBeenPrepTime;
                OnPrepTimeSwitch(_hasBeenPrepTime);
            }
        }
    }
}
