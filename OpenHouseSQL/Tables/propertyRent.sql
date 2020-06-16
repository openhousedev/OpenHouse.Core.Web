SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS propertyCharge;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE `propertyCharge` (
	`propertyChargeId` INT NOT NULL AUTO_INCREMENT,
	`propertyId` INT NOT NULL,
	`rentAccountId` INT NOT NULL,
	`charge` FLOAT,
	`startDT` DATETIME NOT NULL,
	`endDT` DATETIME NULL,
	`updatedByUserID` VARCHAR(255) NOT NULL,
	`updatedDT` DATETIME NOT NULL,
	`createdByUserID` VARCHAR(255) NOT NULL,
	`createdDT` DATETIME NOT NULL,
	PRIMARY KEY(`propertyChargeId`),
	FOREIGN KEY(`propertyId`) REFERENCES property(`propertyId`),
	FOREIGN KEY (`rentAccountId`) REFERENCES rentAccount(`rentAccountId`)
)
COLLATE='utf8_general_ci'
ENGINE=InnoDB
;
SET @currDate = CURDATE();

INSERT INTO propertyCharge VALUES(NULL,1,1,85.72,'2020-04-01',NULL,'611a361a-bce9-4783-b715-da82528a5988',CURDATE(),'611a361a-bce9-4783-b715-da82528a5988',CURDATE());
