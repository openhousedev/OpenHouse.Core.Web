﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OpenHouse.Model.Core.Model
{
    public partial class OpenhouseContext : DbContext
    {
        public OpenhouseContext()
        {
        }

        public OpenhouseContext(DbContextOptions<OpenhouseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<action> action { get; set; }
        public virtual DbSet<actiontype> actiontype { get; set; }
        public virtual DbSet<alert> alert { get; set; }
        public virtual DbSet<alerttype> alerttype { get; set; }
        public virtual DbSet<nationality> nationality { get; set; }
        public virtual DbSet<note> note { get; set; }
        public virtual DbSet<person> person { get; set; }
        public virtual DbSet<property> property { get; set; }
        public virtual DbSet<propertyclass> propertyclass { get; set; }
        public virtual DbSet<propertynote> propertynote { get; set; }
        public virtual DbSet<propertytype> propertytype { get; set; }
        public virtual DbSet<relationship> relationship { get; set; }
        public virtual DbSet<rentaccount> rentaccount { get; set; }
        public virtual DbSet<tenancy> tenancy { get; set; }
        public virtual DbSet<tenancyalert> tenancyalert { get; set; }
        public virtual DbSet<tenancyhousehold> tenancyhousehold { get; set; }
        public virtual DbSet<tenancynote> tenancynote { get; set; }
        public virtual DbSet<tenancyterminationreason> tenancyterminationreason { get; set; }
        public virtual DbSet<tenuretype> tenuretype { get; set; }
        public virtual DbSet<title> title { get; set; }
        public virtual DbSet<vwaction> vwaction { get; set; }
        public virtual DbSet<vwalert> vwalert { get; set; }
        public virtual DbSet<vwperson> vwperson { get; set; }
        public virtual DbSet<vwproperty> vwproperty { get; set; }
        public virtual DbSet<vwtenancy> vwtenancy { get; set; }
        public virtual DbSet<vwtenancyhousehold> vwtenancyhousehold { get; set; }
        public virtual DbSet<vwuser> vwuser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;user id=root;password=0penH0use;persistsecurityinfo=True;database=openhouse", x => x.ServerVersion("10.5.3-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<action>(entity =>
            {
                entity.HasIndex(e => e.actionTypeId)
                    .HasName("actionTypeId");

                entity.HasIndex(e => e.tenancyId)
                    .HasName("tenancyId");

                entity.Property(e => e.assignedUserId)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.createdByUserID)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.updatedByUserID)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.actionType)
                    .WithMany(p => p.action)
                    .HasForeignKey(d => d.actionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("action_ibfk_1");

                entity.HasOne(d => d.tenancy)
                    .WithMany(p => p.action)
                    .HasForeignKey(d => d.tenancyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("action_ibfk_2");
            });

            modelBuilder.Entity<actiontype>(entity =>
            {
                entity.Property(e => e.actionType1)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<alert>(entity =>
            {
                entity.HasIndex(e => e.alertTypeId)
                    .HasName("alertTypeId");

                entity.Property(e => e.alertText)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.createdByUserID)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.updatedByUserID)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.alertType)
                    .WithMany(p => p.alert)
                    .HasForeignKey(d => d.alertTypeId)
                    .HasConstraintName("alert_ibfk_1");
            });

            modelBuilder.Entity<alerttype>(entity =>
            {
                entity.Property(e => e.alertType1)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<nationality>(entity =>
            {
                entity.Property(e => e.nationality1)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<note>(entity =>
            {
                entity.Property(e => e.createdByUserID)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.note1)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.updatedByUserID)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<person>(entity =>
            {
                entity.HasIndex(e => e.nationalityId)
                    .HasName("nationalityId");

                entity.HasIndex(e => e.titleId)
                    .HasName("titleId");

                entity.Property(e => e.createdByUserID)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.email)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.firstName)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.middleName)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.nextOfKinFrstName)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.nextOfKinSurname)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.nextOfKinTelephone)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.surname)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.telephone)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.updatedByUserID)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.nationality)
                    .WithMany(p => p.person)
                    .HasForeignKey(d => d.nationalityId)
                    .HasConstraintName("person_ibfk_2");

                entity.HasOne(d => d.title)
                    .WithMany(p => p.person)
                    .HasForeignKey(d => d.titleId)
                    .HasConstraintName("person_ibfk_1");
            });

            modelBuilder.Entity<property>(entity =>
            {
                entity.HasIndex(e => e.propertyClassId)
                    .HasName("propertyClassId");

                entity.HasIndex(e => e.propertyTypeId)
                    .HasName("propertyTypeId");

                entity.Property(e => e.address1)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.address2)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.address3)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.address4)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.createdByUserID)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.postCode)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.propertySubNum)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.updatedByUserID)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.propertyClass)
                    .WithMany(p => p.property)
                    .HasForeignKey(d => d.propertyClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("property_ibfk_1");

                entity.HasOne(d => d.propertyType)
                    .WithMany(p => p.property)
                    .HasForeignKey(d => d.propertyTypeId)
                    .HasConstraintName("property_ibfk_2");
            });

            modelBuilder.Entity<propertyclass>(entity =>
            {
                entity.Property(e => e.propertyClass1)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<propertynote>(entity =>
            {
                entity.HasIndex(e => e.noteId)
                    .HasName("noteId");

                entity.HasIndex(e => e.propertyId)
                    .HasName("propertyId");

                entity.HasOne(d => d.note)
                    .WithMany(p => p.propertynote)
                    .HasForeignKey(d => d.noteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("propertynote_ibfk_2");

                entity.HasOne(d => d.property)
                    .WithMany(p => p.propertynote)
                    .HasForeignKey(d => d.propertyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("propertynote_ibfk_1");
            });

            modelBuilder.Entity<propertytype>(entity =>
            {
                entity.Property(e => e.propertyType1)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<relationship>(entity =>
            {
                entity.Property(e => e.relationship1)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<rentaccount>(entity =>
            {
                entity.Property(e => e.rentAccount1)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<tenancy>(entity =>
            {
                entity.HasIndex(e => e.jointTenantPersonId)
                    .HasName("jointTenantPersonId");

                entity.HasIndex(e => e.leadTenantPersonId)
                    .HasName("leadTenantPersonId");

                entity.HasIndex(e => e.tenureTypeId)
                    .HasName("tenureTypeId");

                entity.HasIndex(e => e.terminationReasonId)
                    .HasName("terminationReasonId");

                entity.Property(e => e.createdByUserID)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.updatedByUserID)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.jointTenantPerson)
                    .WithMany(p => p.tenancyjointTenantPerson)
                    .HasForeignKey(d => d.jointTenantPersonId)
                    .HasConstraintName("tenancy_ibfk_3");

                entity.HasOne(d => d.leadTenantPerson)
                    .WithMany(p => p.tenancyleadTenantPerson)
                    .HasForeignKey(d => d.leadTenantPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tenancy_ibfk_2");

                entity.HasOne(d => d.tenureType)
                    .WithMany(p => p.tenancy)
                    .HasForeignKey(d => d.tenureTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tenancy_ibfk_1");

                entity.HasOne(d => d.terminationReason)
                    .WithMany(p => p.tenancy)
                    .HasForeignKey(d => d.terminationReasonId)
                    .HasConstraintName("tenancy_ibfk_4");
            });

            modelBuilder.Entity<tenancyalert>(entity =>
            {
                entity.HasIndex(e => e.alertId)
                    .HasName("alertId");

                entity.HasIndex(e => e.tenancyId)
                    .HasName("tenancyId");

                entity.HasOne(d => d.alert)
                    .WithMany(p => p.tenancyalert)
                    .HasForeignKey(d => d.alertId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tenancyalert_ibfk_2");

                entity.HasOne(d => d.tenancy)
                    .WithMany(p => p.tenancyalert)
                    .HasForeignKey(d => d.tenancyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tenancyalert_ibfk_1");
            });

            modelBuilder.Entity<tenancyhousehold>(entity =>
            {
                entity.HasIndex(e => e.jointTenantRelationshipId)
                    .HasName("jointTenantRelationshipId");

                entity.HasIndex(e => e.leadTenantRelationshipId)
                    .HasName("leadTenantRelationshipId");

                entity.HasIndex(e => e.personId)
                    .HasName("personId");

                entity.HasIndex(e => e.tenancyId)
                    .HasName("tenancyId");

                entity.Property(e => e.createdByUserID)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.updatedByUserID)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.jointTenantRelationship)
                    .WithMany(p => p.tenancyhouseholdjointTenantRelationship)
                    .HasForeignKey(d => d.jointTenantRelationshipId)
                    .HasConstraintName("tenancyhousehold_ibfk_4");

                entity.HasOne(d => d.leadTenantRelationship)
                    .WithMany(p => p.tenancyhouseholdleadTenantRelationship)
                    .HasForeignKey(d => d.leadTenantRelationshipId)
                    .HasConstraintName("tenancyhousehold_ibfk_3");

                entity.HasOne(d => d.person)
                    .WithMany(p => p.tenancyhousehold)
                    .HasForeignKey(d => d.personId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tenancyhousehold_ibfk_2");

                entity.HasOne(d => d.tenancy)
                    .WithMany(p => p.tenancyhousehold)
                    .HasForeignKey(d => d.tenancyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tenancyhousehold_ibfk_1");
            });

            modelBuilder.Entity<tenancynote>(entity =>
            {
                entity.HasIndex(e => e.noteId)
                    .HasName("noteId");

                entity.HasIndex(e => e.tenancyId)
                    .HasName("tenancyId");

                entity.HasOne(d => d.note)
                    .WithMany(p => p.tenancynote)
                    .HasForeignKey(d => d.noteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tenancynote_ibfk_2");

                entity.HasOne(d => d.tenancy)
                    .WithMany(p => p.tenancynote)
                    .HasForeignKey(d => d.tenancyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tenancynote_ibfk_1");
            });

            modelBuilder.Entity<tenancyterminationreason>(entity =>
            {
                entity.Property(e => e.terminationReason)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<tenuretype>(entity =>
            {
                entity.Property(e => e.tenureType1)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<title>(entity =>
            {
                entity.Property(e => e.title1)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<vwaction>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwaction");

                entity.Property(e => e.actionType)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.assignedUserId)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.assignedUsername)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.contactAddress)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.createdByUserID)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.updatedByUserID)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<vwalert>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwalert");

                entity.Property(e => e.alertText)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.createdByUserID)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.createdByUsername)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.updateByUsername)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.updatedByUserID)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<vwperson>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwperson");

                entity.Property(e => e.createdByUserID)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.email)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.firstName)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.fullName)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.middleName)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.nationality)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.nextOfKinFrstName)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.nextOfKinSurname)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.nextOfKinTelephone)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.surname)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.telephone)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.title)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.updatedByUserID)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<vwproperty>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwproperty");

                entity.Property(e => e.address1)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.address2)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.address3)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.address4)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.contactAddress)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.createdByUserID)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.postCode)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.propertyClass)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.propertySubNum)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.propertyType)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.tenancyId).HasDefaultValueSql("'0'");

                entity.Property(e => e.updatedByUserID)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<vwtenancy>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwtenancy");

                entity.Property(e => e.contactAddress)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.createdByUserID)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.jointTenant)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.leadTenant)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.tenureType)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.terminationReason)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.updatedByUserID)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<vwtenancyhousehold>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwtenancyhousehold");

                entity.Property(e => e.email)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.firstName)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.fullName)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.middleName)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.nationality)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.relationshipToJointTenant)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.relationshipToLeadTenant)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.surname)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.telephone)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.title)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<vwuser>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwuser");

                entity.Property(e => e.Email)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.UserName)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}