namespace XD
{
    /// <summary>
    /// Тип статики
    /// </summary>
    public enum StaticType
    {
        /// <summary>
        /// UI
        /// </summary>
        UI              = 0,
        /// <summary>
        /// Мастер контроллер - общее сетевое управление
        /// </summary>
        Master          = 1,
        /// <summary>
        /// Менеджер команд - содержит всю необходимую информацию о командах и игроках
        /// </summary>
        TeamManager     = 2,
        /// <summary>
        /// Статистика - ведет учет действий и достижений игрока
        /// </summary>
        Statistics      = 3,
        /// <summary>
        /// Награды - система вознаграждений, обычно работает напрямую со статистикой
        /// </summary>
        Awards          = 4,
        /// <summary>
        /// Эффекты - вся логика воспроизведения партиклей.
        /// </summary>
        Effects         = 5,
        /// <summary>
        /// Мэнеджер сцен - вся логика работы со сценами.
        /// Удинственный скрипт, который принимает событие UnityEngine.SceneManagement.onSceneLoad.
        /// Все остальные - работают через него.
        /// </summary>
        SceneManager    = 6,
        /// <summary>
        /// Система уровней, обычно основанная на опыте.
        /// </summary>
        RankSystem      = 7,
        /// <summary>
        /// Скрипт, отвечающий за соединение с сетью.
        /// Также занимается отловом ошибок и основных сетевых сообщений.
        /// </summary>
        Connector       = 8,
        /// <summary>
        /// Данные игрока, необходимые для отрисовки в HUD.
        /// </summary>
        PlayerData      = 9,
        /// <summary>
        /// Система локализации
        /// </summary>
        Localization    = 10,
        /// <summary>
        /// Контроллер итемов - склад, ангар, магазин и тп
        /// </summary>
        ItemController  = 11,
        /// <summary>
        /// Объект-пустышка, реализующий все интерфейсы статики.
        /// Нужен для того, чтобы не было необходимости проверки на null.
        /// </summary>
        Empty           = 12,

        /// <summary>
        /// Фабрика итемов, просто заготовка
        /// </summary>
        ItemsFactory    = 20,
    }

    /// <summary>
    /// Тип инициатора попадания
    /// </summary>
    public enum HitType
    {
        Bullet      = 0,
        Explosion   = 1,
        Melee       = 2,
    }

    /// <summary>
    /// Тип итема, заготовка, для фабрики
    /// </summary>
    public enum ItemType
    {
        ItemBattleChat = 0,
        ItemResult = 1,
        ItemTeamPlayer = 2,
        ItemDamageContext = 3,
    }

    /// <summary>
    /// Вид расходника
    /// </summary>
    public enum ConsumableType
    {
        None = 0,
        Bullet = 1,
        MedKit = 2,
        Missile = 3,
        ParameterChanger = 4,
        ShellChanger = 5
    }

    /// <summary>
    /// Тип слота для рвсходника
    /// </summary>
    public enum ConsumableSlotType
    {
        None        = 0,
        Ammunition  = 1, // Боекомплект 3
        Consumables = 2, // Снаряжение 6
        Provisions  = 3, // Амуниция 5
        Equipment   = 5, // Оборудование 4
        Sticker     = 6, // Стикеры 2
        Camouflage  = 7  // Камуфляж 1
    }

    /// <summary>
    /// Способ использования расходника
    /// </summary>
    public enum ConsumableUseType
    {
        UseOnPress = 0,
        UseOnBattleStart = 1,
        UseOnLowHP = 2,
    }

    /// <summary>
    /// Тип модуля техники
    /// </summary>
    public enum ModuleType
    {
        None,
        Cannon,
        Reloader,
        Armor,
        Engine,
        Tracks
    }

    /// <summary>
    /// Тип изменения параметра (сложить, умножить, заменить)
    /// </summary>
    public enum ModifierType
    {
        Sum,
        Multiply,
        Replace
    }

    /// <summary>
    /// Класс танка (легкий, средний, тяжелый)
    /// </summary>
    public enum TankClass
    {
        Light       = 0,
        Medium      = 1,
        Heavy       = 2
    }

    public enum VehicleStatus
    {
        Locked      = 0,
        Unlocked    = 1,
        Bought      = 2
    }

    public enum Setting
    {
        None = -1,
        /// <summary> Здоровье </summary>
        HP = 0,
        /// <summary> Длительность </summary>
        Duration = 1,
        /// <summary> Урон </summary>
        Damage = 2,
        /// <summary> Скорострельность </summary>
        RPM = 3,
        /// <summary> Выстелы в минуту </summary>   
        AttackAngle = 4,
        /// <summary> Дальность атаки </summary>
        AttackLength = 5,
        /// <summary> Скорость </summary>
        MovingSpeed = 6,
        /// <summary> Ускорение </summary>
        Accelerate = 7,
        /// <summary> Сфера действия </summary>
        Scope = 8,
        /// <summary> Обойма, либо статус орудия </summary>
        Cage = 9,
        /// <summary> Затраты (либо сила нагрева, либо количество снарядов за один выстрел) </summary>
        Spending = 10,
        /// <summary> Скорость восстановления (% в секунду) </summary>
        Reduction = 11,
        /// <summary> Скорость поворота </summary>
        AngularSpeed = 12,
        /// <summary> Масса </summary>
        Mass = 13,
        /// <summary> Вероятность критического попадания </summary>
        CritProbability = 14,
        /// <summary> Защита </summary>
        Armor = 15,
        /// <summary> Количество </summary>
        Count = 16,
        /// <summary> Топливо </summary>
        Fuel = 17,
        /// <summary> Перезарядка </summary>
        Cooldown = 18,
        /// <summary> Контроль прыжка </summary>
        Jump = 19,
        /// <summary> Радиус (взрыва, влияния) </summary>
        Radius = 20,
        /// <summary> Боезапас </summary>
        Ammunition = 21,
        /// <summary> Множитель урона от критического попадания </summary>
        CritFactor = 22,
        /// <summary> Шанс поджечь </summary>
        BurnProbability = 23,
        /// <summary> Урон от горения </summary>
        BurningDamage = 24,
        /// <summary> Поглощение урона </summary>
        DamageAbsorption = 25,
        /// <summary> Шанс поглощения урона </summary>
        DamageAbsorptionProbability = 26,
        /// <summary> Скорость поворота башни </summary>
        TurretSpeed = 27,
        /// <summary> Шанс изменить скорость поворота башни </summary>
        TurretSpeedChangeProbability = 28,
        /// <summary> Шанс изменить скорость передвижения техники </summary>
        MoveSpeedChangeProbability = 29,
        /// <summary> Шанс изменить скорость перезарядки орудий </summary>
        RPMChangeProbability = 30,
        /// <summary> Уменшение времени дебаффа </summary>
        DebuffTimeСutter = 31,
        /// <summary> Шанс уничтожить технику одним выстрелом </summary>
        OneShotProbability = 32,
        /// <summary> Навык экипажа </summary>
        CrewSkills = 33,
    }

    public enum Message
    {
        Button          = 0,
        Axis            = 1,
        WeaponUsed      = 2,
        Hit             = 3,
        CaptureBase     = 4,
        Connected       = 5,
        Disconnected    = 6,
        Destroy         = 7,
        GotVehicle      = 8,
        Instantiated    = 9,
        Say             = 10,
        VehicleStarted  = 11,
        ShowWindowSets  = 12,
    }

    public enum TextParameter
    {
        Color   = 0,
        Size    = 1,
        Style   = 2,
    }

    public enum ImpactType
    {
        Permanent   = 0,
        Timer       = 1,
        Periodic    = 2,
    }

    public enum VisualVehicleEffectType
    {
        None        = -1,
        Smoke       = 0,
        Burn        = 1,
        BurnByShell = 2
    }

    public enum Stage
    {
        WaitForPlayers  = 0,
        Battle          = 1,
        Result          = 2,
    }
}