DROP VIEW IF EXISTS `vwTenancyHouseHold`;

CREATE VIEW `vwTenancyHousehold` AS

WITH cteLeadTenanct AS
SELECT
	0,
	tenancyhousehold.tenancyId, 
	tenancyhousehold.personId, 
	title.title, 
	person.firstName, 
	person.middleName, 
	person.surname, 
	CONCAT(person.firstName, ' ', person.surname) as fullName,
	person.dateOfBirth, 
	person.telephone, 
	person.email, 
	person.nationalityId, 
	nationality.nationality, 
	tenancyhousehold.leadTenantRelationshipId, 
	relationshipLead.relationship as relationshipToLeadTenant, 
	tenancyhousehold.jointTenantRelationshipId, 
	relationshipJoint.relationship as relationshipToJointTenant
FROM
	tenancy
	INNER JOIN
	person
	ON 
		tenancyhousehold.personId = person.personId
	INNER JOIN
	title
	ON 
		person.titleId = title.titleId
	LEFT JOIN
	nationality
	ON 
		person.nationalityId = nationality.nationalityId
	LEFT JOIN
	relationship relationshipLead
	ON 
		tenancyhousehold.jointTenantRelationshipId = relationshipLead.relationshipId
	LEFT JOIN
	relationship relationshipJoint
	ON 
		tenancyhousehold.leadTenantRelationshipId = relationshipJoint.relationshipId
		
SELECT
	tenancyhousehold.tenancyHouseholdId,
	tenancyhousehold.tenancyId, 
	tenancyhousehold.personId, 
	title.title, 
	person.firstName, 
	person.middleName, 
	person.surname, 
	CONCAT(person.firstName, ' ', person.surname) as fullName,
	person.dateOfBirth, 
	person.telephone, 
	person.email, 
	person.nationalityId, 
	nationality.nationality, 
	tenancyhousehold.leadTenantRelationshipId, 
	relationshipLead.relationship as relationshipToLeadTenant, 
	tenancyhousehold.jointTenantRelationshipId, 
	relationshipJoint.relationship as relationshipToJointTenant
FROM
	tenancyhousehold
	INNER JOIN
	person
	ON 
		tenancyhousehold.personId = person.personId
	INNER JOIN
	title
	ON 
		person.titleId = title.titleId
	LEFT JOIN
	nationality
	ON 
		person.nationalityId = nationality.nationalityId
	LEFT JOIN
	relationship relationshipLead
	ON 
		tenancyhousehold.jointTenantRelationshipId = relationshipLead.relationshipId
	LEFT JOIN
	relationship relationshipJoint
	ON 
		tenancyhousehold.leadTenantRelationshipId = relationshipJoint.relationshipId