using Il2Cpp;
using MelonLoader;

[assembly: MelonInfo(typeof(ToggleItemRenderer.Core), "ToggleItemRenderer", "2.0.0", "Jayden", null)]
[assembly: MelonGame("Notional Games", "Beltmatic")]

namespace ToggleItemRenderer
{
    public class Core : MelonMod
    {
        private bool enabled = true;

        public override void OnUpdate()
        {
            if (UnityEngine.InputSystem.Keyboard.current.tKey.wasPressedThisFrame)
            {
                enabled = !enabled;
            }

            GameManager.Instance.GetComponent<ItemRenderer>().enabled = enabled;
            GameManager.Instance.GetComponent<BuildingFlashRenderer>().enabled = enabled;
            GameManager.Instance.GetComponent<BeltRenderer2>().enabled = enabled;
        }
    }
}