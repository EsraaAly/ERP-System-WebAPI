// =====================================
// Global Using Directives — ERP.Application
// =====================================
global using ERP.Application.Common.Models;
global using ERP.Application.Common;
global using ERP.Application.Common.Interfaces.IPersistence;
global using ERP.Application.DTOs.GeneralDefinitions;
global using ERP.Application.Features.GeneralDefinitions.Cities.Commands;
global using ERP.Application.Features.GeneralDefinitions.Cities.Queries;
global using ERP.Application.Features.GeneralDefinitions.Clients.Commands;
global using ERP.Application.Features.GeneralDefinitions.Clients.Queries;
global using ERP.Application.Features.GeneralDefinitions.Suppliers.Commands;
global using ERP.Application.Features.GeneralDefinitions.Suppliers.Queries;
global using ERP.Application.Features.GeneralDefinitions.Regions.Commands;
global using ERP.Application.Features.GeneralDefinitions.Regions.Queries;
global using ERP.Application.Features.GeneralDefinitions.Units.Commands;
global using ERP.Application.Features.GeneralDefinitions.Units.Queries;
global using ERP.Application.Features.GeneralDefinitions.ClientTypes.Commands;
global using ERP.Application.Features.GeneralDefinitions.ClientTypes.Queries;
global using ERP.Application.Features.GeneralDefinitions.SupplierTypes.Commands;
global using ERP.Application.Features.GeneralDefinitions.SupplierTypes.Queries;
global using ERP.Application.Features.GeneralDefinitions.ItemCategories.Commands;
global using ERP.Application.Features.GeneralDefinitions.ItemCategories.Queries;
global using ERP.Application.Features.GeneralDefinitions.ClientContacts.Commands;
global using ERP.Application.Features.GeneralDefinitions.ClientContacts.Queries;
global using ERP.Application.Features.GeneralDefinitions.SupplierContacts.Commands;
global using ERP.Application.Features.GeneralDefinitions.SupplierContacts.Queries;
global using ERP.Application.Features.GeneralDefinitions.SupplierItems.Commands;
global using ERP.Application.Features.GeneralDefinitions.SupplierItems.Queries;
global using ERP.Application.Features.GeneralDefinitions.ClientPriceLists.Commands;
global using ERP.Application.Features.GeneralDefinitions.ClientPriceLists.Queries;
global using ERP.Application.Features.GeneralDefinitions.ItemLists.Commands;
global using ERP.Application.Features.GeneralDefinitions.ItemLists.Queries;
global using ERP.Application.Features.GeneralDefinitions.ItemRegistries.Commands;
global using ERP.Application.Features.GeneralDefinitions.ItemRegistries.Queries;
global using ERP.Application.Features.GeneralDefinitions.Countries.Commands;
global using ERP.Application.Features.GeneralDefinitions.Countries.Queries;
global using ERP.Application.Common.Mapping;
global using ERP.Domain.Entities.GeneralDefinitions;
// ── BCL ──────────────────────────────────────────────────────
global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Linq.Expressions;
global using System.Text;
global using System.Threading.Tasks;

// ── Third-party ──────────────────────────────────────────────
global using Mapster;
global using MediatR;
global using FluentValidation;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Mvc;




