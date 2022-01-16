using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using AutoMapper;
using CarDealer.DTO.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<SupplierImportDTO, Supplier>();
            CreateMap<PartImportDTO, Part>();
            CreateMap<CarImportDTO, Car>();
            CreateMap<CustomerImportDTO, Customer>();
            CreateMap<SalesImportDTO, Sale>();
        }
    }
}
