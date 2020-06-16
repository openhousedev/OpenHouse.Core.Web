SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS payment;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE `payment` (
	`paymentId` INT NOT NULL AUTO_INCREMENT,
	`propertyChargeId` INT NOT NULL,
	`tenancyId` INT NOT NULL,
	`paymentSourceId` INT NOT NULL,
	`amount` FLOAT,
	`paymentDT` DATETIME NOT NULL,
	`paymentProviderReference` VARCHAR(255),
	`updatedByUserID` VARCHAR(255) NOT NULL,
	`updatedDT` DATETIME NOT NULL,
	`createdByUserID` VARCHAR(255) NOT NULL,
	`createdDT` DATETIME NOT NULL,
	PRIMARY KEY(`paymentId`),
	FOREIGN KEY(`propertyChargeId`) REFERENCES propertyCharge(`propertyChargeId`),
	FOREIGN KEY (`tenancyId`) REFERENCES tenancy(`tenancyId`),
	FOREIGN KEY (`paymentSourceId`) REFERENCES paymentSource(`paymentSourceId`)
)
COLLATE='utf8_general_ci'
ENGINE=InnoDB
;
SET @currDate = CURDATE();