﻿using AppDiv.CRVS.Application.Contracts.DTOs;
using AppDiv.CRVS.Application.Contracts.Request;
using AppDiv.CRVS.Application.Features.AddressLookup.Commands.Create;
using AppDiv.CRVS.Application.Features.AddressLookup.Commands.Update;
using AppDiv.CRVS.Application.Features.Customers.Command.Create;
using AppDiv.CRVS.Application.Features.Customers.Command.Update;
using AppDiv.CRVS.Application.Features.Groups.Commands.Create;
using AppDiv.CRVS.Application.Features.Lookups.Command.Create;
using AppDiv.CRVS.Application.Features.Lookups.Command.Update;
using AppDiv.CRVS.Application.Features.Settings.Commands.create;
using AppDiv.CRVS.Application.Features.Settings.Commands.Update;
using AppDiv.CRVS.Application.Features.WorkFlows.Commands.Create;
using AppDiv.CRVS.Application.Features.User.Command.Create;
using AppDiv.CRVS.Application.Features.User.Command.Update;
using AppDiv.CRVS.Domain;
using AppDiv.CRVS.Domain.Entities;
using AutoMapper;


namespace AppDiv.CRVS.Application.Mapper
{
    internal class CRVSMappingProfile : Profile
    {
        public CRVSMappingProfile()
        {
            CreateMap<Customer, CustomerResponseDTO>().ReverseMap();
            CreateMap<Customer, CreateCustomerCommand>().ReverseMap();
            CreateMap<Customer, EditCustomerCommand>().ReverseMap();

            CreateMap<Lookup, LookupDTO>().ReverseMap();
            CreateMap<Lookup, CreateLookupCommand>().ReverseMap();
            CreateMap<Lookup, UpdateLookupCommand>().ReverseMap();

            CreateMap<Address, AddressDTO>().ReverseMap();
            CreateMap<Address, CreateAdderssCommand>().ReverseMap();
            CreateMap<Address, UpdateaddressCommand>().ReverseMap();

            CreateMap<Setting, SettingDTO>().ReverseMap();
            CreateMap<Setting, createSettingCommand>().ReverseMap();
            CreateMap<Setting, UpdateSettingCommand>().ReverseMap();

            CreateMap<UserGroup, GroupDTO>().ReverseMap();
            CreateMap<UserGroup, CreateGroupCommand>().ReverseMap();

            CreateMap<Workflow, WorkflowDTO>().ReverseMap();
            CreateMap<Workflow, CreateWorkFlowCommand>().ReverseMap();

            CreateMap<Step, StepDTO>().ReverseMap();





            CreateMap<ApplicationUser, UserResponseDTO>().ReverseMap();
            CreateMap<ApplicationUser, CreateUserCommand>().ReverseMap();
            CreateMap<ApplicationUser, UpdateUserCommand>().ReverseMap();

            CreateMap<PersonalInfo, PersonalInfoDTO>().ReverseMap();
            CreateMap<ContactInfo, ContactInfoDTO>().ReverseMap();

            CreateMap<PersonalInfo, AddPersonalInfoRequest>().ReverseMap();
            CreateMap<ContactInfo, AddContactInfoRequest>().ReverseMap();
            CreateMap<ApplicationUser, UpdateUserCommand>().ReverseMap();

            // CreateMap<List<ApplicationUser>, List<UserResponseDTO>>().ReverseMap();



        }
    }
}
