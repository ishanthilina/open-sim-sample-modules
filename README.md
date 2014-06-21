How To Add A Module
--------------------
* Copy the required module's folder to the **{opensim-root}/addon-modules** folder (not the {opensim-root}/bin/addon-modules folder).
* Uncomment the line that starts with **[Extension(Path = "/OpenSim/RegionModules", NodeName = "RegionModule", Id = ..** of the main C# file inside the folder.
* Run the **./runprebuild.sh** command from {opensim-root}.
* Then run **xbuild** or **nant** command from {opensim-root}.

About Modules
--------------
####NonSharedRegionModuleTemplate

A template module that can be used to customize. When built and deployed, it will output log messages to the opensim console output.


####HelloWorldPrimsModule

Shows a 3D **Hello** message in the region. Original source code was obtained from [Getting Started with Region Modules][1] tutorial of the Opensim wiki and modified.

  [1]: http://opensimulator.org/wiki/Getting_Started_with_Region_Modules