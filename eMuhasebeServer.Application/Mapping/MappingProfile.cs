﻿using AutoMapper;
using eMuhasebeServer.Application.Features.CashRegisters.CreateCashRegister;
using eMuhasebeServer.Application.Features.CashRegisters.UpdateCashRegister;
using eMuhasebeServer.Application.Features.Companies.CreateCompany;
using eMuhasebeServer.Application.Features.Companies.UpdateCompany;
using eMuhasebeServer.Application.Features.Users.CreateUser;
using eMuhasebeServer.Application.Features.Users.UpdateUser;
using eMuhasebeServer.Domain.Entities;
using eMuhasebeServer.Domain.Enums;

namespace eMuhasebeServer.Application.Mapping
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserCommand, AppUser>();
            CreateMap<UpdateUserCommand, AppUser>();

            CreateMap<CreateCompanyCommand, Company>();
            CreateMap<UpdateCompanyCommand, Company>();

            CreateMap<CreateCashRegisterCommand, CashRegister>()
                .ForMember(member => member.CurrencyType, options =>
                {
                    options.MapFrom(command => CurrencyTypeEnum.FromValue(command.currencyTypeValue));
                });

            CreateMap<UpdateCashRegisterCommand, CashRegister>().ForMember(member => member.CurrencyType, options =>
            {
                options.MapFrom(command => CurrencyTypeEnum.FromValue(command.currencyTypeValue));
            });

        }
    }
}