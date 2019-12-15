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
using System.Threading.Tasks;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;
using Microsoft.EntityFrameworkCore;
using Microting.eForm.Infrastructure.Constants;
using Microting.InstallationCheckingBase.Infrastructure.Enums;
using System.Collections.Generic;

namespace Microting.InstallationCheckingBase.Infrastructure.Data.Entities
{
    public class Installation : BaseEntity
    {
        public string CadastralNumber { get; set; }
        public string CadastralType { get; set; }
        public string PropertyNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public int? LivingFloorsNumber { get; set; }
        public int? YearBuilt { get; set; }

        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyAddress2 { get; set; }
        public string ZipCode { get; set; }
        public string CityName { get; set; }
        public string CountryCode { get; set; }

        public InstallationType Type { get; set; }
        public InstallationState State { get; set; }

        public DateTime? DateInstall { get; set; }
        public DateTime? DateRemove { get; set; }
        public DateTime? DateActRemove { get; set; }

        public int? EmployeeId { get; set; }
        public int? CustomerId { get; set; }
        public int? SdkCaseId { get; set; }
        public int? RemovalFormId { get; set; }
        public string InstallationImageName { get; set; }

        public virtual ICollection<Meter> Meters { get; set; }

        public async Task Create(InstallationCheckingPnDbContext dbContext)
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Version = 1;
            WorkflowState = Constants.WorkflowStates.Created;

            dbContext.Installations.Add(this);
            await dbContext.SaveChangesAsync();

            dbContext.InstallationVersions.Add(MapInstallationVersion(this));
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(InstallationCheckingPnDbContext dbContext)
        {
            Installation installation = await dbContext.Installations.FirstOrDefaultAsync(x => x.Id == Id);

            if (installation == null)
            {
                throw new NullReferenceException($"Could not find item with id: {Id}");
            }

            installation.CadastralNumber = CadastralNumber;
            installation.CadastralType = CadastralType;
            installation.PropertyNumber = PropertyNumber;
            installation.ApartmentNumber = ApartmentNumber;
            installation.LivingFloorsNumber = LivingFloorsNumber;
            installation.YearBuilt = YearBuilt;
            installation.CompanyName = CompanyName;
            installation.CompanyAddress = CompanyAddress;
            installation.CompanyAddress2 = CompanyAddress2;
            installation.CityName = CityName;
            installation.CountryCode = CountryCode;
            installation.ZipCode = ZipCode;
            installation.Type = Type;
            installation.State = State;
            installation.DateInstall = DateInstall;
            installation.DateRemove = DateRemove;
            installation.DateActRemove = DateActRemove;
            installation.EmployeeId = EmployeeId;
            installation.CustomerId = CustomerId;
            installation.SdkCaseId = SdkCaseId;
            installation.WorkflowState = WorkflowState;
            installation.UpdatedAt = UpdatedAt;
            installation.UpdatedByUserId = UpdatedByUserId;
            installation.Meters = Meters;

            if (dbContext.ChangeTracker.HasChanges())
            {
                installation.UpdatedAt = DateTime.UtcNow;
                installation.Version += 1;

                dbContext.InstallationVersions.Add(MapInstallationVersion(installation));
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task Delete(InstallationCheckingPnDbContext dbContext)
        {
            Installation installation = await dbContext.Installations.FirstOrDefaultAsync(x => x.Id == Id);

            if (installation == null)
            {
                throw new NullReferenceException($"Could not find Installation with id: {Id}");
            }

            installation.WorkflowState = Constants.WorkflowStates.Removed;
            
            if (dbContext.ChangeTracker.HasChanges())
            {
                installation.UpdatedAt = DateTime.UtcNow;
                installation.Version += 1;

                dbContext.InstallationVersions.Add(MapInstallationVersion(installation));
                await dbContext.SaveChangesAsync();
            }
        }

        private InstallationVersion MapInstallationVersion(Installation installation)
        {
            InstallationVersion installationVersion = new InstallationVersion
            {
                InstallationId = installation.Id,
                CadastralNumber = installation.CadastralNumber,
                CadastralType = installation.CadastralType,
                PropertyNumber = installation.PropertyNumber,
                ApartmentNumber = installation.ApartmentNumber,
                LivingFloorsNumber = installation.LivingFloorsNumber,
                YearBuilt = installation.YearBuilt,
                CompanyName = installation.CompanyName,
                CompanyAddress = installation.CompanyAddress,
                CompanyAddress2 = installation.CompanyAddress2,
                CityName = installation.CityName,
                CountryCode = installation.CountryCode,
                ZipCode = installation.ZipCode,
                Type = installation.Type,
                State = installation.State,
                DateInstall = installation.DateInstall,
                DateRemove = installation.DateRemove,
                DateActRemove = installation.DateActRemove,
                EmployeeId = installation.EmployeeId,
                CustomerId = installation.CustomerId,
                SdkCaseId = installation.SdkCaseId,
                RemovalFormId = installation.RemovalFormId,
                InstallationImageName = installation.InstallationImageName,
                CreatedAt = installation.CreatedAt,
                UpdatedAt = installation.UpdatedAt,
                Version = installation.Version,
                WorkflowState = installation.WorkflowState,
                UpdatedByUserId = installation.UpdatedByUserId,
                CreatedByUserId = installation.CreatedByUserId
            };

            return installationVersion;
        }
    }
}