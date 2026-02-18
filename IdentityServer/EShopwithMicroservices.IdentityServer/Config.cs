// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace EShopwithMicroservices.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
                new ApiResource("ResourceCatalog")
                {
                    Scopes = {"CatalogFullPermission" , "CatalogReadPermission" },
                },
                new ApiResource("ResourceDiscount")
                {
                    Scopes = {"DiscountFullPermission" },
                },
                new ApiResource("ResourceOrder")
                {
                    Scopes = {"OrderFullPermission" },
                },
                new ApiResource("ResourceCargo")
                { 
                    Scopes = {"CargoFullPermission"} 
                },
                new ApiResource("ResourceBasket")
                {
                    Scopes = { "BasketFullPermission" }
                },
                 new ApiResource("ResourceComment")
                {
                    Scopes = { "CommentFullPermission" }
                },
                  new ApiResource("ResourcePayment")
                {
                    Scopes = { "PaymentFullPermission" }
                },
                   new ApiResource("ResourceImage")
                {
                    Scopes = { "ImageFullPermission" }
                },
                 new ApiResource("ResourceOcelot")
                {
                    Scopes = { "OcelotFullPermission" }
                },
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
                new ApiScope("CatalogFullPermission","Full authority for Catalog API"),
                new ApiScope("DiscountFullPermission","Full authority for Discount API"),
                new ApiScope("OrderFullPermission","Full authority for Order API"),
                new ApiScope("CatalogReadPermission","Read authority for Catalog API"),
                new ApiScope("CargoFullPermission","Full authority for Cargo API"),
                new ApiScope("BasketFullPermission","Full authority for Basket API"),
                new ApiScope("CommentFullPermission","Full authority for Comment API"),
                new ApiScope("PaymentFullPermission","Full authority for Payment API"),
                new ApiScope("ImageFullPermission","Full authority for Image API"),
                new ApiScope("OcelotFullPermission","Full authority for Ocelot API"),
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName)

        };
        public static IEnumerable<Client> Clients => new Client[]
        {
                //Visitor Client
                new Client
                {
                    ClientId="MultiShopVisitorId",
                    ClientName="Multi Shop Visitor User",
                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    ClientSecrets={ new Secret("multishopsecret".Sha256()) },
                    AllowedScopes={ "CatalogFullPermission", "OcelotFullPermission", "CommentFullPermission", "ImageFullPermission" }
                },
                //Manager Client
                new Client
                {
                    ClientId = "MultiShopManagerId",
                    ClientName="Multi Shop Manager User",
                    AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                    ClientSecrets={ new Secret("multishopsecret".Sha256()) },
                    AllowedScopes={"CatalogReadPermission" , "CatalogFullPermission" , "BasketFullPermission", "OcelotFullPermission" , "CommentFullPermission", "PaymentFullPermission", "ImageFullPermission" ,"DiscountFullPermission",
                    IdentityServerConstants.LocalApi.ScopeName,
                    IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile }
                },
                //Admin Client
                new Client
                {
                    ClientId = "MultiShopAdminId",
                    ClientName="Multi Shop Admin User",
                    AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                    ClientSecrets={ new Secret("multishopsecret".Sha256()) },
                    AllowedScopes={ "CatalogFullPermission", "CatalogReadPermission" , "DiscountFullPermission" , "OrderFullPermission", "CargoFullPermission","BasketFullPermission","OcelotFullPermission","CommentFullPermission","PaymentFullPermission","ImageFullPermission",
                    IdentityServerConstants.LocalApi.ScopeName,
                    IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile },
                    AccessTokenLifetime=600
                }
        };
    }
}