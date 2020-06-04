SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS note;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE `note` (
	`noteId` INT NOT NULL AUTO_INCREMENT,
	`note` TEXT,
	`updatedByUserID` INT,
	`updatedDT` DATETIME,
	`createdByUserID` INT,
	`createdDT` DATETIME,
	PRIMARY KEY(`noteId`)
)

COLLATE='utf8_general_ci'
ENGINE=InnoDB
;

