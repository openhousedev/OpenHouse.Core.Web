SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS tenancyHousehold;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE `tenancyHousehold` (
	`tenancyHouseholdId` INT NOT NULL AUTO_INCREMENT,
	`tenancyId` INT NOT NULL,
	`personId` INT NOT NULL,
	`leadTenantRelationshipId` INT NULL,
	`jointTenantRelationshipId` INT NULL,
	`updatedByUserID` VARCHAR(255) NOT NULL,
	`updatedDT` DATETIME NOT NULL,
	`createdByUserID` VARCHAR(255) NOT NULL,
	`createdDT` DATETIME NOT NULL,
	PRIMARY KEY(`tenancyHouseholdId`),
	FOREIGN KEY(`tenancyId`) REFERENCES tenancy(`tenancyId`),
	FOREIGN KEY(`personId`) REFERENCES person(`personId`),
	FOREIGN KEY(`leadTenantRelationshipId`) REFERENCES relationship(`relationshipId`),
	FOREIGN KEY(`jointTenantRelationshipId`) REFERENCES relationship(`relationshipId`)
)

COLLATE='utf8_general_ci'
ENGINE=InnoDB
;
SET @currDate = CURDATE();

INSERT INTO tenancyHousehold VALUES(NULL,2,4,5,5,'611a361a-bce9-4783-b715-da82528a5988',CURDATE(),'611a361a-bce9-4783-b715-da82528a5988',CURDATE());
INSERT INTO tenancyHousehold VALUES(NULL,3,6,2,NULL,'611a361a-bce9-4783-b715-da82528a5988',CURDATE(),'611a361a-bce9-4783-b715-da82528a5988',CURDATE());

