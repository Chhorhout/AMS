using AutoMapper;
using AMS.Api.Models;
using AMS.Api.Dtos;
namespace AMS.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Asset, AssetResponseDto>()
            .ForMember(dest => dest.LocationName, opt => opt.MapFrom(src => src.Location.Name))
            .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => src.Supplier.Email))
            .ForMember(dest => dest.AssetTypeName, opt => opt.MapFrom(src => src.AssetType.Name))
            .ForMember(x => x.InvoiceNumber, opt => opt.MapFrom(src => src.Invoice.Number));
            CreateMap<AssetCreateDto, Asset>();
            CreateMap<Category, CategoryResponseDto>();
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<Location, LocationResponseDto>();
            CreateMap<LocationCreateDto, Location>();
            CreateMap<Supplier, SupplierResponseDto>();
            CreateMap<SupplierCreateDto, Supplier>();
            CreateMap<Invoice, InvoiceResponseDto>();
            CreateMap<InvoiceCreateDto, Invoice>();
            CreateMap<Maintainer, MaintainerResponseDto>();
            CreateMap<MaintainerCreateDto, Maintainer>();
            CreateMap<AssetType, AssetTypeResponseDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
            CreateMap<AssetTypeCreateDto, AssetType>();
            CreateMap<AssetOwnerShip, AssetOwnerShipResponseDto>()
            .ForMember(dest => dest.AssetName, opt => opt.MapFrom(src => src.Asset.Name));
            CreateMap<AssetOwnerShipCreateDto, AssetOwnerShip>();
            CreateMap<AssetStatus, AssetStatusResponseDto>()
            .ForMember(dest => dest.AssetName, opt => opt.MapFrom(src => src.Asset.Name));
            CreateMap<AssetStatusCreateDto, AssetStatus>();
            CreateMap<AssetStatusHistory, AssetStatusHistoryResponseDto>();
            CreateMap<AssetStatusHistoryCreateDto, AssetStatusHistory>();
            CreateMap<MaintenacePart, MaintenacePartResponseDto>();
            CreateMap<MaintenacePartCreateDto, MaintenacePart>();
            CreateMap<MaintenanceRecord, MaintenanceRecordResponseDto>()
            .ForMember(dest => dest.AssetName, opt => opt.MapFrom(src => src.Asset.Name))
            .ForMember(dest => dest.MaintainerName, opt => opt.MapFrom(src => src.Maintainer.Name));
            CreateMap<MaintenanceRecordCreateDto, MaintenanceRecord>();
            CreateMap<OwnerType, OwnerTypeResponseDto>();
            CreateMap<OwnerTypeCreateDto, OwnerType>();
            CreateMap<TemporaryUser, TemporaryUserResponseDto>();
            CreateMap<TemporaryUserCreateDto, TemporaryUser>();
        }
    }
}
