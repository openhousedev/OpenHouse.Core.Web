SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS tenancyAlert;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE `tenancyAlert` (
	`tenancyId` INT NOT NULL,
	`alertId` INT NOT NULL,
	FOREIGN KEY(`tenancyId`) REFERENCES tenancy(`tenancyId`),
	FOREIGN KEY(`alertId`) REFERENCES alert(`alertId`)
)

COLLATE='utf8_general_ci'
ENGINE=InnoDB
;


