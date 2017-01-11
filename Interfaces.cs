using UnityEngine;

namespace XD
{
    public interface IHighlightable
    {
        string Label
        {
            get;
        }

        Transform Pivot
        {
            get;
        }

        int Team
        {
            get;
        }

        void On(Color color);
        void Off();
    }

    public interface IDamageHandler : ISender, ISubscriber
    {
    }

    public interface IItemsFactory : IFactory
    {
        IItem Create(ItemType type, Transform parent, params object[] parameters);
    }

    public interface IFactory
    {
    }

    public interface IItem
    {
        void Move(int index);
        void Initialize(object[] parameters);
        void DesrtoySelf();
    }

    public interface ILocalization : IStatic
    {
        bool TryLocalize(string key, out string value);
    }

    public interface IStatic : ISender, ISubscriber
    {
        StaticType StaticType
        {
            get;
        }

        void SaveInstance();
        void DeleteInstance();
    }

    public interface ISceneManager : IStatic
    {
        bool InBattle
        {
            get;
        }

        string GetRandomMap();
    }

    public interface IRankSystem : IStatic
    {
        IRank Current
        {
            get;
        }

        IRank GetRank(int index);
    }

    public interface IRank
    {
    }

    public interface IStatistics : IStatic
    {
    }

    public interface IEffects : IStatic
    {
        Transform Container
        {
            get;
        }

        void Play(int id, Vector3 position, Quaternion rotation);
        void Play(HitType hit, PhysicMaterial material, Vector3 point, Vector3 normal);
        void Play(HitType hit, RaycastHit raycastHit);
    }

    public interface IAwards : IStatic
    {
    }

    public interface IPlayer
    {
    }

    public interface ITeamManager : IStatic
    {
        ITeam[] TeamsInBattle
        {
            get;
        }

        IPlayer[] Players
        {
            get;
        }

        Color GetColor(int team);

        void AddScore(int team);

        void Defeat(int team);

        void Victory(int team);
    }

    public interface IConnector : IStatic
    {
        int Team
        {
            get;
        }

        string Login
        {
            get;
            set;
        }

        string GetRandomPrefab();
    }

    public interface IUI : IStatic
    {
        bool isEmpty
        {
            get;
        }
    }

    public interface IPlayerData : IStatic
    {
        int Weapon
        {
            get;
            set;
        }

        int Primary
        {
            get;
            set;
        }

        int Secondary
        {
            get;
            set;
        }
    }

    public interface IMaster : ITeam, IStatic
    {
        Clamper Timer
        {
            get;
            set;
        }

        bool TeamDamage
        {
            get;
            set;
        }

        bool Respawn
        {
            get;
            set;
        }
    }

    public interface ITeam
    {
        int Team
        {
            get;
            set;
        }
    }

    public interface IInputHandler
    {
        void GetAxisMovement();
        void GetAxisRotation();
        void GetActions();
    }

    public interface IWeapon
    {
        void Use();
        void UpdateTimer();
    }

    public interface IWeaponAction
    {
        void Execute();
    }

    public interface ISubscriber
    {
        string Description
        {
            get;
            set;
        }
        void Reaction(Message type, params object[] parameters);
    }

    public interface ICollider
    {
        ITeam teamController
        {
            get;
        }

        void Process(Collider collider, Settings parameters, int team);
    }

    public interface ISender
    {
        string Description
        {
            get;
            set;
        }
        void AddSubscriber(ISubscriber subscriber);
        void RemoveSubscriber(ISubscriber subscriber);
        void Event(Message type, params object[] parameters);
    }

    public interface IResource
    {
    }

    public interface IResourcesContainer
    {
    }

    public interface IImpact
    {
        void Begin(params object[] parameters);
        void Apply();
        void End();
    }

    public interface IEngineJet
    {
        void DrawJet
        (
            ParticleSystem[] particleSystems,
            float minSpeed,
            float maxSpeed,
            float minAlpha,
            float maxAlpha,
            bool disableForLowSpeed,
            float speed
        );
        ParticleSystem[] FindEffects(Transform baseRoot, string parentName);
    }
}
