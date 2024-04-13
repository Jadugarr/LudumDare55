using System;
using UnityEngine;

namespace PotatoFinch.LudumDare55.Localization {
	[Serializable]
	public struct LocalizationData {
		[SerializeField] private LanguageCode _languageCode;
		[SerializeField] private string _text;

		public LanguageCode LanguageCode => _languageCode;

		public string Text => _text;
	}
}