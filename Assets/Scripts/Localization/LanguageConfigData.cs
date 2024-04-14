using System;
using UnityEngine.AddressableAssets;

namespace PotatoFinch.LudumDare55.Localization {
	[Serializable]
	public struct LanguageConfigData {
		public LanguageCodeValue LanguageCode;
		public AssetReference LanguageFlagAssetReference;
	}
}