DROP TABLE IF EXISTS address;

CREATE TABLE `address` (
	`addressId` INT NOT NULL AUTO_INCREMENT,
	`propertyNum` INT,
	`propertySubNum` VARCHAR(5),
	`propertyName` VARCHAR(100),
	`address1` VARCHAR(500),
	`address2` VARCHAR(500),
	`address3` VARCHAR(500),
	`address4` VARCHAR(500),
	`postCode` VARCHAR(8),	
	PRIMARY KEY(`propertyId`),
	FOREIGN KEY (`propertyClassId`) REFERENCES propertyclass(`propertyClassId`)
)
COLLATE='utf8_general_ci'
ENGINE=InnoDB
;