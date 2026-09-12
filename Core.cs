using Il2Cpp;
using MelonLoader;
using UnityEngine;
using UnityEngine.SceneManagement;

[assembly: MelonInfo(typeof(ToggleItemRenderer.Core), "ToggleItemRenderer", "1.0.0", "Jayden", null)]
[assembly: MelonGame("Notional Games", "Beltmatic")]

namespace ToggleItemRenderer
{
    public class Core : MelonMod
    {
        private Rect window = new(10, 10, 150, 55);
        private bool on = true;
        private ItemRenderer itemRenderer;
        private BuildingFlashRenderer buildingFlashRenderer;
        private BeltRenderer2 beltRenderer;
        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("Initialized.");
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            GameObject dummy = new();
            UnityEngine.Object.DontDestroyOnLoad(dummy);
            Scene ddolScene = dummy.scene;
            UnityEngine.Object.Destroy(dummy);
            GameObject gameManagerGO = null;
            var rootObjects = ddolScene.GetRootGameObjects();
            foreach (var GO in rootObjects)
            {
                if (GO != null && GO.name == "GameManager")
                {
                    gameManagerGO = GO;
                    break;
                }
            }
            var gameManagerScript = gameManagerGO.GetComponent<GameManager>();
            itemRenderer = gameManagerScript.GetComponent<ItemRenderer>();
            buildingFlashRenderer = gameManagerScript.GetComponent<BuildingFlashRenderer>();
            beltRenderer = gameManagerScript.GetComponent<BeltRenderer2>();
        }

        public override void OnUpdate()
        {
            if (itemRenderer == null) return;

            itemRenderer.enabled = on;

            if (buildingFlashRenderer == null) return;

            buildingFlashRenderer.enabled = on;

            if (beltRenderer == null) return;

            beltRenderer.enabled = on;
        }

        public override void OnGUI()
        {
            window = GUI.Window(63464, window, (GUI.WindowFunction)DrawWindow, "Item Renderer");
        }

        private void DrawWindow(int id)
        {
            GUI.DragWindow(new Rect(0, 0, 150, 20));

            on = GUI.Toggle(new Rect(15, 25, 150, 20), on, "Enabled?");
        }
    }
}