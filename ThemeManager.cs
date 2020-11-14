using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace <YOUR NAMESPACE HERE>
{
    sealed class ThemeManager
    {
        /*-----Singleton Region----*/
        private static ThemeManager Manager;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keys">Keys to be used in XAML. For Example: "Primary","Accent", etc</param>
        /// <returns>The single instance</returns>
        public static ThemeManager Init(IEnumerable<string> keys)
        {
            if (Manager == null)
            {
                Manager = new ThemeManager(keys);
            }
            return Manager;

        }
        public static ThemeManager Instance()
        {
            if (Manager == null)
                throw new Exception("Theme Manager not Initialized, use the Init Function");
            return Manager;

        }
        /*------End of Singleton ----*/

        private readonly ResourceDictionary ThemeDefaultKeys = new ResourceDictionary();
        private readonly Dictionary<string, IEnumerable<Color>> Themes = new Dictionary<string, IEnumerable<Color>>();
        public IEnumerable<string> Keys => ThemeDefaultKeys.Keys;
        public string CurrentTheme { get; private set; }
        private ThemeManager(IEnumerable<string> keys)
        {
            if (keys.Distinct().Count() != keys.Count())
                throw new Exception("Keys Contain Duplicate Values.");
            foreach (var K in keys)
            {
                if (!K.All(c => char.IsLetter(c)))
                    throw new Exception("Only Letters are allowed.");
                ThemeDefaultKeys.Add(K, Color.Transparent);
            }
            Application.Current.Resources.MergedDictionaries.Add(ThemeDefaultKeys);
            CurrentTheme = String.Empty;
        }

        /// <summary>
        /// Changes the active theme, the required theme reference must be added Once using the AddTheme method. 
        /// </summary>
        /// <param name="theme_name"></param>
        public void SetTheme(string theme_name)
        {
            if (!Themes.ContainsKey(theme_name))
                throw new Exception("Theme does not Exist.");
            var theme = Themes[theme_name];
            var it = theme.GetEnumerator();
            foreach (var key in ThemeDefaultKeys.Keys)
            {
                it.MoveNext();
                Application.Current.Resources[key] = it.Current;
            }
            CurrentTheme = theme_name;

        }
        public void AddTheme(string name, IEnumerable<Color> colors)
        {
            if (colors.Count() != ThemeDefaultKeys.Keys.Count)
                throw new Exception("The amount of colors does not match the keys count.");
            if (Themes.ContainsKey(name))
                throw new Exception("A theme with the same name already exists.");
            Themes.Add(name, colors);
        }




    }
}
