// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace OllieShop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("ResourceCatalog") { Scopes = { "CatalogFullPermission", "CatalogReadPermission" } },
            new ApiResource("ResourceDiscount") { Scopes = { "DiscountFullPermission", "DiscountReadPermission" } },
            new ApiResource("ResourceOrder") { Scopes = { "OrderFullPermission", "OrderReadPermission" } },
            new ApiResource("ResourceCargo") { Scopes = { "CargoFullPermission", "CargoReadPermission" } },
            new ApiResource("ResourceBasket") { Scopes = { "BasketFullPermission", "BasketReadPermission" } },
            new ApiResource("ResourceComment") { Scopes = { "CommentFullPermission", "CommentReadPermission" } },
            new ApiResource("ResourcePayment") { Scopes = { "PaymentFullPermission", "PaymentReadPermission" } },
            new ApiResource("ResourceImages") { Scopes = { "ImagesFullPermission", "ImagesReadPermission" } },
            new ApiResource("ResourceOcelot") { Scopes = { "OcelotFullPermission" } },
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission", "Full authority for catalog operations"),
            new ApiScope("CatalogReadPermission", "Reading authority for catalog operations"),
            new ApiScope("DiscountFullPermission", "Full authority for discount operations"),
            new ApiScope("DiscountReadPermission", "Reading authority for discount operations"),
            new ApiScope("OrderFullPermission", "Full authority for order operations"),
            new ApiScope("OrderReadPermission", "Reading authority for order operations"),
            new ApiScope("CargoFullPermission", "Full authority for cargo operations"),
            new ApiScope("CargoReadPermission", "Reading authority for cargo operations"),
            new ApiScope("BasketFullPermission", "Full authority for basket operations"),
            new ApiScope("BasketReadPermission", "Reading authority for basket operations"),
            new ApiScope("CommentFullPermission", "Full authority for comment operations"),
            new ApiScope("CommentReadPermission", "Reading authority for comment operations"),
            new ApiScope("PaymentFullPermission", "Full authority for payment operations"),
            new ApiScope("PaymentReadPermission", "Reading authority for payment operations"),
            new ApiScope("ImagesFullPermission", "Full authority for images operations"),
            new ApiScope("ImagesReadPermission", "Reading authority for images operations"),
            new ApiScope("OcelotFullPermission", "Full authority for Ocelot operations"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            // Visitor
            new Client
            {
                ClientId="OllieShopVisitorId",
                ClientName="Ollie Shop Visitor User",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={new Secret("ollieshopsecret".Sha256())},
                AllowedScopes={
                    "CatalogFullPermission",
                    "DiscountReadPermission",
                    "OrderReadPermission",
                    "CargoReadPermission",
                    "BasketReadPermission",
                    "BasketFullPermission",
                    "CommentReadPermission",
                    "CommentFullPermission",
                    "PaymentReadPermission",
                    "ImagesReadPermission",
                    "OcelotFullPermission",
                    IdentityServerConstants.LocalApi.ScopeName,
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                }
            },

            // Manager
            new Client
            {
                ClientId="OllieShopManagerId",
                ClientName="Ollie Shop Manager User",
                AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                ClientSecrets={new Secret("ollieshopsecret".Sha256())},
                AllowedScopes={
                    "CatalogFullPermission",
                    "DiscountFullPermission",
                    "OrderReadPermission",
                    "CargoReadPermission",
                    "BasketReadPermission",
                    "CommentReadPermission",
                    "CommentFullPermission",
                    "PaymentReadPermission",
                    "ImagesReadPermission",
                    "OcelotFullPermission",
                    IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                }
            },

            // Admin
            new Client
            {
                ClientId="OllieShopAdminId",
                ClientName="Ollie Shop Admin User",
                AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                ClientSecrets={new Secret("ollieshopsecret".Sha256())},
                AllowedScopes={
                    "CatalogFullPermission",
                    "DiscountFullPermission",
                    "OrderFullPermission",
                    "CargoFullPermission",
                    "BasketFullPermission",
                    "CommentFullPermission",
                    "PaymentFullPermission",
                    "ImagesFullPermission",
                    "OcelotFullPermission",
                    IdentityServerConstants.LocalApi.ScopeName,
                    IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                },
                AccessTokenLifetime=300
            }
        };

    }
}
