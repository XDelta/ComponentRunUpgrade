using Elements.Core;

using FrooxEngine;
using FrooxEngine.UIX;

using HarmonyLib;

using ResoniteModLoader;

namespace ComponentRunUpgrade;
public class ComponentRunUpgrade : ResoniteMod {
	internal const string VERSION_CONSTANT = "1.0.0"; //Changing the version here updates it in all locations needed
	public override string Name => "ComponentRunUpgrade";
	public override string Author => "Delta";
	public override string Version => VERSION_CONSTANT;
	public override string Link => "https://github.com/XDelta/ComponentRunUpgrade";

	public override void OnEngineInit() {
		CustomUILib.CustomUILib.AddCustomInspectorAfter<RadiantDashScreen>(BuildInspectorUI);
	}

	private static void BuildInspectorUI(RadiantDashScreen instance, UIBuilder ui) {
		ui.Button("ComponentRunUpgrade.RunUpgrade".AsLocaleKey()).LocalPressed += (_, _) => {
			AccessTools.Method(typeof(RadiantDashScreen), "CleanupOldComponents").Invoke(instance, [RadiantDashScreen.DASH_SCREENS_CLEANUP_VERSION]);
		};
	}
}
