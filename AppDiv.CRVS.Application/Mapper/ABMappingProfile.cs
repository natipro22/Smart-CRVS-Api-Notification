using AppDiv.CRVS.Application.Contracts.DTOs;
using AppDiv.CRVS.Application.Contracts.Request;
using AppDiv.CRVS.Application.Features.Groups.Commands.Create;
using AppDiv.CRVS.Application.Features.User.Command.Create;
using AppDiv.CRVS.Application.Features.User.Command.Update;
using AppDiv.CRVS.Domain;
using AppDiv.CRVS.Domain.Entities;
using Application.Common.Mappings;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using AppDiv.CRVS.Domain.Entities.Notifications;
using AppDiv.CRVS.Application.Contracts.Request.DeathNotifications;

namespace AppDiv.CRVS.Application.Mapper
{


    internal class CRVSMappingProfile : Profile
    {
        public CRVSMappingProfile()
        {
            // RecognizePrefixes("frm");
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());

        }


        private void ApplyMappingsFromAssembly(Assembly assembly)
        {


            // CreateMap<Lookup, LookupDTO>().ReverseMap();
            // CreateMap<Lookup, CreateLookupCommand>().ReverseMap();
            // CreateMap<Lookup, UpdateLookupCommand>().ReverseMap();

            // CreateMap<Address, AddressDTO>().ReverseMap();
            // // CreateMap<AddressDTO, AddressForLookupDTO>().ReverseMap();

            // CreateMap<Address, CreateAdderssCommand>().ReverseMap();
            // CreateMap<Address, UpdateaddressCommand>().ReverseMap();
            // CreateMap<Address, AddAddressRequest>().ReverseMap();

            CreateMap<UserGroup, GroupDTO>().ReverseMap();
            CreateMap<UserGroup, CreateGroupCommand>().ReverseMap();

            CreateMap<ApplicationUser, UserResponseDTO>().ReverseMap();
            CreateMap<CreateUserCommand, ApplicationUser>()
            .ForMember(x => x.UserGroups, opt => opt.Ignore())
            .ReverseMap();
            CreateMap<ApplicationUser, UpdateUserCommand>().ReverseMap();

            CreateMap<ApplicationUser, UpdateUserCommand>().ReverseMap();
            CreateMap<DeathNotification, AddDeathNotificationRequest>().ReverseMap();
            CreateMap<DeathNotification, DeathNotificationDTO>().ReverseMap();
            CreateMap<DeathRegistrar, AddDeathRegistrar>().ReverseMap();
            CreateMap<Deceased, AddDeceased>().ReverseMap();
            CreateMap<DeathRegistrar, UpdateDeathRegistrar>().ReverseMap();
            CreateMap<Deceased, UpdateDeceased>().ReverseMap();

            // CreateMap<Transaction, TransactionRequestDTO>().ReverseMap();

            // CreateMap<WitnessArchive, Witness>().ReverseMap();


            // CreateMap<PersonalInfoIndex, PersonalInfoSearchDTO>();
            // CreateMap<List<ApplicationUser>, List<UserResponseDTO>>().ReverseMap();

            var mapFromType = typeof(IMapFrom<>);

            var mappingMethodName = nameof(IMapFrom<object>.Mapping);

            bool HasInterface(Type t) => t.IsGenericType && t.GetGenericTypeDefinition() == mapFromType;

            var types = assembly.GetExportedTypes().Where(t => t.GetInterfaces().Any(HasInterface)).ToList();

            var argumentTypes = new Type[] { typeof(Profile) };

            foreach (var type in types)
            {

                var instance = Activator.CreateInstance(type);

                var methodInfo = type.GetMethod(mappingMethodName);

                if (methodInfo != null)
                {
                    methodInfo.Invoke(instance, new object[] { this });
                }
                else
                {
                    var interfaces = type.GetInterfaces().Where(HasInterface).ToList();

                    if (interfaces.Count > 0)
                    {
                        foreach (var @interface in interfaces)
                        {
                            var interfaceMethodInfo = @interface.GetMethod(mappingMethodName, argumentTypes);

                            interfaceMethodInfo?.Invoke(instance, new object[] { this });
                        }
                    }
                }

            }
        }
    }
}
