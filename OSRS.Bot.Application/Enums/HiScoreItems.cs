namespace OSRS.Bot.Application.Enums;

public class HiScoreItems : HiScoreItemEnumeration
{
    public HiScoreItems(int id, string name, HiScoreTypeEnum hiScoreType) : base(id, name, hiScoreType)
    {
    }

    public static HiScoreItems Overall =			new(1, nameof(Overall), HiScoreTypeEnum.Overall);
    public static HiScoreItems Attack =				new(2, nameof(Attack), HiScoreTypeEnum.Skill);
    public static HiScoreItems Defence =			new(3, nameof(Defence), HiScoreTypeEnum.Skill);
    public static HiScoreItems Strength =			new(4, nameof(Strength), HiScoreTypeEnum.Skill);
    public static HiScoreItems Hitpoints =			new(5, nameof(Hitpoints), HiScoreTypeEnum.Skill);
    public static HiScoreItems Ranged =				new(6, nameof(Ranged), HiScoreTypeEnum.Skill);
    public static HiScoreItems Prayer =				new(7, nameof(Prayer), HiScoreTypeEnum.Skill);
    public static HiScoreItems Magic =				new(8, nameof(Magic), HiScoreTypeEnum.Skill);
    public static HiScoreItems Cooking =			new(9, nameof(Cooking), HiScoreTypeEnum.Skill);
    public static HiScoreItems Woodcutting =		new(10, nameof(Woodcutting), HiScoreTypeEnum.Skill);
    public static HiScoreItems Fletching =			new(11, nameof(Fletching), HiScoreTypeEnum.Skill);
    public static HiScoreItems Fishing =			new(12, nameof(Fishing), HiScoreTypeEnum.Skill);
    public static HiScoreItems Firemaking =			new(13, nameof(Firemaking), HiScoreTypeEnum.Skill);
    public static HiScoreItems Crafting =			new(14, nameof(Crafting), HiScoreTypeEnum.Skill);
    public static HiScoreItems Smithing =			new(15, nameof(Smithing), HiScoreTypeEnum.Skill);
    public static HiScoreItems Mining =				new(16, nameof(Mining), HiScoreTypeEnum.Skill);
    public static HiScoreItems Herblore =			new(17, nameof(Herblore), HiScoreTypeEnum.Skill);
    public static HiScoreItems Agility =			new(18, nameof(Agility), HiScoreTypeEnum.Skill);
    public static HiScoreItems Thieving =			new(19, nameof(Thieving), HiScoreTypeEnum.Skill);
    public static HiScoreItems Slayer =				new(20, nameof(Slayer), HiScoreTypeEnum.Skill);
    public static HiScoreItems Farming =			new(21, nameof(Farming), HiScoreTypeEnum.Skill);
    public static HiScoreItems Runecraft =			new(22, nameof(Runecraft), HiScoreTypeEnum.Skill);
    public static HiScoreItems Hunter =				new(23, nameof(Hunter), HiScoreTypeEnum.Skill);
    public static HiScoreItems Construction =		new(24, nameof(Construction), HiScoreTypeEnum.Skill);

    public static HiScoreItems LeaguePoints =		new(25, "League Points", HiScoreTypeEnum.Activity);
	public static HiScoreItems BountyHunterHunter =	new(26, "Bounty Hunter - Hunter", HiScoreTypeEnum.Activity);
	public static HiScoreItems BountyHunterRogue =	new(27, "Bounty Hunter - Rogue", HiScoreTypeEnum.Activity);
	public static HiScoreItems ClueScrollALL =		new(28, "Clue Scrolls (all)", HiScoreTypeEnum.Activity);
	public static HiScoreItems ClueScrollBEGINNER =	new(29, "Clue Scrolls (beginner)", HiScoreTypeEnum.Activity);
	public static HiScoreItems ClueScrollEASY =		new(30, "Clue Scrolls (easy)", HiScoreTypeEnum.Activity);
	public static HiScoreItems ClueScrollMEDIUM =	new(31 ,"Clue Scrolls (medium)", HiScoreTypeEnum.Activity);
	public static HiScoreItems ClueScrollHARD =		new(32 ,"Clue Scrolls (hard)", HiScoreTypeEnum.Activity);
	public static HiScoreItems ClueScrollELITE =	new(33 ,"Clue Scrolls (elite)", HiScoreTypeEnum.Activity);
	public static HiScoreItems ClueScrollMASTER =	new(34 ,"Clue Scrolls (master)", HiScoreTypeEnum.Activity);
	public static HiScoreItems LastManStanding =	new(35 ,"Last Man Standing", HiScoreTypeEnum.Activity);
	public static HiScoreItems PvpArenaRank =		new(36 ,"PvP Arena - Rank", HiScoreTypeEnum.Activity);
	public static HiScoreItems SoulWarsZeal =		new(37 ,"Soul Wars Zeal", HiScoreTypeEnum.Activity);
	public static HiScoreItems RiftsClosed =		new(38 ,"Rifts closed", HiScoreTypeEnum.Activity);

	public static HiScoreItems AbyssalSire =		new(39 ,"Abyssal Sire", HiScoreTypeEnum.Boss);
	public static HiScoreItems AlchemicalHydra =	new(40 ,"Alchemical Hydra", HiScoreTypeEnum.Boss);
	public static HiScoreItems BarrowsChests =		new(41 ,"Barrows Chests", HiScoreTypeEnum.Boss);
	public static HiScoreItems Bryophyta =			new(42 ,"Bryophyta", HiScoreTypeEnum.Boss);
	public static HiScoreItems Callisto =			new(43 ,"Callisto", HiScoreTypeEnum.Boss);
	public static HiScoreItems Cerberus =			new(44 ,"Cerberus", HiScoreTypeEnum.Boss);
	public static HiScoreItems ChambersOfXeric =	new(45 ,"Chambers of Xeric", HiScoreTypeEnum.Boss);
	public static HiScoreItems ChambersOfXericChallengeMode = new(46 ,"Chambers of Xeric: Challenge Mode", HiScoreTypeEnum.Boss);
	public static HiScoreItems ChaosElemental =		new(47 ,"Chaos Elemental", HiScoreTypeEnum.Boss);
	public static HiScoreItems ChaosFanatic =		new(48 ,"Chaos Fanatic", HiScoreTypeEnum.Boss);
	public static HiScoreItems CommanderZilyana =	new(49 ,"Commander Zilyana", HiScoreTypeEnum.Boss);
	public static HiScoreItems CorporealBeast =		new(50 ,"Corporeal Beast", HiScoreTypeEnum.Boss);
	public static HiScoreItems CrazyArchaeologist =	new(51 ,"Crazy Archaeologist", HiScoreTypeEnum.Boss);
	public static HiScoreItems DagannothPrime =		new(52 ,"Dagannoth Prime", HiScoreTypeEnum.Boss);
	public static HiScoreItems DagannothRex =		new(53 ,"Dagannoth Rex", HiScoreTypeEnum.Boss);
	public static HiScoreItems DagannothSupreme =	new(54 ,"Dagannoth Supreme", HiScoreTypeEnum.Boss);
	public static HiScoreItems DerangedArchaeologist = new(55 ,"Deranged Archaeologist", HiScoreTypeEnum.Boss);
	public static HiScoreItems GeneralGraardor =	new(56 ,"General Graardor", HiScoreTypeEnum.Boss);
	public static HiScoreItems GiantMole =			new(57 ,"Giant Mole", HiScoreTypeEnum.Boss);
	public static HiScoreItems GrotesqueGuardians =	new(58 ,"Grotesque Guardians", HiScoreTypeEnum.Boss);
	public static HiScoreItems Hespori =			new(59, "Hespori", HiScoreTypeEnum.Boss);
	public static HiScoreItems KalphiteQueen =		new(60, "Kalphite Queen", HiScoreTypeEnum.Boss);
	public static HiScoreItems KingBlackDragon =	new(61, "King Black Dragon", HiScoreTypeEnum.Boss);
	public static HiScoreItems Kraken =				new(62, "Kraken", HiScoreTypeEnum.Boss);
	public static HiScoreItems Kreearra =			new(63, "Kree'arra", HiScoreTypeEnum.Boss);
	public static HiScoreItems KrilTsutsaroth =		new(64, "K'ril Tsutsaroth", HiScoreTypeEnum.Boss);
	public static HiScoreItems Mimic =				new(65, "Mimic", HiScoreTypeEnum.Boss);
	public static HiScoreItems Nex =				new(66, "Nex", HiScoreTypeEnum.Boss);
	public static HiScoreItems Nightmare =			new(67, "Nightmare", HiScoreTypeEnum.Boss);
	public static HiScoreItems PhosanisNightmare =	new(68, "Phosani's Nightmare", HiScoreTypeEnum.Boss);
	public static HiScoreItems Obor =				new(69, "Obor", HiScoreTypeEnum.Boss);
	public static HiScoreItems Sarachnis =			new(70, "Sarachnis", HiScoreTypeEnum.Boss);
	public static HiScoreItems Scorpia =			new(71, "Scorpia", HiScoreTypeEnum.Boss);
	public static HiScoreItems Skotizo =			new(72, "Skotizo", HiScoreTypeEnum.Boss);
	public static HiScoreItems Tempoross =			new(73, "Tempoross", HiScoreTypeEnum.Boss);
	public static HiScoreItems TheGauntlet =		new(74, "The Gauntlet", HiScoreTypeEnum.Boss);
	public static HiScoreItems TheCorruptedGauntlet = new(75, "The Corrupted Gauntlet", HiScoreTypeEnum.Boss);
	public static HiScoreItems TheatreOfBlood =		new(76, "Theatre of Blood", HiScoreTypeEnum.Boss);
	public static HiScoreItems TheatreOfBloodHardMode = new(77, "Theatre of Blood: Hard Mode", HiScoreTypeEnum.Boss);
	public static HiScoreItems ThermonuclearSmokeDevil = new(78, "Thermonuclear Smoke Devil", HiScoreTypeEnum.Boss);
	public static HiScoreItems TzKalZuk =			new(79, "TzKal-Zuk", HiScoreTypeEnum.Boss);
	public static HiScoreItems TzTokJad =			new(80, "TzTok-Jad", HiScoreTypeEnum.Boss);
	public static HiScoreItems Venenatis =			new(81, "Venenatis", HiScoreTypeEnum.Boss);
	public static HiScoreItems Vetion =				new(82, "Vet'ion", HiScoreTypeEnum.Boss);
	public static HiScoreItems Vorkath =			new(83, "Vorkath", HiScoreTypeEnum.Boss);
	public static HiScoreItems Wintertodt =			new(84, "Wintertodt", HiScoreTypeEnum.Boss);
	public static HiScoreItems Zalcano =			new(85, "Zalcano", HiScoreTypeEnum.Boss);
	public static HiScoreItems Zulrah =				new(86 ,"Zulrah", HiScoreTypeEnum.Boss);
}
