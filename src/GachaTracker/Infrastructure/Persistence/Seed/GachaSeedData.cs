using GachaTracker.Domain.Gachas;

namespace GachaTracker.Infrastructure.Persistence.Seed;

public static class GachaSeedData
{
    public static readonly Guid GenshinImpactId = Guid.Parse("11111111-1111-1111-1111-111111111111");
    public static readonly Guid HonkaiStarRailId = Guid.Parse("22222222-2222-2222-2222-222222222222");
    public static readonly Guid ZenlessZoneZeroId = Guid.Parse("33333333-3333-3333-3333-333333333333");
    public static readonly Guid WutheringWavesId = Guid.Parse("44444444-4444-4444-4444-444444444444");

    public static IReadOnlyCollection<Gacha> All { get; } =
    [
        new Gacha(GenshinImpactId, "Genshin Impact", "genshin"),
        new Gacha(HonkaiStarRailId, "Honkai: Star Rail", "hsr"),
        new Gacha(ZenlessZoneZeroId, "Zenless Zone Zero", "zzz"),
        new Gacha(WutheringWavesId, "Wuthering Waves", "wuwa"),
    ];
}
