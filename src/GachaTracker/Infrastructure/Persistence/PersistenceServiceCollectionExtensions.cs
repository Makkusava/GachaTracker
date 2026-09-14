using GachaTracker.Features.Events;
using GachaTracker.Features.Gachas;
using GachaTracker.Features.MainQuests;
using Microsoft.EntityFrameworkCore;

namespace GachaTracker.Infrastructure.Persistence;

public static class PersistenceServiceCollectionExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("GachaTracker"));

        services.AddScoped<IGachaRepository, GachaRepository>();
        services.AddScoped<IGachaCatalogUnitOfWork, GachaCatalogUnitOfWork>();

        services.AddScoped<IEventsRepository, EventsRepository>();
        services.AddScoped<IEventsUnitOfWork, EventsUnitOfWork>();

        services.AddScoped<IMainQuestsRepository, MainQuestsRepository>();
        services.AddScoped<IMainQuestsUnitOfWork, MainQuestsUnitOfWork>();

        return services;
    }
}
