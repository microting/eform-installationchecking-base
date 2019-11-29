/*
The MIT License (MIT)

Copyright (c) 2007 - 2019 Microting A/S

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microting.InstallationCheckingBase.Infrastructure.Data.Entities;
using Microting.InstallationCheckingBase.Infrastructure.Enums;
using NUnit.Framework;
using static Microting.eForm.Infrastructure.Constants.Constants;

namespace Microting.InstallationCheckingBase.Tests
{
    [TestFixture]
    public class InstallationUTest : DbTestFixture
    {
        [Test]
        public async Task Installation_Create_DoesCreate()
        {
            // Arrange
            Random rnd = new Random();

            Installation installation = new Installation
            {
                CompanyName = Guid.NewGuid().ToString(),
                CompanyAddress = Guid.NewGuid().ToString(),
                CompanyAddress2 = Guid.NewGuid().ToString(),
                ZipCode = Guid.NewGuid().ToString(),
                CityName = Guid.NewGuid().ToString(),
                CountryCode = Guid.NewGuid().ToString(),
                Type = InstallationType.Installation,
                State = InstallationState.NotAssigned,
                DateInstall = DateTime.UtcNow,
                DateRemove = DateTime.UtcNow,
                DateActRemove = DateTime.UtcNow,
                EmployeeId = rnd.Next(1, 255),
                CustomerId = rnd.Next(1, 255),
                SdkCaseId = rnd.Next(1, 255),
                UpdatedByUserId = rnd.Next(1, 255),
                CreatedByUserId = rnd.Next(1, 255)
            };

            // Act
            await installation.Create(DbContext);

            // Assert
            Installation dbInstallation = DbContext.Installations.AsNoTracking().First();
            List<Installation> installations = DbContext.Installations.AsNoTracking().ToList();
            InstallationVersion dbInstallationVersion = DbContext.InstallationVersions.AsNoTracking().First();
            List<InstallationVersion> installationVersions = DbContext.InstallationVersions.AsNoTracking().ToList();

            Assert.NotNull(dbInstallation);
            Assert.NotNull(dbInstallationVersion);
            Assert.AreEqual(1, installations.Count);
            Assert.AreEqual(1, installationVersions.Count);

            Assert.AreEqual(installation.Id, dbInstallation.Id);
            Assert.AreEqual(installation.Version, dbInstallation.Version);
            Assert.AreEqual(installation.WorkflowState, dbInstallation.WorkflowState);
            Assert.AreEqual(installation.CreatedAt.ToString(), dbInstallation.CreatedAt.ToString());
            Assert.AreEqual(installation.CreatedByUserId, dbInstallation.CreatedByUserId);
            Assert.AreEqual(installation.UpdatedAt.ToString(), dbInstallation.UpdatedAt.ToString());
            Assert.AreEqual(installation.UpdatedByUserId, dbInstallation.UpdatedByUserId);
            Assert.AreEqual(installation.DateInstall.ToString(), dbInstallation.DateInstall.ToString());
            Assert.AreEqual(installation.DateRemove.ToString(), dbInstallation.DateRemove.ToString());
            Assert.AreEqual(installation.DateActRemove.ToString(), dbInstallation.DateActRemove.ToString());
            Assert.AreEqual(installation.EmployeeId, dbInstallation.EmployeeId);
            Assert.AreEqual(installation.CustomerId, dbInstallation.CustomerId);
            Assert.AreEqual(installation.SdkCaseId, dbInstallation.SdkCaseId);
            Assert.AreEqual(installation.CompanyName, dbInstallation.CompanyName);
            Assert.AreEqual(installation.CompanyAddress, dbInstallation.CompanyAddress);
            Assert.AreEqual(installation.CompanyAddress2, dbInstallation.CompanyAddress2);
            Assert.AreEqual(installation.ZipCode, dbInstallation.ZipCode);
            Assert.AreEqual(installation.CityName, dbInstallation.CityName);
            Assert.AreEqual(installation.CountryCode, dbInstallation.CountryCode);
            Assert.AreEqual(installation.Type, dbInstallation.Type);
            Assert.AreEqual(installation.State, dbInstallation.State);
        }

        [Test]
        public async Task Installation_Update_DoesUpdate()
        {
            // Arrange
            Random rnd = new Random();

            Installation installation = new Installation
            {
                CompanyName = Guid.NewGuid().ToString(),
                CompanyAddress = Guid.NewGuid().ToString(),
                CompanyAddress2 = Guid.NewGuid().ToString(),
                ZipCode = Guid.NewGuid().ToString(),
                CityName = Guid.NewGuid().ToString(),
                CountryCode = Guid.NewGuid().ToString(),
                Type = InstallationType.Installation,
                State = InstallationState.NotAssigned,
                DateInstall = DateTime.UtcNow,
                DateRemove = DateTime.UtcNow,
                DateActRemove = DateTime.UtcNow,
                EmployeeId = rnd.Next(1, 255),
                CustomerId = rnd.Next(1, 255),
                SdkCaseId = rnd.Next(1, 255),
                UpdatedByUserId = rnd.Next(1, 255),
                CreatedByUserId = rnd.Next(1, 255)
            };

            await installation.Create(DbContext);

            // Act
            var oldState = installation.State;
            var oldEmployeeId = installation.EmployeeId;
            var oldUpdatedAt = installation.UpdatedAt.GetValueOrDefault();

            installation.State = InstallationState.Assigned;
            installation.EmployeeId = rnd.Next(1, 255);

            await installation.Update(DbContext);

            // Assert
            Installation dbInstallation = DbContext.Installations.AsNoTracking().First();
            List<Installation> installations = DbContext.Installations.AsNoTracking().ToList();
            List<InstallationVersion> installationVersions = DbContext.InstallationVersions.AsNoTracking().ToList();

            Assert.NotNull(dbInstallation);
            Assert.AreEqual(1, installations.Count);
            Assert.AreEqual(2, installationVersions.Count);

            Assert.AreEqual(installation.Id, dbInstallation.Id);
            Assert.AreEqual(installation.Version, dbInstallation.Version);
            Assert.AreEqual(installation.WorkflowState, dbInstallation.WorkflowState);
            Assert.AreEqual(installation.CreatedAt.ToString(), dbInstallation.CreatedAt.ToString());
            Assert.AreEqual(installation.CreatedByUserId, dbInstallation.CreatedByUserId);
            Assert.AreEqual(installation.UpdatedAt.ToString(), dbInstallation.UpdatedAt.ToString());
            Assert.AreEqual(installation.UpdatedByUserId, dbInstallation.UpdatedByUserId);
            Assert.AreEqual(installation.DateInstall.ToString(), dbInstallation.DateInstall.ToString());
            Assert.AreEqual(installation.DateRemove.ToString(), dbInstallation.DateRemove.ToString());
            Assert.AreEqual(installation.DateActRemove.ToString(), dbInstallation.DateActRemove.ToString());
            Assert.AreEqual(installation.EmployeeId, dbInstallation.EmployeeId);
            Assert.AreEqual(installation.CustomerId, dbInstallation.CustomerId);
            Assert.AreEqual(installation.SdkCaseId, dbInstallation.SdkCaseId);
            Assert.AreEqual(installation.CompanyName, dbInstallation.CompanyName);
            Assert.AreEqual(installation.CompanyAddress, dbInstallation.CompanyAddress);
            Assert.AreEqual(installation.CompanyAddress2, dbInstallation.CompanyAddress2);
            Assert.AreEqual(installation.ZipCode, dbInstallation.ZipCode);
            Assert.AreEqual(installation.CityName, dbInstallation.CityName);
            Assert.AreEqual(installation.CountryCode, dbInstallation.CountryCode);
            Assert.AreEqual(installation.Type, dbInstallation.Type);
            Assert.AreEqual(installation.State, dbInstallation.State);

            Assert.AreEqual(installation.Id, installationVersions[0].InstallationId);
            Assert.AreEqual(1, installationVersions[0].Version);
            Assert.AreEqual(installation.WorkflowState, installationVersions[0].WorkflowState);
            Assert.AreEqual(installation.CreatedAt.ToString(), installationVersions[0].CreatedAt.ToString());
            Assert.AreEqual(installation.CreatedByUserId, installationVersions[0].CreatedByUserId);
            Assert.AreEqual(oldUpdatedAt.ToString(), installationVersions[0].UpdatedAt.ToString());
            Assert.AreEqual(installation.UpdatedByUserId, installationVersions[0].UpdatedByUserId);
            Assert.AreEqual(installation.DateInstall.ToString(), installationVersions[0].DateInstall.ToString());
            Assert.AreEqual(installation.DateRemove.ToString(), installationVersions[0].DateRemove.ToString());
            Assert.AreEqual(installation.DateActRemove.ToString(), installationVersions[0].DateActRemove.ToString());
            Assert.AreEqual(oldEmployeeId, installationVersions[0].EmployeeId);
            Assert.AreEqual(installation.CustomerId, installationVersions[0].CustomerId);
            Assert.AreEqual(installation.SdkCaseId, installationVersions[0].SdkCaseId);
            Assert.AreEqual(installation.CompanyName, installationVersions[0].CompanyName);
            Assert.AreEqual(installation.CompanyAddress, installationVersions[0].CompanyAddress);
            Assert.AreEqual(installation.CompanyAddress2, installationVersions[0].CompanyAddress2);
            Assert.AreEqual(installation.ZipCode, installationVersions[0].ZipCode);
            Assert.AreEqual(installation.CityName, installationVersions[0].CityName);
            Assert.AreEqual(installation.CountryCode, installationVersions[0].CountryCode);
            Assert.AreEqual(installation.Type, installationVersions[0].Type);
            Assert.AreEqual(oldState, installationVersions[0].State);

            Assert.AreEqual(installation.Id, installationVersions[1].InstallationId);
            Assert.AreEqual(2, installationVersions[1].Version);
            Assert.AreEqual(installation.WorkflowState, installationVersions[1].WorkflowState);
            Assert.AreEqual(installation.CreatedAt.ToString(), installationVersions[1].CreatedAt.ToString());
            Assert.AreEqual(installation.CreatedByUserId, installationVersions[1].CreatedByUserId);
            Assert.AreEqual(installation.UpdatedAt.ToString(), installationVersions[1].UpdatedAt.ToString());
            Assert.AreEqual(installation.UpdatedByUserId, installationVersions[1].UpdatedByUserId);
            Assert.AreEqual(installation.DateInstall.ToString(), installationVersions[1].DateInstall.ToString());
            Assert.AreEqual(installation.DateRemove.ToString(), installationVersions[1].DateRemove.ToString());
            Assert.AreEqual(installation.DateActRemove.ToString(), installationVersions[1].DateActRemove.ToString());
            Assert.AreEqual(installation.EmployeeId, installationVersions[1].EmployeeId);
            Assert.AreEqual(installation.CustomerId, installationVersions[1].CustomerId);
            Assert.AreEqual(installation.SdkCaseId, installationVersions[1].SdkCaseId);
            Assert.AreEqual(installation.CompanyName, installationVersions[1].CompanyName);
            Assert.AreEqual(installation.CompanyAddress, installationVersions[1].CompanyAddress);
            Assert.AreEqual(installation.CompanyAddress2, installationVersions[1].CompanyAddress2);
            Assert.AreEqual(installation.ZipCode, installationVersions[1].ZipCode);
            Assert.AreEqual(installation.CityName, installationVersions[1].CityName);
            Assert.AreEqual(installation.CountryCode, installationVersions[1].CountryCode);
            Assert.AreEqual(installation.Type, installationVersions[1].Type);
            Assert.AreEqual(installation.State, installationVersions[1].State);
        }

        [Test]
        public async Task Installation_Delete_DoesDelete()
        {
            // Arrange
            Random rnd = new Random();

            Installation installation = new Installation
            {
                CompanyName = Guid.NewGuid().ToString(),
                CompanyAddress = Guid.NewGuid().ToString(),
                CompanyAddress2 = Guid.NewGuid().ToString(),
                ZipCode = Guid.NewGuid().ToString(),
                CityName = Guid.NewGuid().ToString(),
                CountryCode = Guid.NewGuid().ToString(),
                Type = InstallationType.Installation,
                State = InstallationState.NotAssigned,
                DateInstall = DateTime.UtcNow,
                DateRemove = DateTime.UtcNow,
                DateActRemove = DateTime.UtcNow,
                EmployeeId = rnd.Next(1, 255),
                CustomerId = rnd.Next(1, 255),
                SdkCaseId = rnd.Next(1, 255),
                UpdatedByUserId = rnd.Next(1, 255),
                CreatedByUserId = rnd.Next(1, 255)
            };

            await installation.Create(DbContext);

            // Act
            var oldUpdatedAt = installation.UpdatedAt.GetValueOrDefault();

            await installation.Delete(DbContext);

            // Assert
            Installation dbInstallation = DbContext.Installations.AsNoTracking().First();
            List<Installation> installations = DbContext.Installations.AsNoTracking().ToList();
            List<InstallationVersion> installationVersions = DbContext.InstallationVersions.AsNoTracking().ToList();

            Assert.NotNull(dbInstallation);
            Assert.AreEqual(1, installations.Count);
            Assert.AreEqual(2, installationVersions.Count);

            Assert.AreEqual(installation.Id, dbInstallation.Id);
            Assert.AreEqual(installation.Version, dbInstallation.Version);
            Assert.AreEqual(WorkflowStates.Removed, dbInstallation.WorkflowState);
            Assert.AreEqual(installation.CreatedAt.ToString(), dbInstallation.CreatedAt.ToString());
            Assert.AreEqual(installation.CreatedByUserId, dbInstallation.CreatedByUserId);
            Assert.AreEqual(installation.UpdatedAt.ToString(), dbInstallation.UpdatedAt.ToString());
            Assert.AreEqual(installation.UpdatedByUserId, dbInstallation.UpdatedByUserId);
            Assert.AreEqual(installation.DateInstall.ToString(), dbInstallation.DateInstall.ToString());
            Assert.AreEqual(installation.DateRemove.ToString(), dbInstallation.DateRemove.ToString());
            Assert.AreEqual(installation.DateActRemove.ToString(), dbInstallation.DateActRemove.ToString());
            Assert.AreEqual(installation.EmployeeId, dbInstallation.EmployeeId);
            Assert.AreEqual(installation.CustomerId, dbInstallation.CustomerId);
            Assert.AreEqual(installation.SdkCaseId, dbInstallation.SdkCaseId);
            Assert.AreEqual(installation.CompanyName, dbInstallation.CompanyName);
            Assert.AreEqual(installation.CompanyAddress, dbInstallation.CompanyAddress);
            Assert.AreEqual(installation.CompanyAddress2, dbInstallation.CompanyAddress2);
            Assert.AreEqual(installation.ZipCode, dbInstallation.ZipCode);
            Assert.AreEqual(installation.CityName, dbInstallation.CityName);
            Assert.AreEqual(installation.CountryCode, dbInstallation.CountryCode);
            Assert.AreEqual(installation.Type, dbInstallation.Type);
            Assert.AreEqual(installation.State, dbInstallation.State);

            Assert.AreEqual(installation.Id, installationVersions[0].InstallationId);
            Assert.AreEqual(1, installationVersions[0].Version);
            Assert.AreEqual(WorkflowStates.Created, installationVersions[0].WorkflowState);
            Assert.AreEqual(installation.CreatedAt.ToString(), installationVersions[0].CreatedAt.ToString());
            Assert.AreEqual(installation.CreatedByUserId, installationVersions[0].CreatedByUserId);
            Assert.AreEqual(oldUpdatedAt.ToString(), installationVersions[0].UpdatedAt.ToString());
            Assert.AreEqual(installation.UpdatedByUserId, installationVersions[0].UpdatedByUserId);
            Assert.AreEqual(installation.DateInstall.ToString(), installationVersions[0].DateInstall.ToString());
            Assert.AreEqual(installation.DateRemove.ToString(), installationVersions[0].DateRemove.ToString());
            Assert.AreEqual(installation.DateActRemove.ToString(), installationVersions[0].DateActRemove.ToString());
            Assert.AreEqual(installation.EmployeeId, installationVersions[0].EmployeeId);
            Assert.AreEqual(installation.CustomerId, installationVersions[0].CustomerId);
            Assert.AreEqual(installation.SdkCaseId, installationVersions[0].SdkCaseId);
            Assert.AreEqual(installation.CompanyName, installationVersions[0].CompanyName);
            Assert.AreEqual(installation.CompanyAddress, installationVersions[0].CompanyAddress);
            Assert.AreEqual(installation.CompanyAddress2, installationVersions[0].CompanyAddress2);
            Assert.AreEqual(installation.ZipCode, installationVersions[0].ZipCode);
            Assert.AreEqual(installation.CityName, installationVersions[0].CityName);
            Assert.AreEqual(installation.CountryCode, installationVersions[0].CountryCode);
            Assert.AreEqual(installation.Type, installationVersions[0].Type);
            Assert.AreEqual(installation.State, installationVersions[0].State);

            Assert.AreEqual(installation.Id, installationVersions[1].InstallationId);
            Assert.AreEqual(2, installationVersions[1].Version);
            Assert.AreEqual(WorkflowStates.Removed, installationVersions[1].WorkflowState);
            Assert.AreEqual(installation.CreatedAt.ToString(), installationVersions[1].CreatedAt.ToString());
            Assert.AreEqual(installation.CreatedByUserId, installationVersions[1].CreatedByUserId);
            Assert.AreEqual(installation.UpdatedAt.ToString(), installationVersions[1].UpdatedAt.ToString());
            Assert.AreEqual(installation.UpdatedByUserId, installationVersions[1].UpdatedByUserId);
            Assert.AreEqual(installation.DateInstall.ToString(), installationVersions[1].DateInstall.ToString());
            Assert.AreEqual(installation.DateRemove.ToString(), installationVersions[1].DateRemove.ToString());
            Assert.AreEqual(installation.DateActRemove.ToString(), installationVersions[1].DateActRemove.ToString());
            Assert.AreEqual(installation.EmployeeId, installationVersions[1].EmployeeId);
            Assert.AreEqual(installation.CustomerId, installationVersions[1].CustomerId);
            Assert.AreEqual(installation.SdkCaseId, installationVersions[1].SdkCaseId);
            Assert.AreEqual(installation.CompanyName, installationVersions[1].CompanyName);
            Assert.AreEqual(installation.CompanyAddress, installationVersions[1].CompanyAddress);
            Assert.AreEqual(installation.CompanyAddress2, installationVersions[1].CompanyAddress2);
            Assert.AreEqual(installation.ZipCode, installationVersions[1].ZipCode);
            Assert.AreEqual(installation.CityName, installationVersions[1].CityName);
            Assert.AreEqual(installation.CountryCode, installationVersions[1].CountryCode);
            Assert.AreEqual(installation.Type, installationVersions[1].Type);
            Assert.AreEqual(installation.State, installationVersions[1].State);
        }
    }
}