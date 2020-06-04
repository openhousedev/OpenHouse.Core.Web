SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS tenuretype;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE `tenureType` (
	`tenureTypeId` INT NOT NULL AUTO_INCREMENT,
	`tenureType` VARCHAR(100) NULL DEFAULT NULL,
	PRIMARY KEY(`tenureTypeId`)
)
COLLATE='utf8_general_ci'
ENGINE=InnoDB
;

INSERT INTO tenureType VALUES(1,'Assured');
INSERT INTO tenureType VALUES(2,'Homeless');
INSERT INTO tenureType VALUES(3,'Leased');
INSERT INTO tenureType VALUES(4,'Private Garage');
INSERT INTO tenureType VALUES(5,'Rent to Buy');
