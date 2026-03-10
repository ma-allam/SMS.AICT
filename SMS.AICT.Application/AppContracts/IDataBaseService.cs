using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SMS.AICT.Domain.DomEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SMS.AICT.Application.AppContracts
{
    public interface IDataBaseService
    {
        public  DbSet<Attempts> Attempts { get; set; }

        public  DbSet<AuditLog> AuditLog { get; set; }

        public  DbSet<Contracts> Contracts { get; set; }

        public  DbSet<Entities> Entities { get; set; }

        public  DbSet<IgsAssignments> IgsAssignments { get; set; }

        public  DbSet<ImageryRecords> ImageryRecords { get; set; }

        public  DbSet<ImageryTargetLinks> ImageryTargetLinks { get; set; }

        public  DbSet<OfficialLetters> OfficialLetters { get; set; }

        public  DbSet<RequestTargets> RequestTargets { get; set; }

        public  DbSet<Requests> Requests { get; set; }

        public  DbSet<Roles> Roles { get; set; }

        public  DbSet<Satellites> Satellites { get; set; }

        public  DbSet<Targets> Targets { get; set; }

        public  DbSet<Users> Users { get; set; }
        int DBSaveChanges();
        Task<int> DBSaveChangesAsync(CancellationToken cancellationToken = default);
        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);

    }

}
