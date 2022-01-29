using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

namespace Lab.Scripts.Util
{
    public class LocaleDropdown : MonoBehaviour
    {
        public Dropdown dropdown;

        private IEnumerator Start()
        {
            // Wait for the localization system to initialize
            yield return LocalizationSettings.InitializationOperation;

            // Generate list of available Locales
            var options = new List<Dropdown.OptionData>();
            int selected = 0;
            for (int i = 0; i < LocalizationSettings.AvailableLocales.Locales.Count; ++i)
            {
                var locale = LocalizationSettings.AvailableLocales.Locales[i];
                if (LocalizationSettings.SelectedLocale == locale)
                    selected = i;
                options.Add(new Dropdown.OptionData(locale.name));
            }
            dropdown.options = options;

            dropdown.value = selected;
            dropdown.onValueChanged.AddListener(LocaleSelected);
        }

        private static void LocaleSelected(int index)
        {
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
            PlayerPrefs.SetString("Language", LocalizationSettings.SelectedLocale.Identifier.Code);
        }
    }
}