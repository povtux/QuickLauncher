# QuickLauncher
Plugin based tray icon based app to embed micro-apps

this app does nearly nothing by itself... It displays an icon in the systray of windows and, when the icon is clicked, displays a minimalistic frame with UserControl embeded via a plugin mechanisme.
An example of UserControl is at https://github.com/povtux/ShortcutPlugin
This plugin loads an XML document via a WebClient on a webserver and displays a list of shortcuts. Those shortcuts can be web URLs or programs to execute. For more explanation, go to the plugin repo.

Plugins must have a class that implements the specific interface described in https://github.com/povtux/LauncherPlugin
