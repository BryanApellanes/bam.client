// <copyright file="OpenIdConnectApplicationCreator.cs" company="Bam, Inc">
// Copyright (c) 2020 - present Bam, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using Bam.Sdk.Model;

namespace Bam.Client
{
    /// <summary>
    /// Class for instaciating OpenIdConnectApplications.
    /// </summary>
    public class OpenIdConnectApplicationCreator : Creator<OpenIdConnectApplication>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenIdConnectApplicationCreator"/> class.
        /// </summary>
        /// <param name="sdkConfig">The configuration.</param>
        /// <param name="requestCreator">The request creator.</param>
        /// <param name="dataManagementContext">The data management context.</param>
        public OpenIdConnectApplicationCreator(ApiConfig sdkConfig, ICreateRequestCreator<OpenIdConnectApplication> requestCreator, IDataManagementContext dataManagementContext)
            : base(sdkConfig, requestCreator, dataManagementContext)
        {
        }
    }
}
