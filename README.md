# Xamarin-Theme-Script
A simple script to add multiple themes to your xamarin forms app.

## Steps
1. Add the ThemeManager.cs to your code **with your corresponding namespace** .
2. Initialize the the ThemeManager Class with the keys of your choice.

        var keys = new List<string>() { "Primary", "Secondary", "Tertiary" };
        var manager = ThemeManager.Init(keys);
    The Keys are the strings you put in your XAML code:
        
        Button Margin="0,10,0,0" Text="NextTheme"
                Command="{Binding OpenWebCommand}"
                BackgroundColor="{DynamicResource Primary}"/>
    **Warning: Keys are case sensitive**
3. Add a Theme by giving it a name and passing colors.

        var manager = ThemeManager.Instance();
        manager.AddTheme("Theme1", new List<Color>() { Color.Blue, Color.Chartreuse, Color.Green });
    **Note: Colors count must match keys count.**
    
     **Note: The first key is matched to the first color, if you'd like another mapping, create another data structure with the appropriate iterator.**  
    
4. Use the SetTheme method to change the theme.
    
        var manager = ThemeManager.Instance();
        manager.SetTheme("Theme1");

5. Results: ![](https://github.com/WAELKASSEM/Xamarin-Theme-Script/blob/main/Themes.jpg)
