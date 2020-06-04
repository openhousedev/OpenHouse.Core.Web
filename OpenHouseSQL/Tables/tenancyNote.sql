SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS tenancyNote;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE `tenancyNote` (
	`noteId` INT NOT NULL,
	`tenancyId` INT NOT NULL,
	FOREIGN KEY(`tenancyId`) REFERENCES tenancy(`tenancyId`)
)

COLLATE='utf8_general_ci'
ENGINE=InnoDB
;