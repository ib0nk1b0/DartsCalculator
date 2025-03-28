workspace "DartsCalculator"
  architecture "x86_64"
  startproject "DartsCalculator"

  configurations
  {
    "Debug",
    "Release"
  }

outputdir = "%{cfg.buildcfg}-%{cfg.system}-%{cfg.architecture}"

project "DartsCalculator"
  kind "SharedLib"
  language "C#"
  dotnetframework "4.7.2"

  targetdir ("../OpenEngine-Editor/Resources/Scripts")
	objdir ("../OpenEngine-Editor/Resources/Scripts/Intermediates")

  files
  {
    "Source/**.cs",
    "Properties/**.cs"
  }
    
  filter "configurations:Debug"
    optimize "Off"
    symbols "Default"

  filter "configurations:Release"
    optimize "On"
    symbols "Default"

  filter "configurations:Dist"
    optimize "Full"
    symbols "Off"