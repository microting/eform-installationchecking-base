using System.ComponentModel.DataAnnotations.Schema;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.InstallationCheckingBase.Infrastructure.Data.Entities
{
    public class MeterVersion : BaseEntity
    {
        public int Num { get; set; }
        public string QR { get; set; }
        public string RoomType { get; set; }
        public int Floor { get; set; }
        public string RoomName { get; set; }
        public int InstallationId { get; set; }
        public virtual Installation Installation { get; set; }
        
        [ForeignKey("Meters")]
        public int MeterId { get; set; }

    }
}