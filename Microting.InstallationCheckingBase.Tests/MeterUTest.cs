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
    public class MeterUTest : DbTestFixture
    {
        [Test]
        public async Task Meter_Create_DoesCreate()
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
                InstallationEmployeeId = rnd.Next(1, 255),
                CustomerId = rnd.Next(1, 255),
                InstallationSdkCaseId = rnd.Next(1, 255),
                UpdatedByUserId = rnd.Next(1, 255),
                CreatedByUserId = rnd.Next(1, 255)
            };
            await installation.Create(DbContext);

            Meter meter = new Meter
            {
                Num = rnd.Next(1, 255),
                QR = Guid.NewGuid().ToString(),
                RoomType = Guid.NewGuid().ToString(),
                Floor = rnd.Next(1, 255),
                RoomName = Guid.NewGuid().ToString(),
                InstallationId = installation.Id
            };

            // Act
            await meter.Create(DbContext);

            // Assert
            Meter dbMeter = DbContext.Meters.AsNoTracking().First();
            List<Meter> meters = DbContext.Meters.AsNoTracking().ToList();
            MeterVersion dbMeterVersion = DbContext.MeterVersions.AsNoTracking().First();
            List<MeterVersion> meterVersions = DbContext.MeterVersions.AsNoTracking().ToList();
            
            Assert.NotNull(dbMeter);
            Assert.NotNull(dbMeterVersion);
            Assert.NotNull(meters);
            Assert.NotNull(meterVersions);
            Assert.AreEqual(1, meters.Count);
            Assert.AreEqual(1, meterVersions.Count);
            
            Assert.AreEqual(meter.Id, dbMeter.Id);
            Assert.AreEqual(meter.Version, dbMeter.Version);
            Assert.AreEqual(meter.WorkflowState, dbMeter.WorkflowState);
            Assert.AreEqual(meter.CreatedAt.ToString(), dbMeter.CreatedAt.ToString());
            Assert.AreEqual(meter.CreatedByUserId, dbMeter.CreatedByUserId);
            Assert.AreEqual(meter.UpdatedAt.ToString(), dbMeter.UpdatedAt.ToString());
            Assert.AreEqual(meter.UpdatedByUserId, dbMeter.UpdatedByUserId);
            Assert.AreEqual(meter.Num, dbMeter.Num);
            Assert.AreEqual(meter.QR, dbMeter.QR);
            Assert.AreEqual(meter.RoomType, dbMeter.RoomType);
            Assert.AreEqual(meter.Floor, dbMeter.Floor);
            Assert.AreEqual(meter.RoomName, dbMeter.RoomName);
            Assert.AreEqual(meter.InstallationId, dbMeter.InstallationId);
        }

        [Test]
        public async Task Meters_Update_DoesUpdate()
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
                InstallationEmployeeId = rnd.Next(1, 255),
                CustomerId = rnd.Next(1, 255),
                InstallationSdkCaseId = rnd.Next(1, 255),
                UpdatedByUserId = rnd.Next(1, 255),
                CreatedByUserId = rnd.Next(1, 255)
            };
            await installation.Create(DbContext);
            Installation installation2 = new Installation
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
                InstallationEmployeeId = rnd.Next(1, 255),
                CustomerId = rnd.Next(1, 255),
                InstallationSdkCaseId = rnd.Next(1, 255),
                UpdatedByUserId = rnd.Next(1, 255),
                CreatedByUserId = rnd.Next(1, 255)
            };
            await installation2.Create(DbContext);
            
            Meter meter = new Meter
            {
                Num = rnd.Next(1, 255),
                QR = Guid.NewGuid().ToString(),
                RoomType = Guid.NewGuid().ToString(),
                Floor = rnd.Next(1, 255),
                RoomName = Guid.NewGuid().ToString(),
                InstallationId = installation.Id
            };
            await meter.Create(DbContext);

            var oldNum = meter.Num;
            var oldQR = meter.QR;
            var oldRoomType = meter.RoomType;
            var oldRoomName = meter.RoomName;
            var oldFloor = meter.Floor;
            var oldInstallationId = meter.InstallationId;
            var oldUpdatedAt = meter.UpdatedAt.GetValueOrDefault();
            
            meter.Num = rnd.Next(1, 255);
            meter.QR = Guid.NewGuid().ToString();
            meter.RoomType = Guid.NewGuid().ToString();
            meter.Floor = rnd.Next(1, 255);
            meter.RoomName = Guid.NewGuid().ToString();
            meter.InstallationId = installation2.Id;
            
            // Act
            await meter.Update(DbContext);
            
            // Assert
            Meter dbMeter = DbContext.Meters.AsNoTracking().First();
            List<Meter> meters = DbContext.Meters.AsNoTracking().ToList();
            List<MeterVersion> meterVersions = DbContext.MeterVersions.AsNoTracking().ToList();
            
            Assert.NotNull(dbMeter);
            Assert.NotNull(meters);
            Assert.NotNull(meterVersions);
            Assert.AreEqual(1, meters.Count);
            Assert.AreEqual(2, meterVersions.Count);
            
            Assert.AreEqual(meter.Id, dbMeter.Id);
            Assert.AreEqual(meter.Version, dbMeter.Version);
            Assert.AreEqual(meter.WorkflowState, dbMeter.WorkflowState);
            Assert.AreEqual(meter.CreatedAt.ToString(), dbMeter.CreatedAt.ToString());
            Assert.AreEqual(meter.CreatedByUserId, dbMeter.CreatedByUserId);
            Assert.AreEqual(meter.UpdatedAt.ToString(), dbMeter.UpdatedAt.ToString());
            Assert.AreEqual(meter.UpdatedByUserId, dbMeter.UpdatedByUserId);
            Assert.AreEqual(meter.Num, dbMeter.Num);
            Assert.AreEqual(meter.QR, dbMeter.QR);
            Assert.AreEqual(meter.RoomType, dbMeter.RoomType);
            Assert.AreEqual(meter.Floor, dbMeter.Floor);
            Assert.AreEqual(meter.RoomName, dbMeter.RoomName);
            Assert.AreEqual(meter.InstallationId, dbMeter.InstallationId);
            
            Assert.AreEqual(meter.Id, meterVersions[0].MeterId);
            Assert.AreEqual(1, meterVersions[0].Version);
            Assert.AreEqual(meter.WorkflowState, meterVersions[0].WorkflowState);
            Assert.AreEqual(meter.CreatedAt.ToString(), meterVersions[0].CreatedAt.ToString());
            Assert.AreEqual(meter.CreatedByUserId, meterVersions[0].CreatedByUserId);
            Assert.AreEqual(oldUpdatedAt.ToString(), meterVersions[0].UpdatedAt.ToString());
            Assert.AreEqual(meter.UpdatedByUserId, meterVersions[0].UpdatedByUserId);
            Assert.AreEqual(oldNum, meterVersions[0].Num);
            Assert.AreEqual(oldQR, meterVersions[0].QR);
            Assert.AreEqual(oldRoomType, meterVersions[0].RoomType);
            Assert.AreEqual(oldFloor, meterVersions[0].Floor);
            Assert.AreEqual(oldRoomName, meterVersions[0].RoomName);
            Assert.AreEqual(oldInstallationId, meterVersions[0].InstallationId);
            
            Assert.AreEqual(meter.Id, meterVersions[1].MeterId);
            Assert.AreEqual(2, meterVersions[1].Version);
            Assert.AreEqual(meter.WorkflowState, meterVersions[1].WorkflowState);
            Assert.AreEqual(meter.CreatedAt.ToString(), meterVersions[1].CreatedAt.ToString());
            Assert.AreEqual(meter.CreatedByUserId, meterVersions[1].CreatedByUserId);
            Assert.AreEqual(meter.UpdatedAt.ToString(), meterVersions[1].UpdatedAt.ToString());
            Assert.AreEqual(meter.UpdatedByUserId, meterVersions[1].UpdatedByUserId);
            Assert.AreEqual(meter.Num, meterVersions[1].Num);
            Assert.AreEqual(meter.QR, meterVersions[1].QR);
            Assert.AreEqual(meter.RoomType, meterVersions[1].RoomType);
            Assert.AreEqual(meter.Floor, meterVersions[1].Floor);
            Assert.AreEqual(meter.RoomName, meterVersions[1].RoomName);
            Assert.AreEqual(meter.InstallationId, meterVersions[1].InstallationId);
        }

        [Test]
        public async Task Meters_Delete_DoesDelete()
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
                InstallationEmployeeId = rnd.Next(1, 255),
                CustomerId = rnd.Next(1, 255),
                InstallationSdkCaseId = rnd.Next(1, 255),
                UpdatedByUserId = rnd.Next(1, 255),
                CreatedByUserId = rnd.Next(1, 255)
            };
            await installation.Create(DbContext);
         
            
            Meter meter = new Meter
            {
                Num = rnd.Next(1, 255),
                QR = Guid.NewGuid().ToString(),
                RoomType = Guid.NewGuid().ToString(),
                Floor = rnd.Next(1, 255),
                RoomName = Guid.NewGuid().ToString(),
                InstallationId = installation.Id
            };
            await meter.Create(DbContext);
            
            var oldUpdatedAt = meter.UpdatedAt.GetValueOrDefault();
 
            // Act
            await meter.Delete(DbContext);
            
            // Assert
            Meter dbMeter = DbContext.Meters.AsNoTracking().First();
            List<Meter> meters = DbContext.Meters.AsNoTracking().ToList();
            List<MeterVersion> meterVersions = DbContext.MeterVersions.AsNoTracking().ToList();
            
            Assert.NotNull(dbMeter);
            Assert.NotNull(meters);
            Assert.NotNull(meterVersions);
            Assert.AreEqual(1, meters.Count);
            Assert.AreEqual(2, meterVersions.Count);
            
            Assert.AreEqual(meter.Id, dbMeter.Id);
            Assert.AreEqual(meter.Version, dbMeter.Version);
            Assert.AreEqual(WorkflowStates.Removed, dbMeter.WorkflowState);
            Assert.AreEqual(meter.CreatedAt.ToString(), dbMeter.CreatedAt.ToString());
            Assert.AreEqual(meter.CreatedByUserId, dbMeter.CreatedByUserId);
            Assert.AreEqual(meter.UpdatedAt.ToString(), dbMeter.UpdatedAt.ToString());
            Assert.AreEqual(meter.UpdatedByUserId, dbMeter.UpdatedByUserId);
            Assert.AreEqual(meter.Num, dbMeter.Num);
            Assert.AreEqual(meter.QR, dbMeter.QR);
            Assert.AreEqual(meter.RoomType, dbMeter.RoomType);
            Assert.AreEqual(meter.Floor, dbMeter.Floor);
            Assert.AreEqual(meter.RoomName, dbMeter.RoomName);
            Assert.AreEqual(meter.InstallationId, dbMeter.InstallationId);
            
            Assert.AreEqual(meter.Id, meterVersions[0].MeterId);
            Assert.AreEqual(1, meterVersions[0].Version);
            Assert.AreEqual(WorkflowStates.Created, meterVersions[0].WorkflowState);
            Assert.AreEqual(meter.CreatedAt.ToString(), meterVersions[0].CreatedAt.ToString());
            Assert.AreEqual(meter.CreatedByUserId, meterVersions[0].CreatedByUserId);
            Assert.AreEqual(oldUpdatedAt.ToString(), meterVersions[0].UpdatedAt.ToString());
            Assert.AreEqual(meter.UpdatedByUserId, meterVersions[0].UpdatedByUserId);
            Assert.AreEqual(meter.Num, meterVersions[0].Num);
            Assert.AreEqual(meter.QR, meterVersions[0].QR);
            Assert.AreEqual(meter.RoomType, meterVersions[0].RoomType);
            Assert.AreEqual(meter.Floor, meterVersions[0].Floor);
            Assert.AreEqual(meter.RoomName, meterVersions[0].RoomName);
            Assert.AreEqual(meter.InstallationId, meterVersions[0].InstallationId);
            
            Assert.AreEqual(meter.Id, meterVersions[1].MeterId);
            Assert.AreEqual(2, meterVersions[1].Version);
            Assert.AreEqual(WorkflowStates.Removed, meterVersions[1].WorkflowState);
            Assert.AreEqual(meter.CreatedAt.ToString(), meterVersions[1].CreatedAt.ToString());
            Assert.AreEqual(meter.CreatedByUserId, meterVersions[1].CreatedByUserId);
            Assert.AreEqual(meter.UpdatedAt.ToString(), meterVersions[1].UpdatedAt.ToString());
            Assert.AreEqual(meter.UpdatedByUserId, meterVersions[1].UpdatedByUserId);
            Assert.AreEqual(meter.Num, meterVersions[1].Num);
            Assert.AreEqual(meter.QR, meterVersions[1].QR);
            Assert.AreEqual(meter.RoomType, meterVersions[1].RoomType);
            Assert.AreEqual(meter.Floor, meterVersions[1].Floor);
            Assert.AreEqual(meter.RoomName, meterVersions[1].RoomName);
            Assert.AreEqual(meter.InstallationId, meterVersions[1].InstallationId);
        }
    }
}