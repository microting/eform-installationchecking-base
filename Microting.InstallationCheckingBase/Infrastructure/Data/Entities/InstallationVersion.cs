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
using System.ComponentModel.DataAnnotations.Schema;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;
using Microting.InstallationCheckingBase.Infrastructure.Enums;

namespace Microting.InstallationCheckingBase.Infrastructure.Data.Entities
{
    public class InstallationVersion : BaseEntity
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

        public int? InstallationEmployeeId { get; set; }
        public int? RemovalEmployeeId { get; set; }
        public int? CustomerId { get; set; }
        public int? InstallationSdkCaseId { get; set; }
        public int? RemovalSdkCaseId { get; set; }
        public int? RemovalFormId { get; set; }
        public string InstallationImageName { get; set; }

        [ForeignKey("Installation")]
        public int InstallationId { get; set; }
        public virtual Installation Installation { get; set; }
    }
}
