DROP VIEW IF EXISTS `vwTenancy`;

CREATE VIEW `vwTenancy` AS

SELECT DISTINCT
	tenancy.tenancyId, 
	tenancy.propertyId, 
	vwproperty.contactAddress, 
	tenancy.leadTenantPersonId, 
	CONCAT(personLead.firstName,' ', personLead.surname) as leadTenant, 
	tenancy.jointTenantPersonId, 
	CONCAT(personJoint.firstName,' ', personJoint.surname) as jointTenant, 
	tenancy.tenureTypeId, 
	tenuretype.tenureType, 
	tenancy.startDate, 
	tenancy.terminationDate, 
	tenancy.terminationReasonId, 
	tenancyterminationreason.terminationReason, 
	tenancy.updatedByUserID, 
	tenancy.updatedDT, 
	tenancy.createdByUserID, 
	tenancy.createdDT
FROM
	tenancy
	INNER JOIN
	person personLead
	ON 
		tenancy.leadTenantPersonId = personLead.personId
	LEFT JOIN
	person personJoint
	ON 
		tenancy.jointTenantPersonId = personJoint.personId
	INNER JOIN
	tenuretype
	ON 
		tenancy.tenureTypeId = tenuretype.tenureTypeId
	LEFT JOIN
	tenancyterminationreason
	ON 
		tenancy.terminationReasonId = tenancyterminationreason.tenancyTerminationReasonId
	INNER JOIN
	vwproperty
	ON 
		tenancy.propertyId = vwproperty.propertyId