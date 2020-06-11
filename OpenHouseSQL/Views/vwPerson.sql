DROP VIEW IF EXISTS `vwPerson`;

CREATE VIEW `vwPerson` AS
SELECT
	person.personId, 
	person.firstName, 
	person.middleName, 
	person.surname, 
	CONCAT(person.firstName,' ', person.surname) AS fullName,
	person.titleId, 
	title.title, 
	person.dateOfBirth, 
	person.telephone, 
	person.email, 
	person.nationalityId, 
	nationality.nationality, 
	person.nextOfKinFrstName, 
	person.nextOfKinSurname, 
	person.nextOfKinTelephone, 
	person.updatedByUserID, 
	person.updatedDT, 
	person.createdByUserID, 
	person.createdDT
FROM
	person
	INNER JOIN
	title
	ON 
		person.titleId = title.titleId
	INNER JOIN
	nationality
	ON
		person.nationalityId = nationality.nationalityIdaspnetusers