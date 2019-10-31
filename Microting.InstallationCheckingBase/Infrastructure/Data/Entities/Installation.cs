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

namespace Microting.InstallationCheckingBase.Infrastructure.Data.Entities
{
    public class Installation : BaseEntity
    {
        public InstallationType Type { get; set; }
        public InstallationState State { get; set; }

        public DateTime DateInstall { get; set; }
        public DateTime DateRemove { get; set; }
        public DateTime DateActRemove { get; set; }

        public int EmployeeId { get; set; }
        public int CustomerId { get; set; }
        public int SdkCaseId { get; set; }

        public async Task Create(InstallationCheckingPnDbContext dbContext)
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Version = 1;
            WorkflowState = Constants.WorkflowStates.Created;

            dbContext.Installations.Add(this);
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
                Type = installation.Type,
                State = installation.State,
                DateInstall = installation.DateInstall,
                DateRemove = installation.DateRemove,
                DateActRemove = installation.DateActRemove,
                EmployeeId = installation.EmployeeId,
                CustomerId = installation.CustomerId,
                SdkCaseId = installation.SdkCaseId,
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