using System;
using System.Reflection;
using System.Collections.Generic;

using OpenMetaverse;
using log4net;
using Mono.Addins;
using Nini.Config;
using OpenSim.Region.Framework.Interfaces;
using OpenSim.Region.Framework.Scenes;
using OpenSim.Framework;
 
[assembly: Addin("NonSharedRegionModuleTemplate", "0.1")]
[assembly: AddinDependency("OpenSim", "0.5")]
 
namespace OpenSim.Region.OptionalModules.Example.NonSharedRegionModuleTemplate
{
    /// <summary>
    /// Simplest possible example of a non-shared region module.
    /// </summary>
    /// <remarks>
    /// This module is the simplest possible example of a non-shared region module (a module where each scene/region
    /// in the simulator has its own copy).
    ///
    /// When the module is enabled it will print messages when it receives certain events to the screen and the log
    /// file.
    /// </remarks>
    [Extension(Path = "/OpenSim/RegionModules", NodeName = "RegionModule", Id = "NonSharedRegionModuleTemplate")]
    public class TemplateModule : INonSharedRegionModule
    {
        private static readonly ILog m_log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
		
		public string Name { get { return "NonSharedRegionModuleTemplate"; } }        
 
        public Type ReplaceableInterface { get { return null; } }
 
		// Called immediately after the module is loaded for a given region
        // i.e. Immediately after instance creation.
        public void Initialise(IConfigSource source)
        {			
			m_log.Info("[HELLO  WORLD] : : INITIALIZING...");
        }
 
		//This method will be invoked when the sim is closing down.
        public void Close()
        {
            m_log.DebugFormat("[HELLO  WORLD] : : CLOSED MODULE");
        }
 
		//This method is called when a region is added to the module. 
        public void AddRegion(Scene scene)
        {
            m_log.DebugFormat("[HELLO  WORLD] : : REGION {0} ADDED", scene.RegionInfo.RegionName);
        }
 
		//Called when a region is removed from a module.
        public void RemoveRegion(Scene scene)
        {
            m_log.DebugFormat("[HELLO  WORLD] : : REGION {0} REMOVED", scene.RegionInfo.RegionName);
        }        
 
		//Called when all modules have been added for a particular scene/region
        public void RegionLoaded(Scene scene)
        {
            m_log.DebugFormat("[HELLO  WORLD] : : REGION {0} LOADED", scene.RegionInfo.RegionName);
        }              
		
		
    }
}