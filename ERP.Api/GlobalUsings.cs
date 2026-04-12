// =====================================
// Global Using Directives — ERP.Api
// =====================================
global using ERP.Application.Common.Models;
global using ERP.Api.Extensions;

// ── BCL ──────────────────────────────────────────────────────
global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Reflection;
global using System.Text;
global using System.Threading.Tasks;
global using MediatR;
global using FluentValidation;
global using FluentValidation.AspNetCore;
global using Mapster;

// ── ASP.NET Core ─────────────────────────────────────────────
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.AspNetCore.Mvc;


global using ERP.Infrastructure.Data;
global using ERP.Api.Constants;
global using ERP.Api.Controllers.Base;
global using ERP.Api.Middlewares;
global using ERP.Application;
global using ERP.Infrastructure;

// ── Features ──────────────────────────────────────────────
global using ERP.Application.DTOs.GeneralDefinitions;
global using ERP.Application.Features.GeneralDefinitions.Cities.Commands;
global using ERP.Application.Features.GeneralDefinitions.Cities.Commands.AddCity;
global using ERP.Application.Features.GeneralDefinitions.Cities.Commands.DeleteCity;
global using ERP.Application.Features.GeneralDefinitions.Cities.Commands.UpdateCity;
global using ERP.Application.Features.GeneralDefinitions.Cities.Queries.GetAllCities;
global using ERP.Application.Features.GeneralDefinitions.Cities.Queries.GetCityById;

global using ERP.Application.Features.GeneralDefinitions.Clients.Commands;
global using ERP.Application.Features.GeneralDefinitions.Clients.Commands.AddClient;
global using ERP.Application.Features.GeneralDefinitions.Clients.Commands.DeleteClient;
global using ERP.Application.Features.GeneralDefinitions.Clients.Commands.UpdateClient;
global using ERP.Application.Features.GeneralDefinitions.Clients.Queries.GetAllClients;
global using ERP.Application.Features.GeneralDefinitions.Clients.Queries.GetClientById;

global using ERP.Application.Features.GeneralDefinitions.Suppliers.Commands;
global using ERP.Application.Features.GeneralDefinitions.Suppliers.Commands.AddSupplier;
global using ERP.Application.Features.GeneralDefinitions.Suppliers.Commands.DeleteSupplier;
global using ERP.Application.Features.GeneralDefinitions.Suppliers.Commands.UpdateSupplier;
global using ERP.Application.Features.GeneralDefinitions.Suppliers.Queries.GetAllSuppliers;
global using ERP.Application.Features.GeneralDefinitions.Suppliers.Queries.GetSupplierById;

global using ERP.Application.Features.GeneralDefinitions.Countries.Commands;
global using ERP.Application.Features.GeneralDefinitions.Countries.Commands.AddCountry;
global using ERP.Application.Features.GeneralDefinitions.Countries.Commands.DeleteCountry;
global using ERP.Application.Features.GeneralDefinitions.Countries.Commands.UpdateCountry;
global using ERP.Application.Features.GeneralDefinitions.Countries.Queries.GetAllCountries;
global using ERP.Application.Features.GeneralDefinitions.Countries.Queries.GetCountryById;

global using ERP.Application.Features.GeneralDefinitions.Regions.Commands;
global using ERP.Application.Features.GeneralDefinitions.Regions.Commands.AddRegion;
global using ERP.Application.Features.GeneralDefinitions.Regions.Commands.DeleteRegion;
global using ERP.Application.Features.GeneralDefinitions.Regions.Commands.UpdateRegion;
global using ERP.Application.Features.GeneralDefinitions.Regions.Queries.GetAllRegions;
global using ERP.Application.Features.GeneralDefinitions.Regions.Queries.GetRegionById;

global using ERP.Application.Features.GeneralDefinitions.Units.Commands;
global using ERP.Application.Features.GeneralDefinitions.Units.Commands.AddUnit;
global using ERP.Application.Features.GeneralDefinitions.Units.Commands.DeleteUnit;
global using ERP.Application.Features.GeneralDefinitions.Units.Commands.UpdateUnit;
global using ERP.Application.Features.GeneralDefinitions.Units.Queries.GetAllUnits;
global using ERP.Application.Features.GeneralDefinitions.Units.Queries.GetUnitById;

global using ERP.Application.Features.GeneralDefinitions.ClientTypes.Commands;
global using ERP.Application.Features.GeneralDefinitions.ClientTypes.Commands.AddClientType;
global using ERP.Application.Features.GeneralDefinitions.ClientTypes.Commands.DeleteClientType;
global using ERP.Application.Features.GeneralDefinitions.ClientTypes.Commands.UpdateClientType;
global using ERP.Application.Features.GeneralDefinitions.ClientTypes.Queries.GetAllClientTypes;
global using ERP.Application.Features.GeneralDefinitions.ClientTypes.Queries.GetClientTypeById;

global using ERP.Application.Features.GeneralDefinitions.SupplierTypes.Commands;
global using ERP.Application.Features.GeneralDefinitions.SupplierTypes.Commands.AddSupplierType;
global using ERP.Application.Features.GeneralDefinitions.SupplierTypes.Commands.DeleteSupplierType;
global using ERP.Application.Features.GeneralDefinitions.SupplierTypes.Commands.UpdateSupplierType;
global using ERP.Application.Features.GeneralDefinitions.SupplierTypes.Queries.GetAllSupplierTypes;
global using ERP.Application.Features.GeneralDefinitions.SupplierTypes.Queries.GetSupplierTypeById;

global using ERP.Application.Features.GeneralDefinitions.ItemCategories.Commands;
global using ERP.Application.Features.GeneralDefinitions.ItemCategories.Commands.AddItemCategory;
global using ERP.Application.Features.GeneralDefinitions.ItemCategories.Commands.DeleteItemCategory;
global using ERP.Application.Features.GeneralDefinitions.ItemCategories.Commands.UpdateItemCategory;
global using ERP.Application.Features.GeneralDefinitions.ItemCategories.Queries.GetAllItemCategories;
global using ERP.Application.Features.GeneralDefinitions.ItemCategories.Queries.GetItemCategoryById;

global using ERP.Application.Features.GeneralDefinitions.ClientContacts.Commands;
global using ERP.Application.Features.GeneralDefinitions.ClientContacts.Commands.AddClientContact;
global using ERP.Application.Features.GeneralDefinitions.ClientContacts.Commands.DeleteClientContact;
global using ERP.Application.Features.GeneralDefinitions.ClientContacts.Commands.UpdateClientContact;
global using ERP.Application.Features.GeneralDefinitions.ClientContacts.Queries.GetAllClientContacts;
global using ERP.Application.Features.GeneralDefinitions.ClientContacts.Queries.GetClientContactById;

global using ERP.Application.Features.GeneralDefinitions.SupplierContacts.Commands;
global using ERP.Application.Features.GeneralDefinitions.SupplierContacts.Commands.AddSupplierContact;
global using ERP.Application.Features.GeneralDefinitions.SupplierContacts.Commands.DeleteSupplierContact;
global using ERP.Application.Features.GeneralDefinitions.SupplierContacts.Commands.UpdateSupplierContact;
global using ERP.Application.Features.GeneralDefinitions.SupplierContacts.Queries.GetAllSupplierContacts;
global using ERP.Application.Features.GeneralDefinitions.SupplierContacts.Queries.GetSupplierContactById;

global using ERP.Application.Features.GeneralDefinitions.SupplierItems.Commands;
global using ERP.Application.Features.GeneralDefinitions.SupplierItems.Commands.AddSupplierItem;
global using ERP.Application.Features.GeneralDefinitions.SupplierItems.Commands.DeleteSupplierItem;
global using ERP.Application.Features.GeneralDefinitions.SupplierItems.Commands.UpdateSupplierItem;
global using ERP.Application.Features.GeneralDefinitions.SupplierItems.Queries.GetAllSupplierItems;
global using ERP.Application.Features.GeneralDefinitions.SupplierItems.Queries.GetSupplierItemById;

global using ERP.Application.Features.GeneralDefinitions.ClientPriceLists.Commands;
global using ERP.Application.Features.GeneralDefinitions.ClientPriceLists.Commands.AddClientPriceList;
global using ERP.Application.Features.GeneralDefinitions.ClientPriceLists.Commands.DeleteClientPriceList;
global using ERP.Application.Features.GeneralDefinitions.ClientPriceLists.Commands.UpdateClientPriceList;
global using ERP.Application.Features.GeneralDefinitions.ClientPriceLists.Queries.GetAllClientPriceLists;
global using ERP.Application.Features.GeneralDefinitions.ClientPriceLists.Queries.GetClientPriceListById;

global using ERP.Application.Features.GeneralDefinitions.ItemLists.Commands;
global using ERP.Application.Features.GeneralDefinitions.ItemLists.Commands.AddItemList;
global using ERP.Application.Features.GeneralDefinitions.ItemLists.Commands.DeleteItemList;
global using ERP.Application.Features.GeneralDefinitions.ItemLists.Commands.UpdateItemList;
global using ERP.Application.Features.GeneralDefinitions.ItemLists.Queries.GetAllItemLists;
global using ERP.Application.Features.GeneralDefinitions.ItemLists.Queries.GetItemListById;

global using ERP.Application.Features.GeneralDefinitions.ItemRegistries.Commands;
global using ERP.Application.Features.GeneralDefinitions.ItemRegistries.Commands.AddItemRegistry;
global using ERP.Application.Features.GeneralDefinitions.ItemRegistries.Commands.DeleteItemRegistry;
global using ERP.Application.Features.GeneralDefinitions.ItemRegistries.Commands.UpdateItemRegistry;
global using ERP.Application.Features.GeneralDefinitions.ItemRegistries.Queries.GetAllItemRegistries;
global using ERP.Application.Features.GeneralDefinitions.ItemRegistries.Queries.GetItemRegistryById;
