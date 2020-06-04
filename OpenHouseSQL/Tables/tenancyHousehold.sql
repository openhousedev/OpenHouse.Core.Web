SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS tenancyHousehold;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE `tenancyHousehold` (
	`tenancyId` INT NOT NULL,
	`personId` INT NOT NULL,
	`leadTenantRelationshipId` INT NULL,
	`jointTenantRelationshipId` INT NULL,
	`updatedByUserID` INT,
	`updatedDT` DATETIME,
	`createdByUserID` INT,
	`createdDT` DATETIME,
	FOREIGN KEY(`tenancyId`) REFERENCES tenancy(`tenancyId`),
	FOREIGN KEY(`personId`) REFERENCES person(`personId`),
	FOREIGN KEY(`leadTenantRelationshipId`) REFERENCES relationship(`relationshipId`),
	FOREIGN KEY(`jointTenantRelationshipId`) REFERENCES relationship(`relationshipId`)
)

COLLATE='utf8_general_ci'
ENGINE=InnoDB
;
SET @currDate = CURDATE();

INSERT INTO tenancyHousehold VALUES(2,4,5,5,1,CURDATE(),1,CURDATE());
INSERT INTO tenancyHousehold VALUES(3,6,2,NULL,1,CURDATE(),1,CURDATE());

