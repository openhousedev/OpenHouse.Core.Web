SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS propertyNote;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE `propertyNote` (
	`noteId` INT NOT NULL,
	`propertyId` INT NOT NULL,
	FOREIGN KEY(`propertyId`) REFERENCES property(`propertyId`)
)

COLLATE='utf8_general_ci'
ENGINE=InnoDB
;