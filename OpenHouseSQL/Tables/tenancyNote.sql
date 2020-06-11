SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS tenancyNote;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE `tenancyNote` (
	`tenancyNoteId` INT NOT NULL AUTO_INCREMENT,
	`noteId` INT NOT NULL,
	`tenancyId` INT NOT NULL,
	PRIMARY KEY(`tenancyNoteId`),
	FOREIGN KEY(`tenancyId`) REFERENCES tenancy(`tenancyId`),
	FOREIGN KEY(`noteId`) REFERENCES note(`noteId`)
)

COLLATE='utf8_general_ci'
ENGINE=InnoDB
;