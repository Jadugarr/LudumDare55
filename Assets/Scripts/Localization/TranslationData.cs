using System;
using UnityEngine;

namespace PotatoFinch.LudumDare55.Localization {
	[Serializable]
	public class TranslationData {
		[SerializeField] private LanguageCodeValue _languageCodeValue;
		[SerializeField] private string _translation;

		public LanguageCodeValue LanguageCodeValue => _languageCodeValue;

		public string Translation => _translation;
	}
}