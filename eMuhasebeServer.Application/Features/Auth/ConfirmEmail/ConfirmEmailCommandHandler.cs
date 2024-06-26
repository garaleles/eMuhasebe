﻿using eMuhasebeServer.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TS.Result;

namespace eMuhasebeServer.Application.Features.Auth.ConfirmEmail
{
    internal sealed class ConfirmEmailCommandHandler(UserManager<AppUser> userManager) :
        IRequestHandler<ConfirmEmailCommand, Result<string>>
    {


        public async Task<Result<string>> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            AppUser? appUser = await userManager.FindByEmailAsync(request.Email);
            if (appUser is null)
            {
                return "E-Posta adresi bulunamadı.";
            }
            if (appUser.EmailConfirmed)
            {
                return "E-Posta adresi zaten onaylanmış.";
            }

            appUser.EmailConfirmed = true;
            await userManager.UpdateAsync(appUser);

            return "E-Posta adresi başarıyla onaylandı.";



        }
    }

}
