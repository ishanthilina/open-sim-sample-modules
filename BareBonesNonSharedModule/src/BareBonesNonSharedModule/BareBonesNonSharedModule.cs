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
 
[assembly: Addin("BareBonesNonSharedModule", "0.1")]
[assembly: AddinDependency("OpenSim", "0.5")]
 
namespace OpenSim.Region.OptionalModules.Example.BareBonesNonShared
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
    [Extension(Path = "/OpenSim/RegionModules", NodeName = "RegionModule", Id = "BareBonesNonSharedModule")]
    public class BareBonesNonSharedModule : INonSharedRegionModule
    {
        private static readonly ILog m_log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        List<Scene> m_scenes = new List<Scene>();
        Dictionary<Scene, List<SceneObjectGroup>> scene_prims = new Dictionary<Scene, List<SceneObjectGroup>>();

        int counter = 0;
        bool positive = true;

        //#region IRegionModule interface
		
		public string Name { get { return "Bare Bones Non Shared Module"; } }        
 
        public Type ReplaceableInterface { get { return null; } }
 
        public void Initialise(IConfigSource source)
        {
            //m_log.DebugFormat("[BARE BONES]: INITIALIZED MODULE");
			
			m_log.Info("[HELLO  WORLD] Initializing...");

            
        }
 
        public void Close()
        {
            m_log.DebugFormat("[HELLO  WORLD] : : CLOSED MODULE");
        }
 
        public void AddRegion(Scene scene)
        {
			m_scenes.Add(scene);
            m_log.DebugFormat("[HELLO  WORLD] : : REGION {0} ADDED", scene.RegionInfo.RegionName);
        }
 
        public void RemoveRegion(Scene scene)
        {
            m_log.DebugFormat("[HELLO  WORLD] : : REGION {0} REMOVED", scene.RegionInfo.RegionName);
        }        
 
        public void RegionLoaded(Scene scene)
        {
			
			foreach (Scene s in m_scenes)
                DoHelloWorld(s);
            m_log.DebugFormat("[HELLO  WORLD] : : REGION {0} LOADED", scene.RegionInfo.RegionName);
        }              
		
		
		void DoHelloWorld(Scene scene)
        {
            // We're going to write HELLO with prims
			
			m_log.Info("[HELLO  WORLD] : : Hello World Starting...");

            List<SceneObjectGroup> prims = new List<SceneObjectGroup>();
            // First prim: |
            Vector3 pos = new Vector3(120, 128, 30);
            SceneObjectGroup sog = new SceneObjectGroup(UUID.Zero, pos, PrimitiveBaseShape.CreateBox());
            sog.RootPart.Scale = new Vector3(0.3f, 0.3f, 2f);
            prims.Add(sog);

            // Second prim: -
            pos = new Vector3(120.5f, 128f, 30f);
            sog = new SceneObjectGroup(UUID.Zero, pos, PrimitiveBaseShape.CreateBox());
            sog.RootPart.Scale = new Vector3(1, 0.3f, 0.3f);
            prims.Add(sog);

            // Third prim: |
            pos = new Vector3(121, 128, 30);
            sog = new SceneObjectGroup(UUID.Zero, pos, PrimitiveBaseShape.CreateBox());
            sog.RootPart.Scale = new Vector3(0.3f, 0.3f, 2);
            prims.Add(sog);

            // Fourth prim: |
            pos = new Vector3(122, 128, 30);
            sog = new SceneObjectGroup(UUID.Zero, pos, PrimitiveBaseShape.CreateBox());
            sog.RootPart.Scale = new Vector3(0.3f, 0.3f, 2);
            prims.Add(sog);

            // Fifth prim: - (up)
            pos = new Vector3(122.5f, 128, 31);
            sog = new SceneObjectGroup(UUID.Zero, pos, PrimitiveBaseShape.CreateBox());
            sog.RootPart.Scale = new Vector3(1, 0.3f, 0.3f);
            prims.Add(sog);

            // Sixth prim: - (middle)
            pos = new Vector3(122.5f, 128, 30);
            sog = new SceneObjectGroup(UUID.Zero, pos, PrimitiveBaseShape.CreateBox());
            sog.RootPart.Scale = new Vector3(1, 0.3f, 0.3f);
            prims.Add(sog);

            // Seventh prim: - (low)
            pos = new Vector3(122.5f, 128, 29);
            sog = new SceneObjectGroup(UUID.Zero, pos, PrimitiveBaseShape.CreateBox());
            sog.RootPart.Scale = new Vector3(1, 0.3f, 0.3f);
            prims.Add(sog);

            // Eighth prim: | 
            pos = new Vector3(124, 128, 30);
            sog = new SceneObjectGroup(UUID.Zero, pos, PrimitiveBaseShape.CreateBox());
            sog.RootPart.Scale = new Vector3(0.3f, 0.3f, 2);
            prims.Add(sog);

            // Ninth prim: _
            pos = new Vector3(124.5f, 128, 29);
            sog = new SceneObjectGroup(UUID.Zero, pos, PrimitiveBaseShape.CreateBox());
            sog.RootPart.Scale = new Vector3(1, 0.3f, 0.3f);
            prims.Add(sog);

            // Tenth prim: | 
            pos = new Vector3(126, 128, 30);
            sog = new SceneObjectGroup(UUID.Zero, pos, PrimitiveBaseShape.CreateBox());
            sog.RootPart.Scale = new Vector3(0.3f, 0.3f, 2);
            prims.Add(sog);

            // Eleventh prim: _
            pos = new Vector3(126.5f, 128, 29);
            sog = new SceneObjectGroup(UUID.Zero, pos, PrimitiveBaseShape.CreateBox());
            sog.RootPart.Scale = new Vector3(1, 0.3f, 0.3f);
            prims.Add(sog);

            // Twelveth prim: O
            pos = new Vector3(129, 128, 30);
            sog = new SceneObjectGroup(UUID.Zero, pos, PrimitiveBaseShape.CreateBox());
            sog.RootPart.Scale = new Vector3(2, 0.3f, 2); 
            prims.Add(sog);

            // Add these to the managed objects
            scene_prims.Add(scene, prims);

            // Now place them visibly on the scene
            foreach (SceneObjectGroup sogr in prims)
            {
                scene.AddNewSceneObject(sogr, false);
            }
        }

		
		
		void OnTick()
        {
            if (counter++ % 50 == 0)
            {
                // Uncomment if you want to see this on your console
                m_log.Debug("[HELLO  WORLD] Tick!");
                foreach (KeyValuePair<Scene, List<SceneObjectGroup>> kvp in scene_prims)
                {
                    foreach (SceneObjectGroup sog in kvp.Value)
                    {
                        if (positive)
                            sog.AbsolutePosition += new Vector3(5, 5, 0);
                        else
                            sog.AbsolutePosition += new Vector3(-5, -5, 0);
                        sog.ScheduleGroupForTerseUpdate();
                    }
                }
                positive = !positive;
            }
        }
		
		
    }
}