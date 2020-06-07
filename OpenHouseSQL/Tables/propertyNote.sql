SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS propertyNote;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE `propertyNote` (
	`propertyNoteId` INT NOT NULL AUTO_INCREMENT,
	`noteId` INT NOT NULL,
	`propertyId` INT NOT NULL,
	PRIMARY KEY(`propertyNoteId`),
	FOREIGN KEY(`propertyId`) REFERENCES property(`propertyId`),
	FOREIGN KEY(`noteId`) REFERENCES note(`noteId`)
)

COLLATE='utf8_general_ci'
ENGINE=InnoDB
;