﻿using INNOEcoSystem.Service.Commons.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace INNOEcoSystem.Shared.Extensions;

public static class HttpContextExtensions
{
    public static void InitAccessor(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        HttpContextHelper.Accessor = scope.ServiceProvider.GetRequiredService<IHttpContextAccessor>();
    }
}
