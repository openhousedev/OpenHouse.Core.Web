SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS rentLedger;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE `rentLedger` (
	`rentLedgerId` INT NOT NULL AUTO_INCREMENT,
	`tenancyId` INT NOT NULL,
	`propertyChargeId` INT NOT NULL,
	`periodStartDT` DATETIME NOT NULL,
	`periodEndDT` DATETIME NOT NULL,
	`paymentId` INT NULL,
	`updatedDT` DATETIME NOT NULL,
	`createdDT` DATETIME NOT NULL,
	PRIMARY KEY(`rentLedgerId`),
	FOREIGN KEY (`tenancyId`) REFERENCES tenancy(`tenancyId`),
	FOREIGN KEY (`paymentId`) REFERENCES payment(`paymentId`)
)

COLLATE='utf8_general_ci'
ENGINE=InnoDB
;
SET @currDate = CURDATE();