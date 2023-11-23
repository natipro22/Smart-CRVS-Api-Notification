using System.Data.Common;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using AppDiv.CRVS.Application.Interfaces.Persistence;
using AppDiv.CRVS.Domain.Enums;
using AppDiv.CRVS.Application.Exceptions;
using AppDiv.CRVS.Application.Common;
using AppDiv.CRVS.Application.Contracts.DTOs;
using AppDiv.CRVS.Application.Interfaces;
using AppDiv.CRVS.Domain.Entities;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using AppDiv.CRVS.Utility.Services;

namespace AppDiv.CRVS.Infrastructure.Persistence
{

    public class ReportRepostory : IReportRepostory
    {
        private readonly CRVSDbContext _DbContext;
        // private readonly IReportStoreRepostory _reportStor;
        private readonly IUserResolverService _userResolver;
        private readonly IAddressLookupRepository _addressLookupRepo;
        private string addressAm = "";
        private string addressOr = "";
        // private static readonly JsonSerializerSettings jsonSerializerSettings = new()
        // {
        //     Converters = { new NullStringValueConverter() }
        // };

        public ReportRepostory(IAddressLookupRepository addressLookupRepo, IUserResolverService userResolver, CRVSDbContext dbContext
        // , IReportStoreRepostory reportStor
        )
        {
            _DbContext = dbContext;
            // _reportStor = reportStor;
            _userResolver = userResolver;
            _addressLookupRepo = addressLookupRepo;
        }
        

        public async Task<(DbDataReader, DbConnection)> ConnectDatabase(string sql)
        {
            var connectionString = _DbContext.Database.GetDbConnection();



            connectionString.Open();

            using var command = connectionString.CreateCommand();
            command.CommandText = sql;
            command.CommandType = CommandType.Text;
            return (await command.ExecuteReaderAsync(), connectionString);


        }
        // public (string, string) ReturnAgrgateString(List<Aggregate>? aggregates)
        // {
        //     string groupBySql = "";
        //     string orderedBySql = "";
        //     string aggregateSql = "";
        //     int x = 0;
        //     if (aggregates != null && aggregates.Count > 0)
        //     {
        //         Console.WriteLine("Agrgate test : {0}", aggregateSql);

        //         foreach (var aggregate in aggregates)
        //         {

        //             switch (aggregate.AggregateMethod)
        //             {
        //                 case SqlAggregate.GroupBy:
        //                     if (string.IsNullOrEmpty(groupBySql))
        //                     {
        //                         groupBySql = $" GROUP BY {aggregate.PropertyName}";
        //                     }
        //                     else
        //                     {
        //                         groupBySql += $", {aggregate.PropertyName}";
        //                     }
        //                     break;
        //                 case SqlAggregate.OrderBy:
        //                     if (string.IsNullOrEmpty(orderedBySql))
        //                     {
        //                         orderedBySql = $" ORDER BY {aggregate.PropertyName} ASC";
        //                     }
        //                     else
        //                     {
        //                         orderedBySql += $", {aggregate.PropertyName} ASC";
        //                     }
        //                     break;
        //                 case SqlAggregate.OrderByDesc:
        //                     if (string.IsNullOrEmpty(orderedBySql))
        //                     {
        //                         orderedBySql = $" ORDER BY {aggregate.PropertyName} DESC";
        //                     }
        //                     else
        //                     {
        //                         orderedBySql += $", {aggregate.PropertyName} DESC";
        //                     }
        //                     break;
        //                 case SqlAggregate.Count:
        //                     aggregateSql += $" COUNT({aggregate.PropertyName}) AS Count_{aggregate.PropertyName}";
        //                     break;
        //                 case SqlAggregate.Max:
        //                     aggregateSql += $" MAX({aggregate.PropertyName}) AS Max_{aggregate.PropertyName}";
        //                     break;
        //                 case SqlAggregate.Min:
        //                     aggregateSql += $" MIN({aggregate.PropertyName}) AS Min_{aggregate.PropertyName}";
        //                     break;
        //                 case SqlAggregate.Average:
        //                     aggregateSql += $" AVG({aggregate.PropertyName}) AS Average_{aggregate.PropertyName}";
        //                     break;
        //                 case SqlAggregate.Sum:
        //                     aggregateSql += $" SUM({aggregate.PropertyName}) AS Sum_Of_{aggregate.PropertyName}";
        //                     break;
        //                 default:
        //                     aggregateSql += $" COUNT({aggregate.PropertyName}) AS Count_{aggregate.PropertyName}";
        //                     break;
        //             }
        //             x++;
        //             if ((aggregates.Count() > x) && !string.IsNullOrEmpty(aggregateSql))
        //             {
        //                 aggregateSql += ",";
        //             }
        //         }
        //     }

        //     return (groupBySql + " " + orderedBySql, aggregateSql);

        // }

        // public string SanitizeString(string StringToSanitize)
        // {
        //     string output = "";
        //     if (!string.IsNullOrEmpty(StringToSanitize))
        //     {
        //         output = Regex.Replace(StringToSanitize, "[^a-zA-Z0-9_]", "");

        //     }


        //     return output;
        // }
        // public string RemoveSpecialChar(string StringToSanitize)
        // {
        //     string output = "";
        //     if (StringToSanitize?.IndexOf(" delete ", StringComparison.OrdinalIgnoreCase) >= 0)
        //     {
        //         throw new NotFoundException("Delete key word is not allowed in report Create Query");
        //     }
        //     if (StringToSanitize?.IndexOf(" alter ", StringComparison.OrdinalIgnoreCase) >= 0)
        //     {
        //         throw new NotFoundException("Alter key word is not allowed in report Create Query");
        //     }
        //     if (StringToSanitize?.IndexOf(" drop ", StringComparison.OrdinalIgnoreCase) >= 0)
        //     {
        //         throw new NotFoundException("Drop key word is not allowed in report Create Query");
        //     }
        //     if (!string.IsNullOrEmpty(StringToSanitize))
        //     {
        //         output = Regex.Replace(StringToSanitize, "[;-]", "");

        //     }
        //     return output;
        // }
        // public async Task<object> ReturnBirthEvent(string Id)
        // {
        //     var sql = $"CALL birth_event ('{Id}')";
        //     var result = new List<object>();


        //     var viewReader = await ConnectDatabase(sql);
        //     while (viewReader.Item1.Read())
        //     {
        //         result.Add(new
        //         {
        //             Child = JsonConvert.DeserializeObject<Person>(viewReader.Item1["Child"].ToString(), jsonSerializerSettings),
        //             Father = JsonConvert.DeserializeObject<Person>(viewReader.Item1["Father"].ToString(), jsonSerializerSettings),
        //             Mother = JsonConvert.DeserializeObject<Person>(viewReader.Item1["Mother"].ToString(), jsonSerializerSettings),
        //             CivilRegistrarOfficer = JsonConvert.DeserializeObject<Person>(viewReader.Item1["CivilOfficer"].ToString(), jsonSerializerSettings),
        //             Notification = JsonConvert.DeserializeObject<BirthNotificationArchive>(viewReader.Item1["Notification"].ToString(), jsonSerializerSettings),
        //             Registrar = JsonConvert.DeserializeObject<Person>(viewReader.Item1["Registrar"].ToString(), jsonSerializerSettings),
        //             EventInfo = JsonConvert.DeserializeObject<BirthInfo>(viewReader.Item1["EventInfo"].ToString(), jsonSerializerSettings),
        //             EventSupportingDocuments = JsonConvert.DeserializeObject<List<SupportingDocumentDTO>>(viewReader.Item1["EventSupportingDocuments"].ToString(), jsonSerializerSettings),
        //         });


        //     }
        //     await viewReader.Item2.CloseAsync();
        //     return result;
        // }

        // public async Task<object> ReturnAdoptionEvent(string Id)
        // {
        //     var sql = $"CALL adoption_event ('{Id}')";
        //     var result = new List<object>();
        //     var viewReader = await ConnectDatabase(sql);
        //     while (viewReader.Item1.Read())
        //     {
        //         result.Add(new
        //         {
        //             Child = JsonConvert.DeserializeObject<Person>(viewReader.Item1["Child"].ToString(),jsonSerializerSettings),
        //             Father = JsonConvert.DeserializeObject<Person>(viewReader.Item1["Father"].ToString(),jsonSerializerSettings),
        //             Mother = JsonConvert.DeserializeObject<Person>(viewReader.Item1["Mother"].ToString(),jsonSerializerSettings),
        //             CivilRegistrarOfficer = JsonConvert.DeserializeObject<Person>(viewReader.Item1["CivilOfficer"].ToString(),jsonSerializerSettings),
        //             EventInfo = JsonConvert.DeserializeObject<AdoptionInfo>(viewReader.Item1["EventInfo"].ToString(),jsonSerializerSettings),
        //             Court = JsonConvert.DeserializeObject<CourtArchive>(viewReader.Item1["Court"].ToString(),jsonSerializerSettings),
        //             EventSupportingDocuments = JsonConvert.DeserializeObject<List<SupportingDocumentDTO>>(viewReader.Item1["EventSupportingDocuments"].ToString(),jsonSerializerSettings),
        //         });


        //     }
        //     await viewReader.Item2.CloseAsync();
        //     return result;
        // }
        // public async Task<object> ReturnmarriageEvent(string Id)
        // {
        //     var sql = $"CALL marriage_events ('{Id}')";
        //     var result = new List<object>();
        //     var viewReader = await ConnectDatabase(sql);
        //     while (viewReader.Item1.Read())
        //     {
        //         result.Add(new
        //         {
        //             Groom = JsonConvert.DeserializeObject<Person>(viewReader.Item1["Groom"].ToString(),jsonSerializerSettings),
        //             Bride = JsonConvert.DeserializeObject<Person>(viewReader.Item1["Bride"].ToString(),jsonSerializerSettings),
        //             EventInfo = JsonConvert.DeserializeObject<MarriageInfo>(viewReader.Item1["EventInfo"].ToString(),jsonSerializerSettings),
        //             CivilRegistrarOfficer = JsonConvert.DeserializeObject<Person>(viewReader.Item1["CivilOfficer"].ToString(),jsonSerializerSettings),
        //             EventSupportingDocuments = JsonConvert.DeserializeObject<List<SupportingDocumentDTO>>(viewReader.Item1["EventSupportingDocuments"].ToString(),jsonSerializerSettings),
        //             BrideWitnesses = JsonConvert.DeserializeObject<List<Person>>(viewReader.Item1["BrideWitnesses"].ToString(),jsonSerializerSettings),
        //             GroomWitnesses = JsonConvert.DeserializeObject<List<Person>>(viewReader.Item1["GroomWitnesses"].ToString(),jsonSerializerSettings),
        //         });


        //     }
        //     await viewReader.Item2.CloseAsync();
        //     return result;
        // }
        // public async Task<object> ReturnDivorceEvent(string Id)
        // {
        //     var sql = $"CALL divorce_event ('{Id}')";
        //     var result = new List<object>();
        //     var viewReader = await ConnectDatabase(sql);
        //     while (viewReader.Item1.Read())
        //     {
        //         result.Add(new
        //         {
        //             Husband = JsonConvert.DeserializeObject<Person>(viewReader.Item1["Husband"].ToString(),jsonSerializerSettings),
        //             Wife = JsonConvert.DeserializeObject<Person>(viewReader.Item1["Wife"].ToString(),jsonSerializerSettings),
        //             CivilRegistrarOfficer = JsonConvert.DeserializeObject<Person>(viewReader.Item1["CivilOfficer"].ToString(),jsonSerializerSettings),
        //             Court = JsonConvert.DeserializeObject<CourtArchive>(viewReader.Item1["Court"].ToString(),jsonSerializerSettings),
        //             EventInfo = JsonConvert.DeserializeObject<DivorceInfo>(viewReader.Item1["EventInfo"].ToString(),jsonSerializerSettings),
        //             EventSupportingDocuments = JsonConvert.DeserializeObject<List<SupportingDocumentDTO>>(viewReader.Item1["EventSupportingDocuments"].ToString(),jsonSerializerSettings),
        //         });


        //     }
        //     await viewReader.Item2.CloseAsync();
        //     return result;
        // }

        // public async Task<object> ReturnDeathEvent(string Id)
        // {
        //     var sql = $"CALL death_event ('{Id}')";
        //     var result = new List<object>();
        //     var viewReader = await ConnectDatabase(sql);
        //     while (viewReader.Item1.Read())
        //     {
        //         result.Add(new
        //         {
        //             Deceased = JsonConvert.DeserializeObject<Person>(viewReader.Item1["Deceased"].ToString(),jsonSerializerSettings),
        //             EventInfo = JsonConvert.DeserializeObject<DeathInfo>(viewReader.Item1["EventInfo"].ToString(),jsonSerializerSettings),
        //             Notification = JsonConvert.DeserializeObject<DeathNotificationArchive>(viewReader.Item1["DeathNotification"].ToString(),jsonSerializerSettings),
        //             Registrar = JsonConvert.DeserializeObject<Person>(viewReader.Item1["Registrar"].ToString(),jsonSerializerSettings),
        //             CivilRegistrarOfficer = JsonConvert.DeserializeObject<Person>(viewReader.Item1["CivilOfficer"].ToString(),jsonSerializerSettings),
        //             EventSupportingDocuments = JsonConvert.DeserializeObject<List<SupportingDocumentDTO>>(viewReader.Item1["EventSupportingDocuments"].ToString(),jsonSerializerSettings),
        //         });
        //     }
        //     await viewReader.Item2.CloseAsync();
        //     return result;
        // }

        // public async Task<object> ReturnCertificateHistory(string Id)
        // {
        //     var sql = $"CALL event_History ('{Id}')";
        //     var result = new List<object>();
        //     var viewReader = await ConnectDatabase(sql);
        //     while (viewReader.Item1.Read())
        //     {
        //         result.Add(new
        //         {
        //             Action = viewReader.Item1["Action"].ToString(),
        //             By = viewReader.Item1["UserName"].ToString(),
        //             Date = viewReader.Item1["CreatedAt"].ToString(),

        //         });
        //     }
        //     await viewReader.Item2.CloseAsync();
        //     return result;
        // }
        // //  Address = viewReader.Item1["Registrar"].ToString(),

        // public async Task<object> ReturnPerson(string Id)
        // {
        //     var sql = $"CALL Person_procedure ('{Id}')";
        //     var result = new List<object>();
        //     var viewReader = await ConnectDatabase(sql);
        //     while (viewReader.Item1.Read())
        //     {
        //         result.Add(new
        //         {
        //             FirstNameAm = viewReader.Item1["FirstNameAm"],
        //             FirstNameOr = viewReader.Item1["FirstNameOr"],
        //             MiddleNameAm = viewReader.Item1["MiddleNameAm"],
        //             MiddleNameOr = viewReader.Item1["MiddleNameOr"],
        //             LastNameAm = viewReader.Item1["LastNameAm"],
        //             LastNameOr = viewReader.Item1["LastNameOr"],
        //             BirthDay = viewReader.Item1["BirthDateEt"],
        //             GenderAm = viewReader.Item1["GenderAm"],
        //             GenderOr = viewReader.Item1["GenderOr"],
        //             NationalId = viewReader.Item1["NationalId"],
        //             NationalityOr = viewReader.Item1["NationalityOr"],
        //             NationalityAm = viewReader.Item1["NationalityAm"],
        //             MarriageStatusOr = viewReader.Item1["MarriageStatusOr"],
        //             MarriageStatusAm = viewReader.Item1["MarriageStatusAm"],
        //             ReligionOr = viewReader.Item1["ReligionOr"],
        //             ReligionAm = viewReader.Item1["ReligionAm"],
        //             NationOr = viewReader.Item1["NationOr"],
        //             NationAm = viewReader.Item1["NationAm"],
        //             EducationalStatusOr = viewReader.Item1["EducationalStatusOr"],
        //             EducationalStatusAm = viewReader.Item1["EducationalStatusAm"],
        //             TypeOfWorkOr = viewReader.Item1["TypeOfWorkOr"],
        //             BirthAddressOr = viewReader.Item1["BirthAddressOr"],
        //             BirthAddressAm = viewReader.Item1["BirthAddressAm"],
        //             ResidentAddressOr = viewReader.Item1["ResidentAddressOr"],
        //             ResidentAddressAm = viewReader.Item1["ResidentAddressAm"],
        //             BirthCountryOr = viewReader.Item1["Birth_CountryOr"],
        //             BirthCountryAm = viewReader.Item1["Birth_CountryAm"],
        //             BirthRegionOr = viewReader.Item1["Birth_RegionOr"],
        //             BirthRegionAm = viewReader.Item1["Birth_RegionAm"],
        //             BirthZoneOr = viewReader.Item1["Birth_ZoneOr"],
        //             BirthZoneAm = viewReader.Item1["Birth_ZoneAm"],
        //             BirthWoredaOr = viewReader.Item1["Birth_WoredaOr"],
        //             BirthWoredaAm = viewReader.Item1["Birth_WoredaAm"],
        //             BirthSubcityOr = viewReader.Item1["Birth_KebeleOr"],
        //             BirthSubcityAm = viewReader.Item1["Birth_KebeleAm"],
        //             BirthCityKetemaOr = viewReader.Item1["Birth_KebeleOr"],
        //             BirthCityKetemaAm = viewReader.Item1["Birth_KebeleAm"],
        //             BirthKebeleOr = viewReader.Item1["Birth_KebeleOr"],
        //             BirthKebeleAm = viewReader.Item1["Birth_KebeleAm"],
        //             ResidentCountryOr = viewReader.Item1["Resident_CountryOr"],
        //             ResidentCountryAm = viewReader.Item1["Resident_CountryAm"],
        //             ResidentRegionOr = viewReader.Item1["Resident_RegionOr"],
        //             ResidentRegionAm = viewReader.Item1["Resident_RegionAm"],
        //             ResidentZoneOr = viewReader.Item1["Resident_ZoneOr"],
        //             ResidentZoneAm = viewReader.Item1["Resident_ZoneAm"],
        //             ResidentSubcityOr = viewReader.Item1["Resident_WoredaOr"],
        //             ResidentSubcityAm = viewReader.Item1["Resident_WoredaAm"],
        //             ResidentWoredaOr = viewReader.Item1["Resident_KebeleOr"],
        //             ResidentWoredaAm = viewReader.Item1["Resident_KebeleAm"],
        //             ResidentCityKetemaOr = viewReader.Item1["Resident_KebeleOr"],
        //             ResidentCityKetemaAm = viewReader.Item1["Resident_KebeleAm"],
        //             ResidentKebeleOr = viewReader.Item1["Resident_KebeleOr"],
        //             ResidentKebeleAm = viewReader.Item1["Resident_KebeleAm"]
        //         });
        //     }
        //     await viewReader.Item2.CloseAsync();
        //     return result;
        // }
        // public async Task<FormatedAddressDto> ReturnFormatedAddress(string Id)
        // {
        //     var ResidentAddress = ReturnAddress(Id.ToString()).Result;
        //     JArray ResidentAddressjsonObject = JArray.FromObject(ResidentAddress);
        //     FormatedAddressDto Address = ResidentAddressjsonObject.ToObject<List<FormatedAddressDto>>().FirstOrDefault();
        //     return Address;
        // }

        public async Task<object> ReturnAddress(string Id)
        {
            var sql = $"CALL Address_procedure ('{Id}')";
            var result = new List<object>();
            var viewReader = await ConnectDatabase(sql);
            while (viewReader.Item1.Read())
            {
                result.Add(new
                {
                    CountryOr = viewReader.Item1["CountryOr"],
                    CountryAm = viewReader.Item1["CountryAm"],
                    RegionOr = viewReader.Item1["RegionOr"],
                    RegionAm = viewReader.Item1["RegionAm"],
                    ZoneOr = viewReader.Item1["ZoneOr"],
                    ZoneAm = viewReader.Item1["ZoneAm"],
                    WoredaOr = viewReader.Item1["WoredaOr"],
                    WoredaAm = viewReader.Item1["WoredaAm"],
                    KebeleOr = viewReader.Item1["KebeleOr"],
                    KebeleAm = viewReader.Item1["KebeleAm"]
                });
            }
            await viewReader.Item2.CloseAsync();
            return result;
        }

        public async Task<object> ReturnAddressIds(string Id)
        {
            var sql = $"CALL AddressIds_procedure ('{Id}')";
            var result = new List<object>();
            var viewReader = await ConnectDatabase(sql);
            while (viewReader.Item1.Read())
            {
                result.Add(new
                {
                    Country = viewReader.Item1["CountryId"],
                    Region = viewReader.Item1["RegionId"],
                    Zone = viewReader.Item1["ZoneId"],
                    Woreda = viewReader.Item1["WoredaId"],
                    Kebele = viewReader.Item1["KebeleId"],
                });
            }
            await viewReader.Item2.CloseAsync();
            return result;
        }
        // private (string, string, Guid?) ReturnFilterAddress(string? filters, string groupBySql)
        // {
        //     string[] addressArray = { "Country", "Region", "Zone", "Woreda", "Kebele", "addId",
        //                              "conid","regid","zoneid","weId","keId" };
        //     string lang = _userResolver.GetLocale();
        //     bool containFilterAddress = false;
        //     bool containGroupByAddress = false;
        //     string address = "";
        //     string addressGroupby = "";

        //     // if (!string.IsNullOrEmpty(filters))
        //     // {
        //     //     containFilterAddress = addressArray.Any(str => filters.Contains(str));
        //     // }
        //     // if (!string.IsNullOrEmpty(groupBySql))
        //     // {
        //     //     containGroupByAddress = addressArray.Any(str => groupBySql.Contains(str));
        //     // }
        //     // if (containFilterAddress && containGroupByAddress)
        //     // {
        //     //     return ("", "", Guid.Empty);
        //     // }
        //     // if (containFilterAddress && !containGroupByAddress)
        //     // {
        //     //     if (!string.IsNullOrEmpty(filters))
        //     //     {
        //     //         string? matchedString = addressArray.FirstOrDefault(str => filters.Contains(str));
        //     //         switch (matchedString)
        //     //         {
        //     //             case "conid":
        //     //                 addressGroupby = "regid";
        //     //                 break;
        //     //             case "regid":
        //     //                 addressGroupby = "zoneid";
        //     //                 break;
        //     //             case "zoneid":
        //     //                 addressGroupby = "weid";
        //     //                 break;
        //     //             case "weid":
        //     //                 addressGroupby = "keid";
        //     //                 break;
        //     //             case "keid":
        //     //                 addressGroupby = "keid";
        //     //                 break;
        //     //         }
        //     //     }
        //     //     if (!string.IsNullOrEmpty(addressGroupby))
        //     //     {
        //     //         addressAm = addressGroupby.Replace("id", lang);
        //     //     }

        //     //     return ("", addressGroupby, Guid.Empty);

        //     // }
        //     var userAddress = _addressLookupRepo.GetAll().Where(x => x.Id == _userResolver.GetWorkingAddressId()).FirstOrDefault();
        //     if (userAddress != null)
        //     {
        //         switch (userAddress.AdminLevel)
        //         {
        //             case 1:
        //                 address = "conid";
        //                 addressGroupby = "regid";
        //                 break;
        //             case 2:
        //                 address = "regid";
        //                 addressGroupby = "zoneid";
        //                 break;
        //             case 3:
        //                 address = "zoneid";
        //                 addressGroupby = "weid";
        //                 break;
        //             case 4:
        //                 address = "weid";
        //                 addressGroupby = "keid";
        //                 break;
        //             case 5:
        //                 address = "keid";
        //                 addressGroupby = "keid";
        //                 break;
        //         }
        //     }
        //     if (!string.IsNullOrEmpty(addressGroupby))
        //     {
        //         addressAm = addressGroupby.Replace("id", lang);
        //     }
        //     return (address, addressGroupby, userAddress?.Id);
        // }

        // private (string?, string?, string) AddAddressandDateFilter(string reportName, string? groupBySql, string? filters, string ColumsList, bool isAddressBased = false)
        // {
        //     var colums = GetReportColums(reportName).GetAwaiter().GetResult;
        //     var colums2 = colums.Invoke().ToArray();
        //     if (colums2 != null && colums2?.Count() > 0)
        //     {
        //         var _convertor = new CustomDateConverter();
        //         string TodaysDateStr = _convertor.GetBudgetYear();// TodaysDate.ToString("yyyy/M/d H:mm:ss");
        //         if ((bool)colums2?.Contains("EventRegDate") && (string.IsNullOrEmpty(filters) || !filters.Contains("EventRegDate")))
        //         {
        //             if (string.IsNullOrEmpty(filters))
        //             {
        //                 filters = $" EventRegDate > '{TodaysDateStr}' ";

        //             }
        //             else
        //             {
        //                 filters += $" and EventRegDate > '{TodaysDateStr}' ";
        //             }
        //         }

        //         if (isAddressBased)
        //         {
        //             var address = ReturnFilterAddress(filters, groupBySql);
        //             if (!string.IsNullOrEmpty(address.Item1))
        //             {

        //                 if (string.IsNullOrEmpty(filters))
        //                 {
        //                     filters = $" {address.Item1} ='{address.Item3}' ";

        //                 }
        //                 else
        //                 {
        //                     filters += $" and {address.Item1} ='{address.Item3}'";
        //                 }
        //             }
        //             if (!string.IsNullOrEmpty(address.Item2))
        //             {
        //                 ColumsList = ColumsList + ", " + address.Item2;
        //                 if (string.IsNullOrEmpty(groupBySql))
        //                 {
        //                     groupBySql = $" GROUP BY {address.Item2} ";

        //                 }
        //                 else
        //                 {
        //                     groupBySql += $" , {address.Item2}";
        //                 }
        //             }
        //         }
        //     }
        //     return (groupBySql, filters, ColumsList);
        // }

        // private string ReturnLanguageBasedColums(string reportName, string colums)
        // {
        //     string lang = _userResolver.GetLocale();
        //     lang = lang.ToLower() == "am" ? "or" : "am";
        //     string[] stringArray;
        //     if (colums == "*")
        //     {
        //         var colums2 = GetReportColums(reportName).GetAwaiter().GetResult;
        //         stringArray = colums2.Invoke().ToArray();
        //     }
        //     else
        //     {
        //         stringArray = colums.Split(',');
        //     }
        //     var filteredStrings = stringArray.Where(str => !str.ToLower().EndsWith(lang));
        //     string resultString = string.Join(",", filteredStrings);

        //     return resultString;
        // }
        // private string UpdateBasedOnGrape(string reportName, string colums, string GroupBy, string filter, ReportStore report)
        // {
        //     string lang = _userResolver.GetLocale();
        //     string[] addressArray = { "country", "region", "zone", "woreda", "kebele",
        //                              "countryam", "regionam", "zoneam", "woredaam", "kebeleam",
        //                              "countryor", "regionor", "zoneor", "woredaor", "kebeleor",
        //                              "conid","regid","zoneid","weid","keid","addid" };

        //     string final_colus = "";
        //     string[] stringArray = new string[0];
        //     if (report != null)
        //     {
        //         JObject jsonObject = JObject.Parse(report.Other);
        //         Console.WriteLine(jsonObject);
        //         var rows = jsonObject["crossTabValue"]["row"];
        //         var LangBasedColums = jsonObject["amOrColumns"];
        //         if (LangBasedColums != null && LangBasedColums.HasValues)
        //         {
        //             var ArrLangBasedColums = (JArray)LangBasedColums;
        //             stringArray = ArrLangBasedColums.ToObject<string[]>();
        //         }
        //         if (rows != null && rows.HasValues)
        //         {
        //             JArray rowArray = (JArray)rows;
        //             foreach (var row in rowArray)
        //             {
        //                 string strRow = row.ToString();
        //                 if (!addressArray.Contains(strRow.ToLower()))
        //                 {
        //                     if (stringArray.Contains(strRow))
        //                     {
        //                         strRow = strRow + (lang.ToLower() == "am" ? "Am" : "Or");// + " as " + strRow.Replace(lang, "");

        //                     }
        //                     if (!addressArray.Contains(strRow.ToLower()))
        //                     {
        //                         if (string.IsNullOrEmpty(final_colus))
        //                         {
        //                             final_colus = strRow;
        //                         }
        //                         else
        //                         {
        //                             final_colus = string.Join(",", final_colus, strRow);
        //                         }

        //                     }
        //                 }
        //             }
        //         }
        //         // Console.WriteLine("result result : {0}", result);
        //         // var rows = jsonObject["crossTabValue"]["row"];
        //         // JArray rowArray = (JArray)rows;
        //         // Console.WriteLine(rowArray);
        //         var colum = jsonObject["crossTabValue"]["column"];
        //         if (colum != null && colum!.HasValues)
        //         {
        //             JArray colsArray = (JArray)colum;
        //             foreach (var col in colsArray)
        //             {
        //                 string strCol = col.ToString();
        //                 if (!addressArray.Contains(strCol.ToLower()))
        //                 {
        //                     if (stringArray.Contains(strCol))
        //                     {
        //                         strCol = strCol + (lang.ToLower() == "am" ? "Am" : "Or"); //+ " as " + strCol.Replace(lang, "")

        //                     }
        //                     if (string.IsNullOrEmpty(final_colus))
        //                     {
        //                         final_colus = strCol;
        //                     }
        //                     else
        //                     {
        //                         final_colus = string.Join(",", final_colus, strCol);
        //                     }


        //                 }
        //             }
        //         }

        //         var value = jsonObject["crossTabValue"]["value"];
        //         if (value != null && value!.HasValues)
        //         {
        //             JArray valueArray = (JArray)value;
        //             foreach (var val in valueArray)
        //             {
        //                 string strVal = val.ToString();
        //                 if (!addressArray.Contains(strVal.ToLower()))
        //                 {
        //                     if (stringArray.Contains(strVal))
        //                     {
        //                         strVal = strVal + (lang.ToLower() == "am" ? "Am" : "Or");// + " as " + strVal.Replace(lang, "");

        //                     }
        //                     if (string.IsNullOrEmpty(final_colus))
        //                     {
        //                         final_colus = strVal;
        //                     }
        //                     else
        //                     {
        //                         final_colus = string.Join(",", final_colus, "sum(" + strVal + ") as " + strVal);
        //                     }
        //                     Console.WriteLine(final_colus);
        //                 }
        //             }
        //         }
        //         var filters = jsonObject["crossTabValue"]["filters"];
        //         if (filters != null && filters!.HasValues)
        //         {
        //             JArray filtersArray = (JArray)filters;
        //             foreach (var filt in filtersArray)
        //             {
        //                 string strFilt = filt.ToString();
        //                 if (!addressArray.Contains(strFilt.ToLower()))
        //                 {
        //                     if (stringArray.Contains(strFilt))
        //                     {
        //                         strFilt = strFilt + (lang.ToLower() == "am" ? "Am" : "Or");// + " as " + strFilt.Replace(lang, "");

        //                     }
        //                     if (string.IsNullOrEmpty(final_colus))
        //                     {
        //                         final_colus = strFilt;
        //                     }
        //                     else
        //                     {
        //                         final_colus = string.Join(",", strFilt, final_colus);
        //                     }
        //                     Console.WriteLine(final_colus);
        //                 }
        //             }
        //         }
        //         if (string.IsNullOrEmpty(final_colus))
        //         {
        //             string[] columsString = colums.Split(',');
        //             foreach (string col in columsString)
        //             {
        //                 if (!addressArray.Contains(col.ToLower()))
        //                 {
        //                     if (string.IsNullOrEmpty(final_colus))
        //                     {
        //                         final_colus = col;
        //                     }
        //                     else
        //                     {
        //                         final_colus = string.Join(",", final_colus, col);
        //                     }
        //                 }
        //             }
        //         }
        //         if (!string.IsNullOrEmpty(final_colus) && !string.IsNullOrEmpty(addressAm))
        //         {
        //             if (addressAm.EndsWith("am"))
        //             {
        //                 addressAm = addressAm.Replace("am", "Am");

        //             }
        //             if (addressAm.EndsWith("or"))
        //             {
        //                 addressAm = addressAm.Replace("or", "Or");

        //             }
        //             final_colus = string.Join(",", addressAm, final_colus);//+ " as " + addressAm.Replace(lang, "")
        //         }
        //     }

        //     Console.WriteLine(final_colus);
        //     return final_colus;
        // }
    }
}
