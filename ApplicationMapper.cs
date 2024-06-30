using ApplicationCore;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using AutoMapper;
using Microsoft.Identity.Client;

namespace EShopAPI;

public class ApplicationMapper:Profile
{
    public ApplicationMapper()
    {
        CreateMap<Product, ProductRequestModel>().ReverseMap();
        CreateMap<ProductResponseModel, Product>().ReverseMap();
    }
}