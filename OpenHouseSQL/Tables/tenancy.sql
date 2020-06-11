SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS tenancy;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE `tenancy` (
	`tenancyId` INT NOT NULL AUTO_INCREMENT,
	`propertyId` INT,
	`leadTenantPersonId` INT NOT NULL,
	`jointTenantPersonId` INT NULL,
	`tenureTypeId` INT NOT NULL,
	`startDate` datetime,
	`terminationDate` datetime,
	`terminationReasonId` INT NULL,
	`updatedByUserID` VARCHAR(255) NOT NULL,
	`updatedDT` DATETIME NOT NULL,
	`createdByUserID` VARCHAR(255) NOT NULL,
	`createdDT` DATETIME NOT NULL,
	PRIMARY KEY(`tenancyId`),
	FOREIGN KEY (`tenureTypeId`) REFERENCES tenureType(`tenureTypeId`),
	FOREIGN KEY (`leadTenantPersonId`) REFERENCES person(`personId`),
	FOREIGN KEY (`jointTenantPersonId`) REFERENCES person(`personId`),
	FOREIGN KEY (`terminationReasonId`) REFERENCES tenancyterminationreason(`tenancyTerminationReasonId`)
)

COLLATE='utf8_general_ci'
ENGINE=InnoDB
;
SET @currDate = CURDATE();

INSERT INTO tenancy VALUES(NULL,3,1,NULL,1,'2020-02-01',NULL,NULL,'611a361a-bce9-4783-b715-da82528a5988',CURDATE(),'611a361a-bce9-4783-b715-da82528a5988',CURDATE());
INSERT INTO tenancy VALUES(NULL,16,2,3,1,'2020-02-01',NULL,NULL,'611a361a-bce9-4783-b715-da82528a5988',CURDATE(),'611a361a-bce9-4783-b715-da82528a5988',CURDATE());
INSERT INTO tenancy VALUES(NULL,24,5,NULL,1,'2020-02-01',NULL,NULL,'611a361a-bce9-4783-b715-da82528a5988',CURDATE(),'611a361a-bce9-4783-b715-da82528a5988',CURDATE());
	
