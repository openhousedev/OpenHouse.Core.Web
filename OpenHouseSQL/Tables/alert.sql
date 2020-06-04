SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS alert;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE `alert` (
	`alertId` INT NOT NULL AUTO_INCREMENT,
	`alertTypeId` INT,
	`alertText` TEXT,
	`startDT` DATETIME,
	`endDT` DATETIME,
	`updatedByUserID` INT,
	`updatedDT` DATETIME,
	`createdByUserID` INT,
	`createdDT` DATETIME,
	PRIMARY KEY(`alertId`),
	FOREIGN KEY(`alertTypeId`) REFERENCES alertType(`alertTypeId`)
)

COLLATE='utf8_general_ci'
ENGINE=InnoDB
;

