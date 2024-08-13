using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace OllieShop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("ResourceCatalog")
            {
                Scopes = { "CatalogFullPermission", "CatalogReadPermission" },
                UserClaims = { "role" }  // Rol claim'ini dahil et
            },
            new ApiResource("ResourceDiscount")
            {
                Scopes = { "DiscountFullPermission", "DiscountReadPermission" },
                UserClaims = { "role" }
            },
            new ApiResource("ResourceOrder")
            {
                Scopes = { "OrderFullPermission", "OrderReadPermission" },
                UserClaims = { "role" }
            },
            new ApiResource("ResourceCargo")
            {
                Scopes = { "CargoFullPermission", "CargoReadPermission" },
                UserClaims = { "role" }
            },
            new ApiResource("ResourceBasket")
            {
                Scopes = { "BasketFullPermission", "BasketReadPermission" },
                UserClaims = { "role" }
            },
            new ApiResource("ResourceComment")
            {
                Scopes = { "CommentFullPermission", "CommentReadPermission" },
                UserClaims = { "role" }
            },
            new ApiResource("ResourcePayment")
            {
                Scopes = { "PaymentFullPermission", "PaymentReadPermission" },
                UserClaims = { "role" }
            },
            new ApiResource("ResourceImages")
            {
                Scopes = { "ImagesFullPermission", "ImagesReadPermission" },
                UserClaims = { "role" }
            },
            new ApiResource("ResourceOcelot")
            {
                Scopes = { "OcelotFullPermission" },
                UserClaims = { "role" }
            },
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
            {
                UserClaims = { "role" }  // Local API için de rol claim'i ekle
            }
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
                    "DiscountFullPermission",
                    "OrderReadPermission",
                    "CargoReadPermission",
                    "BasketReadPermission",
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
