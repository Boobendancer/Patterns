using System.Collections.Generic;

namespace XD
{
    public class StaticContainer
    {
        private static StaticContainer instance = null;
        public static StaticContainer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StaticContainer();
                }

                return instance;
            }
        }

        private Dictionary<int, IStatic> staticContainer = new Dictionary<int, IStatic>();

        public static IStatic Get(StaticType staticType)
        {
            IStatic result = null;
            int type = (int)staticType;
            if (!Instance.staticContainer.TryGetValue(type, out result))
            {
                result = new Empty();
            }
            return result;
        }

        public static T Get<T>(StaticType staticType) where T : IStatic
        {
            return (T)Get(staticType);
        }

        public static void Set(StaticType staticType, IStatic staticObject)
        {
            int type = (int)staticType;
            if (Instance.staticContainer.ContainsKey(type))
            {
                if (staticObject != null)
                {
                    Instance.staticContainer[type] = staticObject;
                }
                else
                {
                    Instance.staticContainer.Remove(type);
                }
            }
            else
            {
                Instance.staticContainer.Add(type, staticObject);
            }
        }

        public static ILocalization Localization
        {
            get
            {
                return Get<ILocalization>(StaticType.Localization);
            }
            set
            {
                Set(StaticType.Localization, value);
            }
        }

        public static IEffects Effects
        {
            get
            {
                return Get<IEffects>(StaticType.Effects);
            }
            set
            {
                Set(StaticType.Effects, value);
            }
        }

        public static IItemsFactory ItemsFactory
        {
            get;
            set;
        }

        public static ISceneManager SceneManager
        {
            get
            {
                return Get<ISceneManager>(StaticType.SceneManager);
            }
            set
            {
                Set(StaticType.SceneManager, value);
            }
        }

        public static IRankSystem RankSystem
        {
            get
            {
                return Get<IRankSystem>(StaticType.RankSystem);
            }
            set
            {
                Set(StaticType.RankSystem, value);
            }
        }

        public static IStatistics Statistics
        {
            get
            {
                return Get<IStatistics>(StaticType.Statistics);
            }
            set
            {
                Set(StaticType.Statistics, value);
            }
        }

        public static IConnector Connector
        {
            get
            {
                return Get<IConnector>(StaticType.Connector);
            }
            set
            {
                Set(StaticType.Connector, value);
            }
        }

        public static IUI UI
        {
            get
            {
                return Get<IUI>(StaticType.UI);
            }
            set
            {
                Set(StaticType.UI, value);
            }
        }

        public static IMaster Master
        {
            get
            {
                return Get<IMaster>(StaticType.Master);
            }
            set
            {
                Set(StaticType.Master, value);
            }
        }

        public static IPlayerData PlayerData
        {
            get
            {
                return Get<IPlayerData>(StaticType.PlayerData);
            }
            set
            {
                Set(StaticType.PlayerData, value);
            }
        }

        public static ITeamManager TeamManager
        {
            get
            {
                return Get<ITeamManager>(StaticType.TeamManager);
            }
            set
            {
                Set(StaticType.TeamManager, value);
            }
        }

        public static IAwards Awards
        {
            get
            {
                return Get<IAwards>(StaticType.Awards);
            }
            set
            {
                Set(StaticType.Awards, value);
            }
        }
    }
}